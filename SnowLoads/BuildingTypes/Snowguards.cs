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
    /// Calculation class for snow guards.
    /// </summary>
    public class Snowguards : ICalculatable
    {
        #region Properties

        /// <summary>
        /// s - Snow load on the roof - the most onerous undrifted load case
        /// appropriate for the roof under consideration [kN/m2].
        /// </summary>
        [Abbreviation("s")]
        public double SnowLoadOnRoofValue { get; set; }

        /// <summary>
        /// b - Width on plan (horizontal) from the guard or obstacle to the next guard or to the ridge.
        /// </summary>
        [Abbreviation("b")]
        public double Width { get; set; }

        /// <summary>
        /// alpha - pitch of the roof, measured from the horizontal
        /// </summary>
        [Abbreviation("alpha")]
        public double Slope { get; set; }

        /// <summary>
        /// Force on snow guard.
        /// </summary>
        [Abbreviation("F_s")]
        public double ForceExertedBySnow { get; private set; }

        #endregion // Properties

        public Snowguards(double width, double slope, double snowLoadOnRoof)
        {
            Width = width;
            Slope = slope;
            SnowLoadOnRoofValue = snowLoadOnRoof;
        }

        #region Methods
        
        /// <summary>
        /// Calculate Snow Load On Roof 
        /// </summary>
        public void CalculateSnowLoad()
        {
            CalculateForce();
        }

        /// <summary>
        /// Calculate force exerted on snow guard.
        /// </summary>
        private void CalculateForce()
        {
            ForceExertedBySnow = SnowLoadOnRoofValue * Width * Math.Sin(UnitConversion.ConvertToRadians(Slope));
        }

        #endregion // Methods
    }
}
