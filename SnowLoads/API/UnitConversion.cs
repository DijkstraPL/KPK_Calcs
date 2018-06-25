using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads.API
{
    public static class UnitConversion
    {
        /// <summary>
        /// Convert percentage into degree.
        /// </summary>
        /// <param name="percentage">Slope in percent.</param>
        /// <returns>Angle in degree.</returns>
        public static double ConvertToDegrees(double percentage) => Math.Atan(Convert.ToDouble(percentage) / 100) * 180 / Math.PI;

        /// <summary>
        /// Convert degrees into radians.
        /// </summary>
        /// <param name="degrees">Degrees.</param>
        /// <returns>Radians.</returns>
        public static double ConvertToRadians(double degrees) => degrees * Math.PI / 180;
    }
}
