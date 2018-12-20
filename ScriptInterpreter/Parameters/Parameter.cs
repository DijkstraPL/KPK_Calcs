using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Units.Interfaces;
using System;
using System.Collections.Generic;

namespace Build_IT_ScriptInterpreter.Parameters
{
    public class Parameter : IParameter
    {
        public string Name { get; }
        public int Number { get; }
        public string Description { get; set; }
        public ValueTypes ValueType { get; set; }
        public string Value { get; set; }
        public IUnit Unit { get; set; }
        public IList<string> ValueOptions { get; set; }
        public virtual ParameterOptions Context { get; set; }
        public string GroupName { get; set; }

        public Parameter(int number, string name)
        {
            Number = number;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public Parameter(int number, string name, string value,
            IUnit unit, ValueTypes valueType) : this(number, name)
        {           
            Value = value;
            Unit = unit;
            ValueType = valueType;
        }

        public virtual void ChangeUnitTo(Enum newUnit)
        {
            if (ValueType != ValueTypes.Number)
                return;

            double currentMultipler = Unit.CurrentUnitMultipler;
            if (Unit.TryChangeUnit(newUnit))
            {
                ChangeValue(currentMultipler);
                ChangeValuesForValueOptions(currentMultipler);
            }
        }

        private void ChangeValue(double currentMultipler)
        {
            double value;
            if (Double.TryParse(Value, out value))
                Value = (value / Unit.CurrentUnitMultipler * currentMultipler).ToString();
        }

        private void ChangeValuesForValueOptions(double currentMultipler)
        {
            if (ValueOptions == null || ValueOptions.Count == 0)
                return;
            var newValueOptions = new List<string>();
            foreach (var value in ValueOptions)
            {
                double currentValue;

                if (Double.TryParse(value, out currentValue))
                    newValueOptions.Add(
                        (currentValue / Unit.CurrentUnitMultipler * currentMultipler)
                        .ToString());
            }
            ValueOptions = newValueOptions;
        }
    }
}
