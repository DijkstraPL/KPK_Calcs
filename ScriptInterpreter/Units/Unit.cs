using Build_IT_ScriptInterpreter.Units.Interfaces;
using System;
using System.Collections.Generic;

namespace Build_IT_ScriptInterpreter.Units
{
    public class Unit : IUnit
    {
        public IDictionary<Enum, double> UnitMultiplerPairs { get; }
        public double CurrentUnitMultipler { get; protected set; }
        public Enum CurrentUnit { get; protected set; }

        public Unit(Enum currentUnit)
        {
            UnitMultiplerPairs = new Dictionary<Enum, double>();

            SetUnits();

            CurrentUnit = currentUnit;

            if (UnitMultiplerPairs != null && UnitMultiplerPairs.Count > 0)
                CurrentUnitMultipler = UnitMultiplerPairs[currentUnit];
        }

        public bool TryChangeUnit(Enum newUnit)
        {
            try
            {
                if (!UnitMultiplerPairs.ContainsKey(newUnit))
                    throw new MissingMemberException(
                        message: nameof(UnitMultiplerPairs) + " doesn't contain " + newUnit.ToString());

                CurrentUnit = newUnit;
                CurrentUnitMultipler = UnitMultiplerPairs[newUnit];
                return true;
            }
            catch (MissingMemberException)
            {
                return false;
            }
        }

        protected virtual void SetUnits() { }
    }
}
