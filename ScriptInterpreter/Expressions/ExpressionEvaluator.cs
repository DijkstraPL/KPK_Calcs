using Build_IT_ScriptInterpreter.Expressions.Interfaces;
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

        private void SetAdditionalFunctions()
        {
            SetErrorFunction();
            SetMaxxFunction();
            SetMinnFunction();
        }

        private void SetErrorFunction()
        {
            string name = "ERROR";
            Func<FunctionArgs, object> function = (e) =>
            {
                throw new ArgumentException(e.Parameters[0].Evaluate().ToString());
            };
            _expression.SetAdditionalFunction(name, function);
            Functions.Add(name);
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
