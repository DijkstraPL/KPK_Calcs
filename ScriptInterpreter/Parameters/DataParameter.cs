using Build_IT_ScriptInterpreter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.Parameters
{
    public class DataParameter : Parameter
    {
        public override ParameterOptions Context => ParameterOptions.Editable | ParameterOptions.Visible;

        public DataParameter(string name) : base(name)
        {
        }
    }
}
