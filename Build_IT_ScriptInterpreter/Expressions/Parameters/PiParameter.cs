using Build_IT_ScriptInterpreter.Expressions.Parameters.Interfaces;
using System;

namespace Build_IT_ScriptInterpreter.Expressions.Parameters
{
    public class PiParameter : ICustomParameter<double>
    {
        #region Properties

        public string[] Names { get; } = { "π", "Pi" };
        public double Value { get; } = Math.PI;
        
        object ICustomParameter.Value => Value;
        
        #endregion // Properties
    }
}
