﻿using Build_IT_CommonTools.Extensions;
using Build_IT_ScriptInterpreter.Expressions;
using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Scripts.Interfaces;
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

        private readonly ICollection<IParameter> _scriptParameters;

        #endregion // Fields

        #region Constructors

        public CalculationEngine(ICollection<IParameter> scriptParameters)
        {
            _scriptParameters = scriptParameters;
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

            SetEditableValues(parameters);
            Calculate(parameters);
        }


        public void Calculate(IDictionary<string, object> parameters)
        {
            SetVisibilityValidators();
            SetStaticParameters(parameters);
            ValidateEditableParameters(parameters);
            CalculateParameters(parameters);
        }

        public bool CheckVisibility(string parameterName, IDictionary<string, object> parameters)
            => IsVisible(_scriptParameters.SingleOrDefault(p => p.Name == parameterName), parameters);

        public bool CalculatePrediction(string equation, IDictionary<string, object> parameters)
        {
            if (string.IsNullOrWhiteSpace(equation))
                return true;

            var expressionEvaluator = ExpressionEvaluator.Create(equation, parameters);
            try
            {
                return (bool)expressionEvaluator.Evaluate();
            }
            catch (ArgumentException)
            {
                return true;
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
        private void SetParameter(IDictionary<string, object> parameters, string parameterName, string parameterValue)
        {
            if (_scriptParameters.SingleOrDefault(p => p.Name == parameterName).ValueType == ValueTypes.Number)
                parameters.Add(parameterName, parameterValue.GetDouble());
            else
                parameters.Add(parameterName, parameterValue.ToString());
        }

        private void SetEditableValues(IDictionary<string, object> parameters)
        {
            foreach (var parameter in _scriptParameters
                .Where(p => (p.Context & ParameterOptions.Editable) != 0))
            {
                if (!string.IsNullOrWhiteSpace(parameter.Value?.ToString()))
                    parameter.Value = parameters.SingleOrDefault(p => p.Key == parameter.Name).Value;
            }
        }

        private void SetVisibilityValidators()
        {
            foreach (var parameter in _scriptParameters)
                parameter.VisibilityValidator = GetVisibilityValidator(parameter);
        }

        private string GetVisibilityValidator(IParameter parameter)
        {
            string visibilityValidator = string.Empty;

            if (!string.IsNullOrWhiteSpace(parameter.Group?.VisibilityValidator))
                visibilityValidator = parameter.Group.VisibilityValidator;

            if (string.IsNullOrWhiteSpace(visibilityValidator))
                visibilityValidator = parameter.VisibilityValidator?.ToString();
            else if (!string.IsNullOrWhiteSpace(parameter.VisibilityValidator?.ToString()))
                visibilityValidator = $"({visibilityValidator})&&({parameter.VisibilityValidator})";
            return visibilityValidator;
        }

        private void SetStaticParameters(IDictionary<string, object> parameters)
        {
            var staticParameters = _scriptParameters
                .Where(p => (p.Context & ParameterOptions.StaticData) != 0).ToList();
            foreach (var parameter in staticParameters)
            {
                if (parameter.ValueType == ValueTypes.Number)
                    parameters.TryAdd(parameter.Name,
                        double.Parse(parameter.Value.ToString().Replace(',', '.'), CultureInfo.InvariantCulture));
                else
                    parameters.TryAdd(parameter.Name,
                        parameter.Value.ToString());

            }
        }

        private void ValidateEditableParameters(IDictionary<string, object> parameters)
        {
            foreach (var parameter in _scriptParameters
                .Where(p => (p.Context & ParameterOptions.Editable) != 0))
                if (!IsValid(parameter, parameters))
                    throw new ArgumentException("Wrong data", parameter.Name);
        }

        private bool IsValid(IParameter parameter, IDictionary<string, object> parameters)
        {
            var value = parameter.DataValidator?.ToString();
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

        private void CalculateParameters(IDictionary<string, object> parameters)
        {
            foreach (var parameter in _scriptParameters.Where(p =>
                (p.Context & ParameterOptions.Calculation) != 0))
            {
                if (!IsVisible(parameter, parameters))
                    continue;

                CalculateParameter(parameter, parameters);
                if (parameters.ContainsKey(parameter.Name))
                    parameters[parameter.Name] = parameter.Value;
                else
                    parameters.Add(parameter.Name, parameter.Value);

                if (!string.IsNullOrWhiteSpace(parameter.DataValidator?.ToString()))
                    CalculateDataValidator(parameter, parameters);
            }
        }

        private bool IsVisible(IParameter parameter, IDictionary<string, object> parameters)
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

        private void CalculateParameter(IParameter parameter, IDictionary<string, object> parameters)
        {
            var expressionEvaluator = ExpressionEvaluator.Create(
                Regex.Replace(parameter.Value.ToString(), @"\s+(?=([^']*'[^']*')*[^']*$)", string.Empty), parameters);
            try
            {
                parameter.Value = expressionEvaluator.Evaluate();
                if (parameter.ValueType == ValueTypes.Number && parameter.Value.GetType() == typeof(String))
                    parameter.Value = Convert.ToDouble(parameter.Value.ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
            }
            catch (ArgumentException ex)
            {
                parameter.Value = ex.Message;
            }
        }

        private void CalculateDataValidator(IParameter parameter, IDictionary<string, object> parameters)
        {
            parameter.DataValidator = IsValid(parameter, parameters);
        }

        #endregion // Private_Methods
    }
}
