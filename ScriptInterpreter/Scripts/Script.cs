using Build_IT_ScriptInterpreter.DataSaver.Interfaces;
using Build_IT_ScriptInterpreter.Expressions;
using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Build_IT_ScriptInterpreter.Scripts
{
    public class Script
    {
        public string Name { get; }
        public string Description { get; }
        public ICollection<string> Tags { get; set; }

        public ICollection<KeyValuePair<int, IParameter>> Parameters { get; }

        public Script(string name, string description, params string[] tags)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Tags = new List<string>(tags);
            Parameters = new SortedList<int, IParameter>();
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
                    continue;
                else if (ch == '[')
                    inParameter = true;
                else if (ch == ']')
                    inParameter = false;
                else if (ch == ',' && !inParameter)
                {
                    parameters.Add(parameterName, Convert.ToDouble(parameterValue));
                    parameterName = string.Empty;
                    parameterValue = string.Empty;
                }
                else if (inParameter)
                    parameterName += ch;
                else
                    parameterValue += ch;
            }
            parameters.Add(parameterName, Convert.ToDouble(parameterValue));

            foreach (var parameter in Parameters.Where(p=>(p.Value.Context & ParameterOptions.StaticData) != 0))
            {
                parameters.Add(parameter.Value.Name, parameter.Value.Value);
            }

            foreach (var parameter in Parameters.Where(p =>
                (p.Value.Context & ParameterOptions.Calculation) != 0))
            {
                var expressionEvaluator = ExpressionEvaluator.Create(parameter.Value.Value.ToString(), parameters);

                parameter.Value.Value = expressionEvaluator.Evaluate();
                parameters.Add(parameter.Value.Name, parameter.Value.Value);
            }
        }

        public void Calculate(params object[] values)
        {
            var parameters = PrepareDataParameters(values).ToList();

            foreach (var parameter in Parameters.Where(p =>
            (p.Value.Context & ParameterOptions.Calculation) != 0))
            {
                var expressionEvaluator = ExpressionEvaluator.Create(parameter.Value.Value.ToString(), parameters);

                parameter.Value.Value = expressionEvaluator.Evaluate();
                parameters.Add(parameter.Value);
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
                => (p.Value.Context & ParameterOptions.Calculation) == 0))
            {
                if ((parameter.Value.Context & ParameterOptions.StaticData) == 0)
                    parameter.Value.Value = values[i++];
                yield return parameter.Value;
            }
        }

        public IParameter GetParameterByName(string name)
            => Parameters.FirstOrDefault(p => p.Value.Name == name).Value;
    }
}
