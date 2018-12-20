using Build_IT_ScriptInterpreter.Expressions;
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
        public object Value { get; set; }
        public object DataValidator { get; set; }
        public string Unit { get; set; }
        public IList<IValueOption> ValueOptions { get; set; }
        public virtual ParameterOptions Context { get; set; }
        public string GroupName { get; set; }

        public Parameter(int number, string name)
        {
            Number = number;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        //public virtual void ChangeUnitTo(Enum newUnit)
        //{
        //    if (ValueType != ValueTypes.Number)
        //        return;

        //    double currentMultipler = Unit.CurrentUnitMultipler;
        //    if (Unit.TryChangeUnit(newUnit))
        //    {
        //        ChangeValue(currentMultipler);
        //        ChangeValuesForValueOptions(currentMultipler);
        //    }
        //}

        //private void ChangeValue(double currentMultipler)
        //{
        //    double value;
        //    if (Double.TryParse(Value?.ToString(), out value))
        //        Value = (value / Unit.CurrentUnitMultipler * currentMultipler).ToString();
        //}

        //private void ChangeValuesForValueOptions(double currentMultipler)
        //{
        //    if (ValueOptions == null || ValueOptions.Count == 0)
        //        return;
        //    var newValueOptions = new List<IValueOption>();
        //    foreach (var valueOption in ValueOptions)
        //    {
        //        double currentValue;

        //        if (Double.TryParse(valueOption.Value.ToString(), out currentValue))
        //            newValueOptions.Add(new ValueOption(
        //                value: (currentValue / Unit.CurrentUnitMultipler * currentMultipler),
        //                description: valueOption.Description));
        //    }
        //    ValueOptions = newValueOptions;
        //}
    }
}
