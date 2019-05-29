using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.Units.Interfaces
{
    [Obsolete]
    public interface IUnit
    {
        double CurrentUnitMultipler { get; }
        Enum CurrentUnit { get; }

        bool TryChangeUnit(Enum newUnit);
    }
}
