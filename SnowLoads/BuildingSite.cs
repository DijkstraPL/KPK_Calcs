﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads
{
    /// <summary>
    /// Class for additional informations about building site.
    /// </summary>
    public class BuildingSite
    {
        /// <summary>
        /// A - Altitude above sea level.
        /// </summary>
        /// <remarks>
        /// Height above mean sea level of the site where the structure is to be located, or
        /// is already located for an existing structure.
        /// </remarks>
        [Abbreviation("A")]
        public double AltitudeAboveSea { get; set; }

        /// <summary>
        /// Zone read from the proper map.
        /// </summary>
        public Zone CurrentZone { get; set; }

        /// <summary>
        /// Topography base on terrain conditions.
        /// </summary>
        public Topography CurrentTopography { get; set; }

        /// <summary>
        /// Ce - Exposure coefficient - 
        /// coefficient defining the reduction or increase of load on a roof of an unheated
        /// building, as a fraction of the characteristic snow load on the ground.
        /// </summary>
        /// <remarks>
        /// The exposure coefficient Ce should be used for determining the snow load
        /// on the roof.The choice for Ce should consider the future development around
        /// the site.Ce should be taken as 1,0 unless otherwise specified for different
        /// topographies.
        /// </remarks>
        [Abbreviation("C_e")]
        public double ExposureCoefficient { get; private set; }

        /// <summary>
        /// Calcualte exposure coefficient.
        /// </summary>
        public void CalculateExposureCoefficient()
        {
            switch (CurrentTopography)
            {
                case Topography.Windswept:
                    ExposureCoefficient = 0.8;
                    break;
                case Topography.Normal:
                    ExposureCoefficient = 1.0;
                    break;
                case Topography.Sheltered:
                    ExposureCoefficient = 1.2;
                    break;
                case Topography.None:
                    ExposureCoefficient = 1.2;
                    break;
                default:
                    throw new ArgumentException("Topography should be selected.");
            }
        }
    }

    /// <summary>
    /// Zone enumerator.
    /// </summary>
    public enum Zone
    {
        None,
        FirstZone,
        BetweenFirst_Second,
        SecondZone,
        BetweenSecond_Third,
        ThirdZone,
        BetweenThird_Fourth,
        FourthZone,
        BetweenFourth_Fifth,
        FifthZone
    }

    /// <summary>
    /// Topography enumerator
    /// </summary>
    public enum Topography
    {
        None,
        /// <summary>
        /// flat unobstructed areas exposed on all sides
        /// without, or little shelter afforded by terrain, higher construction works or
        /// trees.
        /// </summary>
        Windswept,
        /// <summary>
        /// areas where there is no significant removal of snow
        /// by wind on construction work, because of terrain, other construction works
        /// or trees.
        /// </summary>
        Normal,
        /// <summary>
        /// areas in which the construction work being
        /// considered is considerably lower than the surrounding terrain or
        /// surrounded by high trees and/or surrounded by higher construction works.
        /// </summary>
        Sheltered
    }
}
