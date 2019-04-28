﻿using Build_IT_CommonTools;
using Build_IT_SnowLoads.Enums;

namespace Build_IT_SnowLoads.Interfaces
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
        Zones CurrentZone { get; set; }

        /// <summary>
        /// Topography base on terrain conditions - <see cref="TopographyEnum"/>.
        /// </summary>
        Topographies CurrentTopography { get; set; }

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