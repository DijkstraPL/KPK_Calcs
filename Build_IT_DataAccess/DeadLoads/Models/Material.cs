using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Build_IT_DataAccess.DeadLoads.Models
{
    [Table("Materials")]
    public class Material
    {
        public long Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        public double MinimumDensity { get; set; }
        [Required]
        public double MaximumDensity { get; set; }
        [Required]
        public string Units { get; set; }
        public string DocumentName { get; set; }
        public string AdditionalOption1 { get; set; }
        public string AdditionalOption2 { get; set; }
        public string AdditionalComments { get; set; }

        public Subcategory Subcategory { get; set; }
    }
}
