using Build_IT_Application.ScriptInterpreter.Calculations.Queries;
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
        #region Fields

        private readonly List<ParameterResource> _parameters;

        private SI.CalculationEngine _calculationEngine;
        private IDictionary<string, object> _parameterValues;

        #endregion // Fields

        #region Constructors

        public ScriptCalculator(List<ParameterResource> parameters)
        {
            _parameters = parameters;
        }

        #endregion // Constructors

        #region Internal_Methods

        internal async Task<bool> ValidateResults(IEnumerable<CalculateParameterResource> userParameters, params string[] validatorEquations)
        {
            await CalculateAsync(userParameters).ConfigureAwait(false);

            return validatorEquations.All(ve => _calculationEngine.CalculatePrediction(ve, _parameterValues));
        }

        internal async Task CalculateAsync(IEnumerable<CalculateParameterResource> userParameters)
        {
            var parameters = await MapParameters();

            _calculationEngine = new SI.CalculationEngine(parameters.ToList());

            _parameterValues = userParameters
                .Where(p => (p.Context & SIP.ParameterOptions.Optional) == 0 ||
                !string.IsNullOrWhiteSpace(p.Value) && (p.Context & SIP.ParameterOptions.Optional) != 0)
                .ToDictionary(
                p => p.Name,
                p => p.ValueType == SIP.ValueTypes.Number ?
                 string.IsNullOrWhiteSpace(p.Value) ? 0 :
                 double.Parse(p.Value?.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture) :
                (object)p.Value);
            _calculationEngine.Calculate(_parameterValues);
            _parameters.RemoveAll(p => !_parameterValues.ContainsKey(p.Name) ||
                !_calculationEngine.CalculatePrediction(p.VisibilityValidator, _parameterValues) ||
                !_calculationEngine.CalculatePrediction(p.Group?.VisibilityValidator, _parameterValues));

            foreach (var par in _parameterValues)
            {
                var pp = _parameters.SingleOrDefault(p => p.Name == par.Key);
                if (pp == null)
                    continue;
                pp.Value = par.Value.ToString();
                if ((pp.Context & ParameterOptions.Calculation) != 0 &&
                    (pp.Context & ParameterOptions.Visible) != 0 &&
                    !string.IsNullOrWhiteSpace(pp.DataValidator))
                    pp.DataValidator = parameters.SingleOrDefault(p => p.Name == par.Key)?.DataValidator?.ToString();
            }
        }

        internal IEnumerable<ParameterResource> GetResult()
            => _parameters.Where(p =>
            ((SIP.ParameterOptions)p.Context & SIP.ParameterOptions.Calculation) != 0 &&
            _calculationEngine.CalculatePrediction(p.VisibilityValidator, _parameterValues));

        #endregion // Internal_Methods

        #region Private_Methods

        //private async Task<IScript> MapScript()
        //{
        //    return await Task.Run(() =>
        //    {
        //        return SI.ScriptBuilder.Create(
        //            _script.Name,
        //            _script.Description,
        //            _script.Tags.Select(t => t.Tag.Name).ToArray())
        //            .Build();
        //    }).ConfigureAwait(false);
        //}

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
                        Context = (SIP.ParameterOptions)parameter.Context,
                        Group = parameter.Group != null ?
                            new SIP.Group { VisibilityValidator = parameter.Group.VisibilityValidator } : null
                    });
                }
                return parameters;
            }).ConfigureAwait(false);
        }


        #endregion // Private_Methods
    }
}
