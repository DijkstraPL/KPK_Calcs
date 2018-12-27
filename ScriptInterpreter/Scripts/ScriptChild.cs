using Build_IT_ScriptInterpreter.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.Scripts
{
    public class ScriptChild
    {
        public string  Name { get; set; }
        public List<Parameter> ParametersMapping { get; set; }
    }
}
