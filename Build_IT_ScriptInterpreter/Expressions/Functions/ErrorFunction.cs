using Build_IT_ScriptInterpreter.Expressions.Functions.Interfaces;
using NCalc;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;

namespace Build_IT_ScriptInterpreter.Expressions.Functions
{
    [Export(typeof(IFunction))]
    public class ErrorFunction : IFunction
    {
        #region Properties

        public string Name { get; private set; }
        public Func<FunctionArgs, object> Function { get; private set; }

        #endregion // Properties

        #region Constructors

        public ErrorFunction()
        {
            SetFunction();
        }

        #endregion // Constructors

        #region Private_Methods
        
        private void SetFunction()
        {
            Name = "ERROR";
            Function = (e) =>
            {
                if(e.Parameters.Count() != 1 )
                    throw new ArgumentException("Wrong number of parameters.");
                throw new ArgumentException(e.Parameters[0].Evaluate().ToString());
            };
        }

        #endregion // Private_Methods
    }
}
