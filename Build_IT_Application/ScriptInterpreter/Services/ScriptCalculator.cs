using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Scripts.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using SI = Build_IT_ScriptInterpreter.Scripts;
using SIP = Build_IT_ScriptInterpreter.Parameters;

namespace Build_IT_Applications.ScriptInterpreter.Services
{
    public class ScriptCalculator
    {
        private readonly Script _script;
        private readonly List<Parameter> _parameters;

        private SI.CalculationEngine _calculationEngine;
        private IDictionary<string, object> _parameterValues;
        private IScript _scriptToInterpret;

        public ScriptCalculator(Script script, List<Parameter> parameters)
        {
            _script = script;
            _parameters = parameters;
        }

        internal async Task CalculateAsync(IEnumerable<ParameterResource> userParameters)
        {
            _scriptToInterpret = await MapScript();
            var parameters = await MapParameters();
            _scriptToInterpret.Parameters = parameters.ToList();

            _calculationEngine = new SI.CalculationEngine(_scriptToInterpret);

            _parameterValues = userParameters
                .Where(p => (p.Context & ParameterOptions.Optional) == 0 ||
                !string.IsNullOrWhiteSpace(p.Value) && (p.Context & ParameterOptions.Optional) != 0)
                .ToDictionary(
                p => p.Name,
                p => p.ValueType == ValueTypes.Number ?
                 string.IsNullOrWhiteSpace(p.Value) ? 0 :
                 double.Parse(p.Value?.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture) :
                (object)p.Value);
            _calculationEngine.Calculate(_parameterValues);
            _parameters.RemoveAll(p => !_parameterValues.ContainsKey(p.Name));

            foreach (var par in _parameterValues)
            {
                var pp = _parameters.SingleOrDefault(p => p.Name == par.Key &&
                _calculationEngine.CalculatePrediction(p.VisibilityValidator, _parameterValues));
                if (pp != null)
                    pp.Value = par.Value.ToString();
            }
        }

        internal IEnumerable<Parameter> GetResult()
            => _parameters.Where(p => 
            ((SIP.ParameterOptions)p.Context & SIP.ParameterOptions.Calculation) != 0 && 
            _calculationEngine.CalculatePrediction(p.VisibilityValidator, _parameterValues));

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
                        ValueType = (SIP.ValueTypes)parameter.ValueType,
                        VisibilityValidator = parameter.VisibilityValidator,
                        DataValidator = parameter.DataValidator,
                        Context = (SIP.ParameterOptions)parameter.Context
                    });
                }
                return parameters;
            });
        }
    }
}
