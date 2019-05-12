using Build_IT_DataAccess.DeadLoads.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Build_IT_Web.Controllers.DeadLoadsControllers.Resources
{
    public class SubcategoryResource
    {
        #region Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public string DocumentName { get; set; }

        #endregion // Properties
    }
}
