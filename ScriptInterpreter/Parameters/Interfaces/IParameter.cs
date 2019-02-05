using Build_IT_ScriptInterpreter.Parameters.ValueOptions;
using Build_IT_ScriptInterpreter.Scripts;
using Build_IT_ScriptInterpreter.Units.Interfaces;
using System;
using System.Collections.Generic;

namespace Build_IT_ScriptInterpreter.Parameters.Interfaces
{
    public interface IParameter : IComparer<IParameter>, IComparable<IParameter>
    {
        int Number { get; set; }
        string Name { get; set; }
        object Value { get; set; }
        string Description { get; set; }
        List<ValueOption> ValueOptions { get; set; }
        object DataValidator { get; set; }
        string Unit { get; set; }
        ParameterOptions Context { get; }
        ValueTypes ValueType { get; set; }
        string GroupName { get; set; }
        string AccordingTo { get; set; }
        string Notes { get; set; }
        List<Script> Scripts { get; set; }
    }
}