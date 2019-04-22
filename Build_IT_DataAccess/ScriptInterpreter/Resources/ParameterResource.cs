using Build_IT_DataAccess.ScriptInterpreter.Models.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Build_IT_DataAccess.ScriptInterpreter.Resources
{
    public class ParameterResource
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public ValueTypes ValueType { get; set; }
        public string Value { get; set; }
        public string VisibilityValidator { get; set; }
        public string DataValidator { get; set; }
        public string Unit { get; set; }
        public ICollection<ValueOptionResource> ValueOptions { get; set; }
        public ValueOptionSettings ValueOptionSetting { get; set; }
        public ParameterOptions Context { get; set; }
        public string GroupName { get; set; }
        public string AccordingTo { get; set; }
        public string Notes { get; set; }
        public ICollection<AlternativeScriptResource> NestedScripts { get; set; }

        public string Equation { get; set; }

        public ParameterResource()
        {
            ValueOptions = new Collection<ValueOptionResource>();
            NestedScripts = new Collection<AlternativeScriptResource>();
        }
    }
}