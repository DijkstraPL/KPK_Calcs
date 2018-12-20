using Build_IT_ScriptInterpreter.Units.Interfaces;
using System;
using System.Collections.Generic;

namespace Build_IT_ScriptInterpreter.Units
{
    public abstract class Unit : IUnit
    {
        public IDictionary<Enum, double> UnitMultiplerPairs { get; }
        public double CurrentUnitMultipler { get; protected set; }
        public Enum CurrentUnit { get; protected set; }

        public Unit(Enum currentUnit)
        {
            UnitMultiplerPairs = new Dictionary<Enum, double>();

            SetUnits();

            CurrentUnit = currentUnit;
            CurrentUnitMultipler = UnitMultiplerPairs[currentUnit];
        }

        public bool TryChangeUnit(Enum newUnit)
        {
            if (!UnitMultiplerPairs.ContainsKey(newUnit))
                return false;

            CurrentUnit = newUnit;
            CurrentUnitMultipler = UnitMultiplerPairs[newUnit];
            return true;
        }

        protected abstract void SetUnits();
    }
}
