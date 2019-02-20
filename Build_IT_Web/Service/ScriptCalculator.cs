using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Scripts.Interfaces;
using Build_IT_Web.Controllers.Resources;
using Build_IT_Web.Core.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using SI = Build_IT_ScriptInterpreter.Scripts;
using SIP = Build_IT_ScriptInterpreter.Parameters;

namespace Build_IT_Web.Service
{
    public class ScriptCalculator
    {
        private readonly Script _script;
        private readonly List<Parameter> _parameters;

        private SI.CalculationEngine _calculationEngine;
        private IScript _scriptToInterpret;

        public ScriptCalculator(Script script, List<Parameter> parameters)
        {
            _script = script;
            _parameters = parameters;
        }

        internal async Task CalculateAsync(List<ParameterResource> userParameters)
        {
            _scriptToInterpret = await MapScript();
            var parameters = await MapParameters();
            _scriptToInterpret.Parameters = parameters.ToList();

            _calculationEngine = new SI.CalculationEngine(_scriptToInterpret);

            var parameterValues = userParameters
                .ToDictionary(
                p => p.Name,
                p => p.ValueType == SIP.ValueTypes.Number ?
                double.Parse(p.Value.Replace(',','.'), NumberStyles.Any, CultureInfo.InvariantCulture) : 
                (object)p.Value);
            _calculationEngine.Calculate(parameterValues);
            _parameters.RemoveAll(p => !parameterValues.ContainsKey(p.Name));

            foreach (var par in parameterValues)
            {
               var pp = _parameters.SingleOrDefault(p => p.Name == par.Key);
                if (pp != null)
                    pp.Value = par.Value.ToString();
            }
        }

        internal IEnumerable<Parameter> GetResult() 
            => _parameters.Where(p => (p.Context & SIP.ParameterOptions.Calculation) != 0);

        private async Task<IScript> MapScript()
        {
            return await Task.Run(() =>
            {
                return SI.ScriptBuilder.Create(
                    _script.Name,
                    _script.Description,
                    _script.Tags.Select(t => t.Tag.Name).ToArray())
                    .Build();
            });
        }

        private async Task<IEnumerable<IParameter>> MapParameters()
        {
            return await Task.Run(() =>
            {
                var parameters = new List<SIP.Parameter>();
                foreach (var parameter in _parameters)
                {
                    parameters.Add(new SIP.Parameter()
                    {
                        Number = parameter.Number,
                        Name = parameter.Name,
                        Value = parameter.Value,
                        DataValidator = parameter.DataValidator,
                        Context = parameter.Context
                    });
                }
                return parameters;
            });
        }
    }
}
