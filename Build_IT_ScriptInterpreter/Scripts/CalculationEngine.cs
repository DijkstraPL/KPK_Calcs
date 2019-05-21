using Build_IT_ScriptInterpreter.Expressions;
using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Scripts.Interfaces;
using Build_IT_CommonTools;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Build_IT_ScriptInterpreter.Scripts
{
    public class CalculationEngine
    {
        #region Fields

        private readonly ICalculatable _script;
        private readonly ICollection<IParameter> _scriptParameters;

        #endregion // Fields

        #region Constructors

        public CalculationEngine(ICalculatable script)
        {
            _script = script;
            _scriptParameters = _script.Parameters;
        }

        #endregion // Constructors

        #region Public_Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterValues">In format "[a]=555,[b]=333"</param>
        public void CalculateFromText(string parameterValues)
        {
            Dictionary<string, object> parameters = ExtractParameters(parameterValues);

            SetStaticParameters(parameters);
            SetEditableValues(parameters);
            Calculate(parameters);
        }


        public void Calculate(Dictionary<string, object> parameters)
        {
            var staticParameters = _scriptParameters
                .Where(p => (p.Context & ParameterOptions.StaticData) != 0).ToList();
            foreach (var parameter in staticParameters)
                parameters.Add(parameter.Name, double.Parse(parameter.Value.ToString(), CultureInfo.InvariantCulture));

            foreach (var parameter in _scriptParameters.Where(p =>
                (p.Context & ParameterOptions.Calculation) != 0))
            {
                if (!IsValid(parameter, parameters))
                    continue;

                CalculateParameter(parameter, parameters);
                if (parameters.ContainsKey(parameter.Name))
                    parameters[parameter.Name] = parameter.Value;
                else
                    parameters.Add(parameter.Name, parameter.Value);
            }
        }

        #endregion // Public_Methods

        #region Private_Methods

        private Dictionary<string, object> ExtractParameters(string parameterValues)
        {
            var parameters = new Dictionary<string, object>();
            bool inParameter = false;
            string parameterName = string.Empty;
            string parameterValue = string.Empty;
            foreach (var ch in parameterValues)
            {
                if (ch == '=')
                    continue;
                else if (ch == '[')
                    inParameter = true;
                else if (ch == ']')
                    inParameter = false;
                else if (ch == '|' && !inParameter)
                {
                    SetParameter(parameters, parameterName, parameterValue);
                    parameterName = string.Empty;
                    parameterValue = string.Empty;
                }
                else if (inParameter)
                    parameterName += ch;
                else
                    parameterValue += ch;
            }
            parameters.Add(parameterName, parameterValue.GetDouble());
            return parameters;
        }

        private void SetStaticParameters(Dictionary<string, object> parameters)
        {
            foreach (var parameter in _scriptParameters.Where(p => (p.Context & ParameterOptions.StaticData) != 0))
                parameters.Add(parameter.Name, parameter.Value);
        }

        private void SetEditableValues(Dictionary<string, object> parameters)
        {
            foreach (var parameter in _scriptParameters.Where(p => (p.Context & ParameterOptions.Editable) != 0))
            {
                if (!string.IsNullOrWhiteSpace(parameter.Value?.ToString()))
                    parameter.Value = parameters.SingleOrDefault(p => p.Key == parameter.Name).Value;
                else if (parameter.Scripts.Count > 0)
                {
                    var neededParameters = parameter.Scripts[0].Parameters.Where(p
                        => (p.Context & ParameterOptions.Editable) != 0);
                    var providedParameters = parameters.Where(p => neededParameters.Select(np => np.Name).Contains(p.Key));
                    string parameterValues = "";
                    foreach (var param in providedParameters)
                    {
                        parameterValues += "[";
                        parameterValues += param.Key;
                        parameterValues += "]=";
                        parameterValues += param.Value;
                        parameterValues += ",";
                    }
                    parameterValues = parameterValues.Remove(parameterValues.Length - 1, 1);

                    var calculateEngine = new CalculationEngine(parameter.Scripts[0]);
                    calculateEngine.CalculateFromText(parameterValues);
                    parameter.Value = parameter.Scripts[0].Parameters.FirstOrDefault(p => p.Name == parameter.Name).Value;
                }
            }
        }

        private IEnumerable<IParameter> PrepareDataParameters(object[] values)
        {
            int i = 0;
            foreach (var parameter in _scriptParameters.Where(p
                => (p.Context & ParameterOptions.Calculation) == 0))
            {
                if ((parameter.Context & ParameterOptions.StaticData) == 0)
                    parameter.Value = values[i++];
                yield return parameter;
            }
        }

        private void SetParameter(Dictionary<string, object> parameters, string parameterName, string parameterValue)
        {
            if (_scriptParameters.SingleOrDefault(p => p.Name == parameterName).ValueType == ValueTypes.Number)
                parameters.Add(parameterName, parameterValue.GetDouble());
            else
                parameters.Add(parameterName, parameterValue.ToString());
        }

        private static void CalculateParameter(IParameter parameter, Dictionary<string, object> parameters)
        {
            var expressionEvaluator = ExpressionEvaluator.Create(
                Regex.Replace(parameter.Value.ToString(), @"\s+(?=([^']*'[^']*')*[^']*$)", string.Empty), parameters);
            try
            {
                parameter.Value = expressionEvaluator.Evaluate();
            }
            catch (ArgumentException ex)
            {
                parameter.Value = ex.Message;
            }
        }

        private bool IsValid(IParameter parameter, Dictionary<string, object> parameters)
        {
            var value = parameter.VisibilityValidator?.ToString();
            if (string.IsNullOrWhiteSpace(value))
                return true;

            var expressionEvaluator = ExpressionEvaluator.Create(value, parameters);
            try
            {
                return (bool)expressionEvaluator.Evaluate();
            }
            catch (ArgumentException)
            {
                return true;
            }
        }

        #endregion // Private_Methods
    }
}
