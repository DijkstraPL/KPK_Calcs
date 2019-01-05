using Build_IT_ScriptInterpreter.Parameters.ValueOptions;

namespace Build_IT_ScriptInterpreter.Parameters.Interfaces
{
    public interface IValueOption
    {
        object Value { get; }
       string  Description { get; }
        ValueOptionSettings ValueOptionSetting { get;  }
    }
}
