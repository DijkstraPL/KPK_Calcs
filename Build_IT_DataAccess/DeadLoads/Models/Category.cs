using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Build_IT_DataAccess.DeadLoads.Models
{
    [Table("Categories")]
    public class Category
    {
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Subcategory> Subcategories { get; set; }

        public Category()
        {
            Subcategories = new Collection<Subcategory>();
        }
    }
}
