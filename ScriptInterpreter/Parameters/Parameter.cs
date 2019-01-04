using Build_IT_ScriptInterpreter.Expressions;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Units.Interfaces;
using System;
using System.Collections.Generic;

namespace Build_IT_ScriptInterpreter.Parameters
{
    public class Parameter : IParameter
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public ValueTypes ValueType { get; set; }
        public object Value { get; set; }
        public object DataValidator { get; set; }
        public string Unit { get; set; }
        public IList<IValueOption> ValueOptions { get; set; }
        public virtual ParameterOptions Context { get; set; }
        public string GroupName { get; set; }

        public int Compare(IParameter x, IParameter y)
        {
            if (x.Number.CompareTo(y.Number) != 0)
                return x.Number.CompareTo(y.Number);
            else
                return 0;
        }

        public int CompareTo(IParameter other)
        {
            if (other == null)
                return 1;
            return this.Number.CompareTo(other.Number);
        }

        public override string ToString() 
            => Value.ToString() + Unit;
    }
}
