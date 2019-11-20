using Build_IT_ScriptInterpreter.Expressions.Functions.Interfaces;
using NCalc;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Globalization;
using System.Text;

namespace Build_IT_ScriptInterpreter.Expressions.Functions
{
    [Export(typeof(IFunction))]
    public class AbsFunction : IFunction
    {
        #region Properties

        public string Name { get; private set; }
        public Func<FunctionArgs, object> Function { get; private set; }

        #endregion // Properties

        #region Constructors

        public AbsFunction()
        {
            SetFunction();
        }

        #endregion // Constructors

        #region Private_Methods

        private void SetFunction()
        {
            Name = "ABS";
            Function = (e) =>
            {
                var value = e.Parameters[0].Evaluate().ToString().Replace(',', '.');
                return Math.Abs(Convert.ToDouble(value, CultureInfo.InvariantCulture));
            };
        }

        #endregion // Private_Methods
    }
}
