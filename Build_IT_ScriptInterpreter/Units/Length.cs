using System;
using System.Collections.Generic;
using System.Text;
using static Build_IT_ScriptInterpreter.Units.Area;
using static Build_IT_ScriptInterpreter.Units.Volume;

namespace Build_IT_ScriptInterpreter.Units
{
    [Obsolete]
    public class Length : Unit
    {
        public Length(LengthUnits currentUnit = LengthUnits.m) : base(currentUnit)
        {
            DefaultUnit = LengthUnits.m;
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
               
        //public static Area operator *(Length length1, Length length2)
        //{
        //    var area = new Area();
        //    area.Value = Multiply(length1, length2);
        //    return area;
        //}

        //private static double Multiply(Unit unit1, Unit unit2)
        //{
        //    return unit1.Value * unit1.CurrentUnitMultipler / unit1.UnitMultiplerPairs[unit1.DefaultUnit]
        //          * unit2.Value * unit2.CurrentUnitMultipler / unit2.UnitMultiplerPairs[unit2.DefaultUnit];
        //}

        //public static Volume operator *( Area area, Length length)
        //{
        //    var volume = new Volume();
        //    volume.Value = Multiply(area, length);
        //    return volume;
        //}

        //public static Volume operator *(Length length, Area area)
        //{
        //    var volume = new Volume();
        //    volume.Value = Multiply(area, length);
        //    return volume;
        //}
    }
}
