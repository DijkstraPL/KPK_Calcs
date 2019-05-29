using Build_IT_Data.Calculators.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_ScriptInterpreter.Expressions.Functions.Interfaces;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Scripts;
using Build_IT_ScriptService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NCalc;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.Linq;
using System.Reflection;
using SI = Build_IT_DataAccess.ScriptInterpreter.Models;
using SIP = Build_IT_ScriptInterpreter.Parameters;

namespace Build_IT_ScriptInterpreter.Expressions.Functions.Externals
{
    [Export(typeof(IFunction))]
    public class CalculateFunction : IFunction
    {
        #region Properties

        public string Name { get; private set; }

        public Func<FunctionArgs, object> Function { get; private set; }

        public ICalculator Calculator { get; private set; }

        #endregion // Properties

        #region Fields

        private string _scriptName;
        private string _prefix;
        private const string _defaultPrefix = "#";
        private readonly IScriptRepository _scriptRepository;
        private readonly IParameterRepository _parameterRepositort;
        private readonly bool _useContainer = true;

        #endregion // Fields

        #region Constructors

        public CalculateFunction()
        {
            Set();
        }

        internal CalculateFunction(
            IScriptRepository scriptRepository = null,
            IParameterRepository parameterRepositort = null,
            bool useContainer = false,
            ICalculator calculator = null) : this()
        {
            _scriptRepository = scriptRepository;
            _parameterRepositort = parameterRepositort;
            _useContainer = useContainer;
            Calculator = calculator;
        }

        #endregion // Constructors

        #region Private_Methods

        private void Set()
        {
            Name = "CALCULATE";
            Function = (e) =>
            {
                _prefix = _defaultPrefix;
                _scriptName = e.Parameters[0]?.Evaluate()?.ToString();
                if (_scriptName.Contains(_defaultPrefix))
                {
                    _prefix = _scriptName.Substring(_scriptName.IndexOf(_defaultPrefix));
                    _scriptName = _scriptName.Substring(0, _scriptName.IndexOf(_defaultPrefix));
                }

                if (_useContainer)
                    Compose(_scriptName);
                if (Calculator != null)
                    return CalculateService(e);

                return CalculateScriptFromDatabase(e);

            };
        }

        private void Compose(string calculatorName)
        {
            var configuration = new ContainerConfiguration()
               .WithAssembly(typeof(ServiceStartup).GetTypeInfo().Assembly);

            using (var container = configuration.CreateContainer())
            {
                if (container.TryGetExport(calculatorName, out ICalculator calculator))
                    Calculator = calculator;
            }
        }

        private object CalculateService(FunctionArgs functionArgs)
        {
            IList<object> arguments = new List<object>();
            for (int i = 1; i < functionArgs.Parameters.Length; i++)
                try
                {
                    arguments.Add(functionArgs.Parameters[i].Evaluate());
                }
                catch (ArgumentException)
                {
                    arguments.RemoveAt(arguments.Count - 1);
                }

            Calculator.Map(arguments);
            return SetParameters(Calculator.Calculate(), functionArgs);
        }
        
        private object SetParameters(IResult result, FunctionArgs functionArgs)
        {
            foreach (var property in result.Properties)
                functionArgs.Parameters.First().Parameters.Add($"{_prefix}{property.Key}", property.Value);

            return true;
        }

        private object CalculateScriptFromDatabase(FunctionArgs e)
        {
            if (_scriptRepository != null && _scriptRepository != null)
            {
                var scriptData = _scriptRepository.GetScriptBaseOnNameAsync(_scriptName).Result;
                if (scriptData != null)
                    return CalculateScript(scriptData, e, _parameterRepositort);

                throw new ArgumentException("No script with name " + _scriptName);
            }

            using (var scriptInterpreterDbContext = new ScriptInterpreterDbContext(new DbContextOptions<ScriptInterpreterDbContext>()))
            {
                var scriptRepository = _scriptRepository ?? new ScriptRepository(scriptInterpreterDbContext);
                var scriptData = scriptRepository.GetScriptBaseOnNameAsync(_scriptName).Result;
                if (scriptData != null)
                {
                    var parameterRepository = _parameterRepositort ?? new ParameterRepository(scriptInterpreterDbContext);
                    return CalculateScript(scriptData, e, parameterRepository);
                }
            }

            throw new ArgumentException("No script with name " + _scriptName);
        }

        
        private object CalculateScript(SI.Script scriptData, FunctionArgs functionArgs, IParameterRepository parameterRepository)
        {
            var script = ScriptBuilder.Create(
                    scriptData.Name,
                    scriptData.Description,
                    new string[0])
                    .Build();

            script.Parameters = GetParameters(scriptData, parameterRepository).ToList();

            var calculationEngine = new CalculationEngine(script);

            IDictionary<string, object> parameterValues = GetParametersValues(functionArgs);

            calculationEngine.Calculate(parameterValues);
            IncludeParameterValues(script, parameterValues);

            SetPrefixes(functionArgs, script);

            return true;
        }


        private IEnumerable<IParameter> GetParameters(SI.Script scriptData, IParameterRepository parameterRepository)
        {
            var parametersData = parameterRepository.GetAllParametersForScriptAsync(scriptData.Id).Result;
            foreach (var parameter in parametersData)
            {
                yield return new SIP.Parameter()
                {
                    Number = parameter.Number,
                    Name = parameter.Name,
                    Value = parameter.Value,
                    VisibilityValidator = parameter.VisibilityValidator,
                    Context = (SIP.ParameterOptions)parameter.Context
                };
            }
        }

        private IDictionary<string, object> GetParametersValues(FunctionArgs functionArgs)
        {
            IDictionary<string, object> parameterValues = new Dictionary<string, object>();
            for (int i = 1; i < functionArgs.Parameters.Length; i += 2)
                parameterValues.Add(functionArgs.Parameters[i].Evaluate().ToString(), functionArgs.Parameters[i + 1].Evaluate());
            return parameterValues;
        }

        private static void IncludeParameterValues(Scripts.Interfaces.IScript script, IDictionary<string, object> parameterValues)
        {
            script.Parameters.RemoveAll(p => !parameterValues.ContainsKey(p.Name));

            foreach (var par in parameterValues)
            {
                var pp = script.Parameters.SingleOrDefault(p => p.Name == par.Key);
                if (pp != null)
                    pp.Value = par.Value.ToString();
            }
        }

        private void SetPrefixes(FunctionArgs functionArgs, Scripts.Interfaces.IScript script)
        {
            foreach (var par in script.Parameters.Where(p => (p.Context & SIP.ParameterOptions.Calculation) != 0))
                functionArgs.Parameters.First().Parameters.Add($"{_prefix}{par.Name}", par.Value);
        }

        #endregion // Private_Methods      
    }
}
