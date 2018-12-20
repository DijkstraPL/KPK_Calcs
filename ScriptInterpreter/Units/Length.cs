using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.Units
{
    public class Length : Unit
    {
        public Length(LengthUnits currentUnit) : base(currentUnit)
        {
        }

        protected override void SetUnits()
        {
            UnitMultiplerPairs.Add(LengthUnits.mm, 0.001);
            UnitMultiplerPairs.Add(LengthUnits.cm, 0.01);
            UnitMultiplerPairs.Add(LengthUnits.m, 1);
        }

        public enum LengthUnits
        {
            mm,
            cm,
            m 
        }
    }
}
