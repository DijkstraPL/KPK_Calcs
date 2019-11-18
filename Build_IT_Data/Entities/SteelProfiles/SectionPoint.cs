using Build_IT_Data.Entities.SteelProfiles.Enums;

namespace Build_IT_Data.Entities.SteelProfiles
{
    public class SectionPoint
    {
        #region Properties

        public long Id { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public ChamferType ChamferType { get; set; }
        public string ChamferX { get; set; }
        public string ChamferY { get; set; }

        #endregion // Properties
    }
}
