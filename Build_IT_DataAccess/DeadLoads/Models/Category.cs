using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Build_IT_DataAccess.DeadLoads.Models
{
    public class Category
    {
        #region Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Subcategory> Subcategories { get; set; }

        #endregion // Properties

        #region Constructors
               
        public Category()
        {
            Subcategories = new Collection<Subcategory>();
        }

        #endregion // Constructors               
    }
}
