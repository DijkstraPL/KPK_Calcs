using System.Collections.Generic;

namespace Build_IT_Data.Entities.DeadLoads
{
    public class Category
    {
        #region Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Subcategory> Subcategories { get; private set; }

        #endregion // Properties

        #region Constructors
               
        public Category()
        {
            Subcategories = new HashSet<Subcategory>();
        }

        #endregion // Constructors               
    }
}
