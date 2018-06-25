using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads.API
{
    public static class SnowLoadCalc
    {
        /// <summary>
        /// Calculate snow load.
        /// </summary>
        /// <param name="shapeCoefficient">Shape coefficient.</param>
        /// <param name="exposureCoefficient">Exposure coefficient.</param>
        /// <param name="thermalCoefficient">Thermal coefficient.</param>
        /// <param name="snowLoad">Value of snow load laying on ground[kN/m2].</param>
        /// <returns>Snow load.</returns>
        public static double CalculateSnowLoad(double shapeCoefficient, double exposureCoefficient, double thermalCoefficient, double snowLoad) =>
            shapeCoefficient * exposureCoefficient * thermalCoefficient * snowLoad;

        public static double CalculateSnowLoadForAnnexB(double shapeCoefficient, double snowLoad) => shapeCoefficient * snowLoad;
    }
}
