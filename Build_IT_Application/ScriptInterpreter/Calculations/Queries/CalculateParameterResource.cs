using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.ValueOptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Build_IT_Application.ScriptInterpreter.Calculations.Queries
{
    public class CalculateParameterResource
    {
        #region Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public ValueTypes ValueType { get; set; }
        public string Value { get; set; }
        public string VisibilityValidator { get; set; }
        public string DataValidator { get; set; }
        public string Unit { get; set; }
        public ParameterOptions Context { get; set; }
        public CalculateGroupResource Group { get; set; }

        public string Equation { get; set; }

        #endregion // Properties
    }
}
