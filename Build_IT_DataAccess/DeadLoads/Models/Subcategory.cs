using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Build_IT_DataAccess.DeadLoads.Models
{
    [Table("Subcategories")]
    public class Subcategory
    {
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string DocumentName { get; set; }

        public Category Category { get; set; }
        public ICollection<Material> Materials { get; set; }

        public Subcategory()
        {
            Materials = new Collection<Material>();
        }
    }
}
