using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Build_IT_Data.Entities.DeadLoads
{
    public class Addition
    {
        #region Property

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }

        #endregion // Property
    }
}
