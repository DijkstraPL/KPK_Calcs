using Build_IT_ScriptInterpreter.Units.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.Parameters
{
    public class StaticDataParameter : Parameter
    {
        public override ParameterOptions Context => ParameterOptions.StaticData;

        public StaticDataParameter(int number, string name, object value) : base(number, name)
        {
            Value = value;
        }
    }
}
