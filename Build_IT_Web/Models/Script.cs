using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_Web.Models
{
    [Table("Scripts")]
    public class Script
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<Tag> Tags { get; set; } = new Collection<Tag>();
        [StringLength(255)]
        public string GroupName { get; set; }
        [StringLength(255)]
        public string Author { get; set; }
        public DateTime Added { get; set; }
        public DateTime Modified { get; set; }
        [StringLength(255)]
        public string AccordingTo { get; set; }
        public string Notes { get; set; }
        public ICollection<Parameter> Parameters { get; set; } = new Collection<Parameter>();
    }
}
