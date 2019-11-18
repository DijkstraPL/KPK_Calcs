using Build_IT_ScriptInterpreter.Expressions;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Parameters.ValueOptions;
using Build_IT_ScriptInterpreter.Scripts;
using Build_IT_ScriptInterpreter.Units.Interfaces;
using System;
using System.Collections.Generic;

namespace Build_IT_ScriptInterpreter.Parameters
{
    public class Parameter : IParameter
    {
        #region Properties

        public string Name { get; set; }
        public int Number { get; set; }
        public ValueTypes ValueType { get; set; }
        public object Value { get; set; }
        public object VisibilityValidator { get; set; }
        public object DataValidator { get; set; }
        public string Unit { get; set; }
        public List<ValueOption> ValueOptions { get; set; }
        public ParameterOptions Context { get; set; }
        public IGroup Group { get; set; }

        #endregion // Properties

        #region Constructors

        public Parameter()
        {
        }

        #endregion // Constructors

        #region Public_Methods

        public int Compare(IParameter x, IParameter y)
        {
            return x.Number.CompareTo(y.Number);
        }

        public int CompareTo(IParameter other)
        {
            if (other == null)
                return 1;
            return this.Number.CompareTo(other.Number);
        }

        public override string ToString() 
            => Value.ToString() + Unit;

        #endregion // Public_Methods
    }
}
