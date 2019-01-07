using System.Collections.Generic;
using WebTest.Models.Enums;

namespace WebTest.Controllers.Resources
{
    public class ParameterResource
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public ValueTypes ValueType { get; set; }
        public string Value { get; set; }
        public string DataValidator { get; set; }
        public string Unit { get; set; }
        public ICollection<ValueOptionResource> ValueOptions { get; set; }
        public ValueOptionSettings ValueOptionSetting { get; set; }
        public virtual ParameterOptions Context { get; set; }
        public string GroupName { get; set; }
        public string AccordingTo { get; set; }
        public string Notes { get; set; }
        public ICollection<AlternativeScriptResource> NestedScripts { get; set; }
    }
}