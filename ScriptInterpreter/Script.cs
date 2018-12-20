using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using System;
using System.Collections.Generic;

namespace Build_IT_ScriptInterpreter
{
    public class Script
    {
        public string Name { get; }
        public string Decription { get; }
        public IEnumerable<string> Tags { get; set; }

        public IEnumerable<IParameter> DataParameters { get; }

        public Script(string name, string decription)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Decription = decription ?? throw new ArgumentNullException(nameof(decription));
        }
    }
}
