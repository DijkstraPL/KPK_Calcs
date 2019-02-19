using Build_IT_ScriptInterpreter.Expressions.Parameters.Interfaces;
using System;

namespace Build_IT_ScriptInterpreter.Expressions.Parameters
{
    public class PiParameter : ICustomParameter
    {
        public string[] Names { get; } = { "π", "Pi" };
        public object Value { get; } = Math.PI;
    }
}
