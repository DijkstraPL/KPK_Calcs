using Build_IT_Data.Sections.Additional.Interfaces;
using System.Collections.Generic;

namespace Build_IT_BeamStatica.Data
{
    public class SectionPropertiesData
    {
        public IList<IPoint> Points { get; private set; }

        public SectionPropertiesData()
        {
            Points = new List<IPoint>();
        }
    }
}
