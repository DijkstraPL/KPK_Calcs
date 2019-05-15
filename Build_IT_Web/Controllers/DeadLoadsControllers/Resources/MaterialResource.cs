using Build_IT_Data.Units.Enums;
using Build_IT_DataAccess.DeadLoads.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Build_IT_Web.Controllers.DeadLoadsControllers.Resources
{
    public class MaterialResource
    {
        #region Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public double MinimumDensity { get; set; }
        public double MaximumDensity { get; set; }
        public LoadUnit Unit { get; set; }
        public string DocumentName { get; set; }
        public string Comments { get; set; }
        public ICollection<AdditionResource> Additions { get; set; }

        #endregion // Properties

        #region Constructors

        public MaterialResource()
        {
            Additions = new Collection<AdditionResource>();
        }

        #endregion // Constructors
    }
}
