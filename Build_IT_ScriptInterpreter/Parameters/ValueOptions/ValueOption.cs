using Build_IT_ScriptInterpreter.Parameters.Interfaces;

namespace Build_IT_ScriptInterpreter.Parameters.ValueOptions
{
    public class ValueOption : IValueOption
    {
        #region Properties

        public object Value { get; set; }
        public ValueOptionSettings ValueOptionSetting { get; set; }

        #endregion // Properties

        #region Constructors
        
        public ValueOption(object value, ValueOptionSettings valueOptionSetting = ValueOptionSettings.None)
        {
            Value = value;
            ValueOptionSetting = valueOptionSetting;
        }

        internal ValueOption()
        {
        }

        #endregion // Constructors
    }
}
