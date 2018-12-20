using Build_IT_ScriptInterpreter.Units.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.Parameters
{
    public class CalculationParameter : Parameter
    {
        public override ParameterOptions Context { get; set; } 
            = ParameterOptions.Calculation | ParameterOptions.Visible;

        public CalculationParameter(int number, string name, object value) 
            : base(number, name)
        {
            Value = value;
        }               
    }
}
