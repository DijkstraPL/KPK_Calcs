﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebTest.Models.Enums;

namespace WebTest.Models
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
    }
}