﻿using Build_IT_ScriptInterpreter.Parameters.Interfaces;

namespace Build_IT_ScriptInterpreter.Parameters.ValueOptions
{
    public class ValueOption : IValueOption
    {
        public object Value { get; set; }
        public string Description { get; set; }
        public ValueOptionSettings ValueOptionSetting { get; set; }

        public ValueOption(object value, string description = null, ValueOptionSettings valueOptionSetting = ValueOptionSettings.None)
        {
            Value = value;
            Description = description;
            ValueOptionSetting = valueOptionSetting;
        }

        internal ValueOption()
        {
        }
    }
}