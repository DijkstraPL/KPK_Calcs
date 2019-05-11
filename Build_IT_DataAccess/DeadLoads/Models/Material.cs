using Build_IT_Data.Units.Enums;

namespace Build_IT_DataAccess.DeadLoads.Models
{
    public class Material
    {
        #region Properties
        
        public long Id { get; set; }
        public string Name { get; set; }
        public double MinimumDensity { get; set; }
        public double MaximumDensity { get; set; }
        public LoadUnit Unit { get; set; }
        public string DocumentName { get; set; }
        public string Comments { get; set; }
        public Subcategory Subcategory { get; set; }
        public long SubcategoryId { get; set; }

        #endregion // Properties
    }
}
