using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.Units
{
    [Obsolete]
    public class Area : Unit
    {
        public Area(AreaUnits currentUnit = AreaUnits.m2) : base(currentUnit)
        {
            DefaultUnit = AreaUnits.m2;
        }

        protected override void SetUnits()
        {
            UnitMultiplerPairs.Add(AreaUnits.mm2, 0.000001);
            UnitMultiplerPairs.Add(AreaUnits.cm2, 0.0001);
            UnitMultiplerPairs.Add(AreaUnits.m2, 1);
        }

        public enum AreaUnits
        {
            mm2,
            cm2,
            m2
        }
    }
}
