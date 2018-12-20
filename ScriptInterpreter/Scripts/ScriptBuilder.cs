using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.Scripts
{
    public class ScriptBuilder : Script
    {
        public ScriptBuilder(string name, string description, params string[] tags) : base(name, description, tags)
        {
        }
        
        public ScriptBuilder AppendTag(string tag)
        {
            Tags.Add(tag);
            return this;
        }

        public ScriptBuilder AppendTags(IEnumerable<string> tags)
        {
            foreach (var tag in tags)
                Tags.Add(tag);
            return this;
        }

        public ScriptBuilder AppendParameter(IParameter parameter)
        {
            Parameters.Add(new KeyValuePair<int, IParameter>(parameter.Number, parameter));
            return this;
        }
    }
}
