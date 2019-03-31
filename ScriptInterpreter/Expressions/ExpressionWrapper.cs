using Build_IT_ScriptInterpreter.Expressions.Interfaces;
using NCalc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Build_IT_ScriptInterpreter.Expressions
{
    public class ExpressionWrapper : IExpression
    {
        #region Fields

        private readonly Expression _original;

        #endregion // Fields

        #region Constructors
        
        public ExpressionWrapper(string expression)
        {
            _original = new Expression(expression, EvaluateOptions.IgnoreCase);
        }

        #endregion // Constructors

        #region Public_Methods

        public void SetParameters(IDictionary<string, object> parameters)
        {
            _original.Parameters = parameters as Dictionary<string, object>;// new Dictionary<string, object>(parameters);
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

        #endregion // Public_Methods
    }
}
