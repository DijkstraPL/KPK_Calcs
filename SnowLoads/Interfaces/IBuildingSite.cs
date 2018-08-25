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
        /// <summary>
        /// Altitude above sea level.
        /// </summary>
        [Abbreviation("A")]
        [Unit("m")]
        double AltitudeAboveSea { get; set; }

        /// <summary>
        /// Zone read from the proper map - <see cref="ZoneEnum"/>.
        /// </summary>
        ZoneEnum CurrentZone { get; set; }

        /// <summary>
        /// Topography base on terrain conditions - <see cref="TopographyEnum"/>.
        /// </summary>
        TopographyEnum CurrentTopography { get; set; }

        /// <summary>
        /// Exposure coefficient.
        /// </summary>
        [Abbreviation("C_e")]
        [Unit("")]
        double ExposureCoefficient { get; }

        /// <summary>
        /// Calcualte <see cref="ExposureCoefficient"/>.
        /// </summary>
        void CalculateExposureCoefficient();
    }
}
