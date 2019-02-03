using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Build_IT_Web.Core.Models
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
