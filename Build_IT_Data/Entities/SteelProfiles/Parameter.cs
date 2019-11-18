using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Data.Entities.SteelProfiles
{
    public class Parameter
    {
        #region Properties
               
        public long Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }

        #endregion // Properties
               
    }
}
