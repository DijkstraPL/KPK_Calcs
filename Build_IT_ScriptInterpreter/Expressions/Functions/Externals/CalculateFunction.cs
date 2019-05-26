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
    public class CalculateFunction : IFunction
    {
        #region Properties

        public string Name { get; private set; }

        public Func<FunctionArgs, object> Function { get; private set; }

        [Import]
        public ICalculator Calculator { get; set; }

        #endregion // Properties

        #region Fields

        private string _scriptName;
        private string _prefix;
        private const string _defaultPrefix = "#";

        #endregion // Fields

        #region Constructors

        public CalculateFunction()
        {
            Set();
        }

        #endregion // Constructors

        #region Private_Methods

        private void Set()
        {
            Name = "Calculate";
            Function = (e) =>
            {
                _prefix = _defaultPrefix;
                _scriptName = e.Parameters[0]?.Evaluate()?.ToString();
                if (_scriptName.Contains(_defaultPrefix))
                {
                    _prefix = _scriptName.Substring(_scriptName.IndexOf(_defaultPrefix));
                    _scriptName = _scriptName.Substring(0, _scriptName.IndexOf(_defaultPrefix));
                }

                Compose(_scriptName);
                if (Calculator != null)
                    return CalculateService(e);

                using (var scriptInterpreterDbContext = new ScriptInterpreterDbContext(new DbContextOptions<ScriptInterpreterDbContext>()))
                {
                   var scriptRepository = new ScriptRepository(scriptInterpreterDbContext);
                    var scriptData = scriptRepository.GetScriptBaseOnNameAsync(_scriptName).Result;
                    if (scriptData != null)
                    {
                        var parameterRepository = new ParameterRepository(scriptInterpreterDbContext);
                        return CalculateScript(scriptData, e, parameterRepository);
                    }
                }

                throw new ArgumentException("No script with name " + _scriptName);

            };
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

        private object CalculateScript(SI.Script scriptData, FunctionArgs functionArgs, IParameterRepository parameterRepository)
        {
            var parametersData = parameterRepository.GetAllParametersForScriptAsync(scriptData.Id).Result;
            var script = ScriptBuilder.Create(
                    scriptData.Name,
                    scriptData.Description,
                    new string[0])
                    .Build();

            var parameters = new List<IParameter>();
            foreach (var parameter in parametersData)
            {
                parameters.Add(new SIP.Parameter()
                {
                    Number = parameter.Number,
                    Name = parameter.Name,
                    Value = parameter.Value,
                    VisibilityValidator = parameter.VisibilityValidator,
                    Context = (SIP.ParameterOptions)parameter.Context
                });
            }

            script.Parameters = parameters;

            var calculationEngine = new CalculationEngine(script);

            Dictionary<string, object> parameterValues = new Dictionary<string, object>();
            for (int i = 1; i < functionArgs.Parameters.Length; i += 2)
                parameterValues.Add(functionArgs.Parameters[i].Evaluate().ToString(), functionArgs.Parameters[i + 1].Evaluate());

            calculationEngine.Calculate(parameterValues);
            parameters.RemoveAll(p => !parameterValues.ContainsKey(p.Name));

            foreach (var par in parameterValues)
            {
                var pp = parameters.SingleOrDefault(p => p.Name == par.Key);
                if (pp != null)
                    pp.Value = par.Value.ToString();
            }

            foreach (var par in parameters.Where(p=> (p.Context & SIP.ParameterOptions.Calculation) != 0))
                functionArgs.Parameters.First().Parameters.Add($"{_prefix}{par.Name}", par.Value);

            return true;
        }

        private void Compose(string calculatorName)
        {
            var configuration = new ContainerConfiguration()
               .WithAssembly(typeof(ServiceStartup).GetTypeInfo().Assembly);

            using (var container = configuration.CreateContainer())
            {
                ICalculator calculator;
                if (container.TryGetExport<ICalculator>(calculatorName, out calculator))
                    Calculator = calculator;
            }
        }

        private object SetParameters(IResult result, FunctionArgs functionArgs)
        {
            //StringBuilder setFunction = new StringBuilder("SET(");

            //foreach(var property in result.Properties)
            //    setFunction.Append(property.Key)
            //        .Append(",")
            //        .Append(property.Value)
            //        .Append(",");

            //setFunction.Remove(setFunction.Length - 1, 1)
            //    .Append(")");

            foreach (var property in result.Properties)
                functionArgs.Parameters.First().Parameters.Add($"{_prefix}{property.Key}", property.Value);
            //functionArgs
            //var expression = new ExpressionWrapper(setFunction.ToString());
            //return expression.Evaluate();
            return true;
        }

        #endregion // Private_Methods      
    }
}
