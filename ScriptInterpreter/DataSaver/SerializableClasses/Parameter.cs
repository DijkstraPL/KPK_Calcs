using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using System.Collections.Generic;

namespace Build_IT_ScriptInterpreter.DataSaver.SerializableClasses
{
    public class Parameter
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public ValueTypes ValueType { get; set; }
        public object Value { get; set; }
        public object DataValidator { get; set; }
        public string Unit { get; set; }
        public List<ValueOption> ValueOptions { get; set; }
        public virtual ParameterOptions Context { get; set; }
        public string GroupName { get; set; }

        public Parameter()
        {
        }

        public Parameter(IParameter parameter)
        {
            Number = parameter.Number;
            Name = parameter.Name;
            Value = parameter.Value;
            Unit = parameter.Unit;
            Context = parameter.Context;
            ValueType = parameter.ValueType;
            ValueOptions = new List<ValueOption>();
            if (parameter.ValueOptions != null)
                foreach (var valueOption in parameter.ValueOptions)
                    ValueOptions.Add(new ValueOption(valueOption));
        }
    }
}
