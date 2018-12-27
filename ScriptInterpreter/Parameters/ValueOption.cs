using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using System;

namespace Build_IT_ScriptInterpreter.Parameters
{
    public class ValueOption : IValueOption
    {
        public object Value { get; set; }
        public string Description { get; set; }

        public ValueOption(object value, string description = null)
        {
            Value = value;
            Description = description;
        }
    }
}
