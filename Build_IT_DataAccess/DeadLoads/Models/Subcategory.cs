using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Build_IT_DataAccess.DeadLoads.Models
{
    public class Subcategory
    {
        #region Properties
        
        public long Id { get; set; }
        public string Name { get; set; }
        public string DocumentName { get; set; }
        public Category Category { get; set; }
        public long CategoryId { get; set; }
        public ICollection<Material> Materials { get; set; }

        #endregion // Properties

        #region Constructors

        public Subcategory()
        {
            Materials = new Collection<Material>();
        }

        #endregion // Constructors
    }
}
