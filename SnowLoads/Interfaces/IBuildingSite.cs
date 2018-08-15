using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace SnowLoads.Interfaces
{
    public interface IBuildingSite
    {
        [Abbreviation("A")]
        [Unit("m")]
        double AltitudeAboveSea { get; set; }
        
        ZoneEnum CurrentZone { get; set; }
        
        TopographyEnum CurrentTopography { get; set; }
        
        [Abbreviation("C_e")]
        [Unit("")]
        double ExposureCoefficient { get; }

        void CalculateExposureCoefficient();
    }
}
