﻿using Build_IT_ScriptInterpreter.Expressions;
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
        public string Description { get; set; }
        public ValueTypes ValueType { get; set; }
        public object Value { get; set; }
        public object VisibilityValidator { get; set; }
        public object DataValidator { get; set; }
        public string Unit { get; set; }
        public List<ValueOption> ValueOptions { get; set; }
        public virtual ParameterOptions Context { get; set; }
        public string GroupName { get; set; }
        public string AccordingTo { get; set; }
        public string Notes { get; set; }
        public List<Script> Scripts { get; set; }

        #endregion // Properties

        #region Constructors

        public Parameter()
        {
        }

        #endregion // Constructors

        #region Public_Methods

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

        #endregion // Public_Methods
    }
}