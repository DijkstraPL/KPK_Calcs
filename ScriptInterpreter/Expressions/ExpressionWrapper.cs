using Build_IT_ScriptInterpreter.Expressions.Interfaces;
using NCalc;
using System;
using System.Collections.Generic;

namespace Build_IT_ScriptInterpreter.Expressions
{
    public class ExpressionWrapper : IExpression
    {
        private readonly Expression _original;

        public ExpressionWrapper(string expression)
        {
            _original = new Expression(expression, EvaluateOptions.IgnoreCase);
        }

        public void SetParameters(IDictionary<string, object> parameters)
        {
            _original.Parameters = new Dictionary<string, object>(parameters);
        }

        public object Evaluate() => _original.Evaluate();

        public void SetAdditionalFunction(string fuctionName, Func<FunctionArgs, object> function)
        {
            _original.EvaluateFunction += delegate (string name, FunctionArgs args)
            {
                if (name == fuctionName.ToLower())
                    args.Result = function.Invoke(args);
            };
        }
    }
}
