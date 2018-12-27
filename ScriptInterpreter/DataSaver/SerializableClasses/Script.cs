using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Scripts;

namespace Build_IT_ScriptInterpreter.DataSaver.SerializableClasses
{
    [Serializable]
    public class Script
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public string GroupName { get; set; }

        public List<Parameter> Parameters { get; set; }

        public Script()
        {
        }

        public Script(Scripts.Script script)
        {
            Name = script.Name;
            Description = script.Description;
            Tags = new List<string>(script.Tags);
            GroupName = script.GroupName;
            Parameters = new List<Parameter>();
          
            foreach (var parameter in script.Parameters)
                this.Parameters.Add(new Parameter(parameter.Value));
        }

        public Scripts.Script Initialize()
        {
            var script = new Scripts.Script(Name, Description)
            {
                Tags = new List<string>(Tags),
            };

            foreach (var parameter in Parameters)
            {
                script.Parameters.Add(
                    new KeyValuePair<int, Parameters.Interfaces.IParameter>(
                        parameter.Number,
                        new Parameters.Parameter()
                        {
                            Number = parameter.Number,
                            Name = parameter.Name,
                            Description = parameter.Description,
                            Value = parameter.Value,
                            Context = parameter.Context,
                            ValueType = parameter.ValueType,
                            Unit = parameter.Unit,
                            ValueOptions = new List<IValueOption>()
                        }));

                foreach (var valueOption in parameter.ValueOptions)
                    script.Parameters.SingleOrDefault(p =>
                    p.Value.Name == parameter.Name).Value.ValueOptions.Add(new Parameters.ValueOption(
                        value: valueOption.Value,
                        description: valueOption.Description
                    ));
            }
            return script;
        }
    }
}
