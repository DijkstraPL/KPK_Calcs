using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_Web.Models
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
