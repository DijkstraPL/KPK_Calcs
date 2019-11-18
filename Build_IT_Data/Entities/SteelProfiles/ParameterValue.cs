using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Data.Entities.SteelProfiles
{
    public class ParameterValue
    {
        #region Properties
               
        public long Id { get; set; }
        public Parameter Parameter { get; set; }
        public long ParameterId { get; set; }
        public object Value { get; set; }

        #endregion // Properties
               
    }
}
