using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads.API
{
    public static class ShapeCoefficientCalc
    {
        /// <summary>
        /// Calculate snow load coefficient number 1 (Tab.5.2).
        /// </summary>
        /// <param name="slope">Angle for which we calculate in degrees.</param>
        /// <param name="snowFences">Is there any obstacles fe. snow fences.</param>
        /// <returns>Return snow load shape coefficient 1</returns>
        public static double CalculateSnowLoadShapeCoefficient1(double slope, bool snowFences = false)
        {
            if (slope < 0)
                throw new ArgumentOutOfRangeException("Value couldn't be less than 0.");
            else if (snowFences)
                return 0.8;
            else if (slope <= 30)
                return 0.8;
            else if (slope < 60)
                return 0.8 * (60 - slope) / 30;
            else
                return 0;
        }

        /// <summary>
        /// Calculate snow load coefficient number 2 (Tab.5.2).
        /// </summary>
        /// <param name="slope">Angle for which we calculate in degrees.</param>
        /// <returns>Return snow load shape coefficient 2</returns>
        public static double CalculateSnowLoadShapeCoefficient2(double slope)
        {
            if (slope < 0)
                throw new ArgumentOutOfRangeException("Value couldn't be less than 0.");
            else if (slope <= 30)
                return 0.8 + 0.8 * slope / 30;
            else if (slope < 60)
                return 1.6;
            else
                return 1.6;
        }
    }
}
