using SnowLoads.API;
using SnowLoads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace SnowLoads.BuildingTypes
{
    /// <summary>
    /// Calculation class for loads on snow guards or other obstacles.
    /// </summary>
    /// <remarks>[PN-EN 1991-1-3 6.4.(1)]</remarks>
    /// <example>
    /// <code>
    /// class TestClass
    /// {
    ///     static void Main()
    ///     {
    ///         Snowguards snowguards = new Snowguards(20, 30, 0.72);
    ///         snowguards.CalculateSnowLoad();
    ///     }
    /// }
    /// </code>
    /// </example>
    /// <seealso cref="DriftingAtProjectionsObstructions"/>
    /// <seealso cref="SnowOverhanging"/>
    public class Snowguards : ICalculatable
    {
        #region Properties

        /// <summary>
        /// Snow load on the roof - the most onerous undrifted load case
        /// appropriate for the roof under consideration [kN/m2].
        /// </summary>
        [Abbreviation("s")]
        [Unit("kN/m2")]
        public double SnowLoadOnRoofValue { get; set; }

        /// <summary>
        /// Width on plan (horizontal) from the guard or obstacle to the next guard or to the ridge [m].
        /// </summary>
        [Abbreviation("b")]
        [Unit("m")]
        public double Width { get; set; }

        /// <summary>
        /// Pitch of the roof, measured from the horizontal [degree].
        /// </summary>
        [Abbreviation("alpha")]
        [Unit("degree")]
        public double Slope { get; set; }

        /// <summary>
        /// Force on snow guard [kN/m].
        /// </summary>
        [Abbreviation("F_s")]
        [Unit("kN/m")]
        public double ForceExertedBySnow { get; private set; }

        #endregion // Properties

        /// <summary>
        /// Initializes a new instance of the <see cref="Snowguards"/> class.
        /// </summary>
        /// <param name="width">Set <see cref="Width"/>.</param>
        /// <param name="slope">Set <see cref="Slope"/>.</param>
        /// <param name="snowLoadOnRoof">Set <see cref="SnowLoadOnRoofValue"/>.</param>
        public Snowguards(double width, double slope, double snowLoadOnRoof)
        {
            Width = width;
            Slope = slope;
            SnowLoadOnRoofValue = snowLoadOnRoof;
        }

        #region Methods

        /// <summary>
        /// Calculate <see cref="ForceExertedBySnow"/>.
        /// </summary>
        /// <remarks>[PN-EN 1991-1-3 6.4.(1)]</remarks>
        public void CalculateSnowLoad()
        {
            CalculateForce();
        }

        /// <summary>
        /// Calculate <see cref="ForceExertedBySnow"/>.
        /// </summary>
        /// <remarks>[PN-EN 1991-1-3 6.4.(1)]</remarks>
        private void CalculateForce()
        {
            ForceExertedBySnow = SnowLoadOnRoofValue * Width * Math.Sin(UnitConversion.ConvertToRadians(Slope));
        }

        #endregion // Methods
    }
}
