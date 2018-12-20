using System;

namespace Build_IT_ScriptInterpreter.Parameters
{
    [Flags]
    public enum ParameterOptions
    {
        Visible = 1,
        Editable = 2,
        Calculation = 4
    }
}
