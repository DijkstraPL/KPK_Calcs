using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.ValueOptions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Build_IT_Web.Core.Models
{
    [Table("Parameters")]
    public class Parameter
    {
        public long Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        public int Number { get; set; }
        public string Description { get; set; }
        [Required]
        public ValueTypes ValueType { get; set; }
        public string Value { get; set; }
        public string DataValidator { get; set; }
        public string Unit { get; set; }
        public ICollection<ValueOption> ValueOptions { get; set; }
        public ValueOptionSettings ValueOptionSetting { get; set; }
        public virtual ParameterOptions Context { get; set; }
        public string GroupName { get; set; }
        public string AccordingTo { get; set; }
        public string Notes { get; set; }
        public ICollection<AlternativeScript> NestedScripts { get; set; }

        public Script Script { get; set; }
        public long ScriptId { get; set; }

        public Parameter()
        {
            ValueOptions = new Collection<ValueOption>();
        }
    }
}
