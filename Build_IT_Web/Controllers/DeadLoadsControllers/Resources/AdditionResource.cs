using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.DeadLoadsControllers.Resources
{
    public class AdditionResource
    {
        #region Property

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }

        #endregion // Property
    }
}
