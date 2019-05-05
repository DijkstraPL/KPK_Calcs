using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.Units
{
    public class Pressure : Unit
    {
        public Pressure(PressureUnits currentUnit) : base(currentUnit)
        {
        }

        protected override void SetUnits()
        {
            UnitMultiplerPairs.Add(PressureUnits.kPa, 1000);
            UnitMultiplerPairs.Add(PressureUnits.MPa, 1000000);
        }

        public enum PressureUnits
        {
            kPa,
            MPa,
        }
    }
}
