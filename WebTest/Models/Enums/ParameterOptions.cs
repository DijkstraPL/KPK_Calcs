using System;

namespace WebTest.Models.Enums
{
    [Flags]
    public enum ParameterOptions
    {
        None = 0,
        Visible = 1,
        Editable = 2,
        Calculation = 4,
        StaticData = 8,
    }
}
