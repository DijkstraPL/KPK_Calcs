using AutoMapper;
using Build_IT_ScriptInterpreter.DataSaver;
using Build_IT_ScriptInterpreter.DataSaver.Interfaces;
using Build_IT_ScriptInterpreter.Expressions;
using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Build_IT_ScriptInterpreterTests")]
namespace Build_IT_ScriptInterpreter.Scripts
{
    public class Script : IScript
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public string GroupName { get; set; }
        public string Author { get; set; }
        public DateTime Added { get; set; }
        public DateTime Modified { get; set; }
        public string AccordingTo { get; set; }
        public string Notes { get; set; }

        public List<Parameter> Parameters { get; set; } = new List<Parameter>();

        internal Script()
        {
        }             
        
        public IParameter GetParameterByName(string name)
            => Parameters.FirstOrDefault(p => p.Name == name);
    }
}
