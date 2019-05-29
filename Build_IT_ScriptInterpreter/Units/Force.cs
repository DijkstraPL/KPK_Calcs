using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.Units
{
    [Obsolete]
    public class Force : Unit
    {
        public Force(ForceUnits currentUnit) : base(currentUnit)
        {
        }

        protected override void SetUnits()
        {
            UnitMultiplerPairs.Add(ForceUnits.N, 1);
            UnitMultiplerPairs.Add(ForceUnits.kN, 1000);
            UnitMultiplerPairs.Add(ForceUnits.MN, 1000000);
        }

        public enum ForceUnits
        {
            N,
            kN,
            MN
        }
    }
}
