using Build_IT_ScriptInterpreter.Expressions.Functions.Interfaces;
using Build_IT_ScriptInterpreter.Expressions.Interfaces;
using Build_IT_ScriptInterpreter.Expressions.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using NCalc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Build_IT_ScriptInterpreter.Expressions
{
    public class ExpressionEvaluator : IExpressionEvaluator
    {
        public ICollection<string> Functions { get; private set; }

        private readonly IExpression _expression;

        public static ExpressionEvaluator Create(
            string expression, IDictionary<string, object> parameters = null)
            => new ExpressionEvaluator(expression, parameters);

        public static ExpressionEvaluator Create(
            string expression, IEnumerable<IParameter> parameters)
        {
            var parametersDict = new Dictionary<string, object>();
            parametersDict = parameters.ToDictionary(p => p.Name, p => (object)p.Value);
            return new ExpressionEvaluator(expression, parametersDict);
        }

        private ExpressionEvaluator(string expression, IDictionary<string, object> parameters = null)
        {
            Functions = new List<string>();            
            _expression = new ExpressionWrapper(expression);

            SetAdditionalParameters(parameters);
            if (parameters != null)
                _expression.SetParameters(parameters);

            SetAdditionalFunctions();
        }

        public object Evaluate()
        {
            try
            {
                return _expression.Evaluate();
            }
            catch (EvaluationException ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
        }

        private IDictionary<string, object> SetAdditionalParameters(
            IDictionary<string, object> parameters)
        {
            if (parameters == null)
                parameters = new Dictionary<string, object>();

            var type = typeof(ICustomParameter);
            var customParameters = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);
            foreach (var customParameter in customParameters)
            {
                var instance = (ICustomParameter)Activator.CreateInstance(customParameter);
                foreach (var name in instance.Names)
                    if (!parameters.ContainsKey(name))
                        parameters.Add(name, instance.Value);
            }

            return parameters;
        }

        private void SetAdditionalFunctions()
        {
            var type = typeof(IFunction);
            var functions = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);
            foreach (var function in functions)
            {
                var instance = (IFunction)Activator.CreateInstance(function);
                _expression.SetAdditionalFunction(instance.Name, instance.Function);
                Functions.Add(instance.Name);
            }
        }
    }
}
