using Build_IT_ScriptInterpreter.Expressions.Parameters.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.Expressions.Parameters
{
    public class EParameter : ICustomParameter<double>
    {
        #region Properties

        public string[] Names { get; } = { "e" };
        public double Value { get; } = Math.E;
        
        object ICustomParameter.Value => Value;

        #endregion // Properties
    }
}
