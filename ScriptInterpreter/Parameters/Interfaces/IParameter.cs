using Build_IT_ScriptInterpreter.Units.Interfaces;
using System.Collections.Generic;

namespace Build_IT_ScriptInterpreter.Parameters.Interfaces
{
    public interface IParameter
    {
        int Number { get; }
        string Name { get;  }
        object Value { get; set; }
        string Description { get; set; }
        IList<IValueOption> ValueOptions { get; set; }
        string Unit { get; set; }
        ParameterOptions Context { get; }
        ValueTypes ValueType { get; set; }
    }
}