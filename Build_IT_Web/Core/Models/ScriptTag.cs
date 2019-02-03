using System.ComponentModel.DataAnnotations.Schema;

namespace Build_IT_Web.Core.Models
{
    [Table("ScriptTags")]
    public class ScriptTag
    {
        public long ScriptId { get; set; }
        public long TagId { get; set; }

        public Script Script { get; set; }
        public Tag Tag { get; set; }
    }
}
