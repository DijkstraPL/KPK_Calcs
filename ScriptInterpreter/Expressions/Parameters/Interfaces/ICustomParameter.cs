using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.Expressions.Parameters.Interfaces
{
    public interface ICustomParameter
    {
        string[] Names { get; }
        object Value { get; }
    }
}
