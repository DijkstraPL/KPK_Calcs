using Build_IT_ScriptInterpreter.Parameters.ValueOptions;

namespace Build_IT_ScriptInterpreter.Parameters.Interfaces
{
    public interface IValueOption
    {
        #region Properties

        object Value { get; }
        ValueOptionSettings ValueOptionSetting { get;  }

        #endregion // Properties
    }
}
