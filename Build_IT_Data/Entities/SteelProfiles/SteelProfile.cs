using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Data.Entities.SteelProfiles
{
    public class SteelProfile
    {
        #region Properties
        
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<ParameterValue> ParametersValues { get; private set; }

        #endregion // Properties

        #region Constructors
        
        public SteelProfile()
        {
            ParametersValues = new HashSet<ParameterValue>();
        }

        #endregion // Constructors
    }
}
