using System;
using System.Collections.Generic;

namespace ScriptInterpreter
{
    public class Script
    {
        public string Name { get; }
        public string Decription { get; }
        public IEnumerable<string> Tags { get; set; }

        public Script(string name, string decription)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Decription = decription ?? throw new ArgumentNullException(nameof(decription));
        }
    }
}
