using Build_IT_ScriptInterpreter;
using Build_IT_ScriptInterpreter.Units.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.Parameters
{
    public class DataParameter : Parameter
    {
        public override ParameterOptions Context => ParameterOptions.Editable | ParameterOptions.Visible;

        public DataParameter(int number, string name) 
            : base(number, name )
        {
        }
    }
}
