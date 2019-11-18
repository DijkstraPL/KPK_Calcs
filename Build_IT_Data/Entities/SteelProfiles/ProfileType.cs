using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Data.Entities.SteelProfiles
{
    public class ProfileType
    {
        #region Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Parameter> Parameters { get; private set; }
        public ICollection<SectionPoint> SectionPoints { get; private set; }
        public ICollection<SteelProfile> SteelProfiles { get; private set; }

        #endregion // Properties

        #region Constructors

        public ProfileType()
        {
            Parameters = new HashSet<Parameter>();
            SectionPoints = new HashSet<SectionPoint>();
            SteelProfiles = new HashSet<SteelProfile>();
        }

        #endregion // Constructors
    }
}
