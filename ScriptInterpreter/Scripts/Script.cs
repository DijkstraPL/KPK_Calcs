using Build_IT_ScriptInterpreter.DataSaver.Interfaces;
using Build_IT_ScriptInterpreter.Expressions;
using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static Build_IT_Tools.ParseExtended;

namespace Build_IT_ScriptInterpreter.Scripts
{
    public class Script
    {
        public string Name { get; }
        public string Description { get; }
        public ICollection<string> Tags { get; set; }
        public string GroupName { get; set; }

        public ICollection<IParameter> Parameters { get; set; }

        public Script(string name, string description, params string[] tags)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Tags = new List<string>(tags);
            Parameters = new SortedSet<IParameter>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterValues">In format "[a]=555,[b]=333"</param>
        public void CalculateFromText(string parameterValues)
        {
            var parameters = new Dictionary<string, object>();
            bool inParameter = false;
            string parameterName = string.Empty;
            string parameterValue = string.Empty;
            foreach (var ch in parameterValues)
            {
                if (ch == '=')
                {
                    continue;
                }
                else if (ch == '[')
                    inParameter = true;
                else if (ch == ']')
                    inParameter = false;
                else if (ch == '|' && !inParameter)
                {
                    if (Parameters.SingleOrDefault(p => p.Name == parameterName).ValueType == ValueTypes.Number)
                        parameters.Add(parameterName, parameterValue.GetDouble());
                    else
                        parameters.Add(parameterName, parameterValue.ToString());
                    parameterName = string.Empty;
                    parameterValue = string.Empty;
                }
                else if (inParameter)
                    parameterName += ch;
                else
                    parameterValue += ch;
            }
            parameters.Add(parameterName, parameterValue.GetDouble());

            foreach (var parameter in Parameters.Where(p => (p.Context & ParameterOptions.StaticData) != 0))
            {
                parameters.Add(parameter.Name, parameter.Value);
            }

            foreach (var parameter in Parameters.Where(p=>(p.Context & ParameterOptions.Editable) != 0))
            {
                parameter.Value = parameters.SingleOrDefault(p => p.Key == parameter.Name).Value;
            }

            foreach (var parameter in Parameters.Where(p =>
                (p.Context & ParameterOptions.Calculation) != 0))
            {
                var expressionEvaluator = ExpressionEvaluator.Create(parameter.Value.ToString(), parameters);

                try
                {
                    parameter.Value = expressionEvaluator.Evaluate();
                }
                catch (ArgumentException ex)
                {
                    parameter.Value = ex.Message;
                }
                parameters.Add(parameter.Name, parameter.Value);
            }
        }

        public void Calculate(params object[] values)
        {
            var parameters = PrepareDataParameters(values).ToList();

            foreach (var parameter in Parameters.Where(p =>
            (p.Context & ParameterOptions.Calculation) != 0))
            {
                var expressionEvaluator = ExpressionEvaluator.Create(parameter.Value.ToString(), parameters);

                parameter.Value = expressionEvaluator.Evaluate();
                parameters.Add(parameter);
            }
        }

        public void Save(ISave save, string path)
        {
            var scriptToSave = new DataSaver.SerializableClasses.Script(this);

            save.SaveData(scriptToSave, path);
        }

        private IEnumerable<IParameter> PrepareDataParameters(object[] values)
        {
            int i = 0;
            foreach (var parameter in Parameters.Where(p
                => (p.Context & ParameterOptions.Calculation) == 0))
            {
                if ((parameter.Context & ParameterOptions.StaticData) == 0)
                    parameter.Value = values[i++];
                yield return parameter;
            }
        }

        public IParameter GetParameterByName(string name)
            => Parameters.FirstOrDefault(p => p.Name == name);
    }
}
