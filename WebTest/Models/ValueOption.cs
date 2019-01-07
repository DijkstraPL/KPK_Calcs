using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebTest.Models.Enums;

namespace WebTest.Models
{
    [Table("ValueOptions")]
    public class ValueOption
    {
        public long Id { get; set; }
        [Required]
        public string Value { get; set; }
        public string Description { get; set; }

        public Parameter Parameter { get; set; }
        public long ParameterId { get; set; }
    }
}
