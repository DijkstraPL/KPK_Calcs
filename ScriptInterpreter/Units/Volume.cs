using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.Units
{
    public class Volume : Unit
    {
        public Volume(VolumeUnits currentUnit = VolumeUnits.m3) : base(currentUnit)
        {
            DefaultUnit = VolumeUnits.m3;
        }

        protected override void SetUnits()
        {
            UnitMultiplerPairs.Add(VolumeUnits.mm3, 0.000000001);
            UnitMultiplerPairs.Add(VolumeUnits.cm3, 0.000001);
            UnitMultiplerPairs.Add(VolumeUnits.m3, 1);
        }

        public enum VolumeUnits
        {
            mm3,
            cm3,
            m3
        }
    }
}
