using Build_IT_ScriptInterpreter.Expressions.Interfaces;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using NCalc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Build_IT_ScriptInterpreter.Expressions
{
    public class ExpressionEvaluator
    {
        public ICollection<string> Functions { get; private set; }

        private readonly IExpression _expression;

        public static ExpressionEvaluator Create(
            string expression, IDictionary<string, object> parameters = null)
            => new ExpressionEvaluator(expression, parameters);

        public static ExpressionEvaluator Create(
            string expression, IEnumerable<IParameter> parameters = null)
        {
            var parametersDict = new Dictionary<string, object>();
            parametersDict = parameters.ToDictionary(p => p.Name, p => (object)p.Value);
            return new ExpressionEvaluator(expression, parametersDict);
        }

        private ExpressionEvaluator(string expression, IDictionary<string, object> parameters = null)
        {
            Functions = new List<string>();

            _expression = new ExpressionWrapper(expression);
            if (parameters != null)
                _expression.SetParameters(parameters);

            SetAdditionalFunctions();
        }
        public object Evaluate()
            => _expression.Evaluate();

        private void SetAdditionalFunctions()
        {
            SetMaxxFunction();
            SetMinnFunction();
        }

        private void SetMaxxFunction()
        {
            string name = "MAXX";
            Func<FunctionArgs, object> function = (e) =>
            {
                return e.Parameters.Select(p => p.Evaluate()).Max();
            };
            _expression.SetAdditionalFunction(name, function);
            Functions.Add(name);
        }

        private void SetMinnFunction()
        {
            string name = "MINN";
            Func<FunctionArgs, object> function = (e) =>
            {
                return e.Parameters.Select(p => p.Evaluate()).Min();
            };
            _expression.SetAdditionalFunction(name, function);
            Functions.Add(name);
        }
    }
}
