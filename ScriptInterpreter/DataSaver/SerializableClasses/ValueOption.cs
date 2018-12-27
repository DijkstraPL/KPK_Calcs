using System;
using System.Collections.Generic;
using System.Text;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;

namespace Build_IT_ScriptInterpreter.DataSaver.SerializableClasses
{
    [Serializable]
    public class ValueOption
    {
        public ValueOption()
        {
        }

        public ValueOption(IValueOption valueOption)
        {
            Value = valueOption.Value;
            Description = valueOption.Description;
        }

        public object Value { get; set; }
        public string Description { get; set; }
    }
}
