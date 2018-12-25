using Build_IT_ScriptInterpreter.Expressions.Functions.Interfaces;
using NCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Build_IT_ScriptInterpreter.Expressions.Functions
{
    public class MinnFunction : IFunction
    {
        public string Name { get; private set; }
        public Func<FunctionArgs, object> Function { get; private set; }
        
        public MinnFunction()
        {
            SetFunction();
        }

        private void SetFunction()
        {
            Name = "MINN";
            Function = (e) =>
            {
                return e.Parameters.Select(p => p.Evaluate()).Min();
            };
        }
    }
}
