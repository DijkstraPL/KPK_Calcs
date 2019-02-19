using Build_IT_ScriptInterpreter.Expressions.Parameters.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.Expressions.Parameters
{
    public class EParameter : ICustomParameter
    {
        public string[] Names { get; } = { "e" };
        public object Value { get; } = Math.E;
    }
}
