using Build_IT_ScriptInterpreter.Expressions.Functions.Interfaces;
using NCalc;
using System;

namespace Build_IT_ScriptInterpreter.Expressions.Functions
{
    public class SetFunction : IFunction
    {
        #region Properties

        public string Name { get; private set; }

        public Func<FunctionArgs, object> Function { get; private set; }

        #endregion // Properties

        #region Constructors

        public SetFunction()
        {
            Set();
        }

        #endregion // Constructors

        #region Private_Methods

        private void Set()
        {
            Name = "SET";
            Function = (e) =>
            {
                var parameters = e.Parameters[0].Parameters;
                for (int i = 0; i < Convert.ToInt32(e.Parameters[0].Evaluate()) * 2; i += 2)
                {
                    var parameterName = e.Parameters[i + 1].ParsedExpression.ToString();
                    parameterName = parameterName.Substring(1, parameterName.Length - 2);
                    if (parameters.ContainsKey(parameterName))
                        parameters[parameterName] = e.Parameters[i + 2].Evaluate();
                    else
                        parameters.Add(parameterName, e.Parameters[i + 2].Evaluate());
                }
                return true;
            };
        }

        #endregion // Private_Methods         
    }
}
