using Build_IT_ScriptInterpreter.Expressions.Functions.Interfaces;
using NCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Build_IT_ScriptInterpreter.Expressions.Functions
{
    public class ValidateFunction : IFunction
    {
        public string Name { get; private set; }
        public Func<FunctionArgs, object> Function { get; private set; }
        
        public ValidateFunction()
        {
            SetFunction();
        }

        private void SetFunction()
        {
            Name = "VALIDATE";
            Function = (e) =>
            {
                return e.Parameters[0].Evaluate();
            };
        }
    }
}
