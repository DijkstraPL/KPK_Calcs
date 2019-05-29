using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.Units
{
    [Obsolete]
    public class Mass : Unit
    {
        public Mass(MassUnits currentUnit) : base(currentUnit)
        {
        }

        protected override void SetUnits()
        {
            UnitMultiplerPairs.Add(MassUnits.kg, 1);
            UnitMultiplerPairs.Add(MassUnits.t, 1000);
        }

        public enum MassUnits
        {
            kg, 
            t 
        }
    }
}
