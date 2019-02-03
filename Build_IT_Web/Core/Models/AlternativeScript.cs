using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Build_IT_Web.Core.Models
{
    [Table("AlternativeScripts")]
    public class AlternativeScript
    {
        public long Id { get; set; }
        [Required]
        [StringLength(255)]
        public string ScriptName { get; set; }

        public Parameter Parameter { get; set; }
        public long ParameterId { get; set; }
    }
}