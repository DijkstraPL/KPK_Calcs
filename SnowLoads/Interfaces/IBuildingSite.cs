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
        double AltitudeAboveSea { get; set; }
        
        Zone CurrentZone { get; set; }
        
        Topography CurrentTopography { get; set; }
        
        [Abbreviation("C_e")]
        double ExposureCoefficient { get; }

        void CalculateExposureCoefficient();
    }
}
