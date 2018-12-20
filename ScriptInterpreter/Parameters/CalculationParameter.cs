using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.Parameters
{
    public class CalculationParameter : Parameter
    {
        public override ParameterOptions Context => ParameterOptions.Calculation | ParameterOptions.Visible;

        public CalculationParameter(string name) : base(name)
        {
        }
    }
}
