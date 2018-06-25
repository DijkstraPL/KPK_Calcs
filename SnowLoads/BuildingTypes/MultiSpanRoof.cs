using SnowLoads.API;
using SnowLoads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads.BuildingTypes
{
    /// <summary>
    /// Calculation class for multi span roofs.
    /// </summary>
    public class MultiSpanRoof : ICalculatable
    {
        #region Properties

        /// <summary>
        /// Left roof.
        /// </summary>
        public MonopitchRoof LeftRoof { get; set; }

        /// <summary>
        /// Right roof.
        /// </summary>
        public MonopitchRoof RightRoof { get; set; }

        /// <summary>
        /// Snow load on middle roof [kN/m2]
        /// </summary>
        public double SnowLoadOnMiddleRoof { get; private set; }

        /// <summary>
        /// Snow load shape coefficient
        /// </summary>
        [Abbreviation("mi_2")]
        public double ShapeCoefficient { get; private set; }
        
        /// <summary>
        /// Instance of building.
        /// </summary>
        public Building Building { get; private set; }

        #endregion // Properties

        #region Fields

        private SnowLoad snowLoad;
        private BuildingSite buildingSite;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="building">Instance of buildinng.</param>
        public MultiSpanRoof(Building building, double leftRoofSlope, double rightRoofSlope,
            bool leftRoofSnowFences = false, bool rightRoofSnowFences = false)
        {
            Building = building;

            LeftRoof = new MonopitchRoof(Building, leftRoofSlope, leftRoofSnowFences);
            RightRoof = new MonopitchRoof(Building, rightRoofSlope, rightRoofSnowFences);
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Calculate Snow Load On Roof 
        /// </summary>
        public void CalculateSnowLoad()
        {
            CalculateSnowLoadShapeCoefficient();
            CalculateSnowLoadOnRoof();
        }

        /// <summary>
        /// Method calculate shape coefficient for monopiych roof.
        /// </summary>
        public void CalculateSnowLoadShapeCoefficient()
        {
            if (LeftRoof.Slope > 60 || RightRoof.Slope > 60)
                ShapeCoefficient = 1.6;
            else
                ShapeCoefficient = ShapeCoefficientCalc.CalculateSnowLoadShapeCoefficient2(LeftRoof.Slope + RightRoof.Slope);
        }

        /// <summary>
        /// Calculate snow load on roof.
        /// </summary>
        public void CalculateSnowLoadOnRoof()
        {
            if (!snowLoad.ExcepctionalSituation)
                SnowLoadOnMiddleRoof =
                    SnowLoadCalc.CalculateSnowLoad(
                        ShapeCoefficient,
                        buildingSite.ExposureCoefficient,
                        Building.ThermalCoefficient,
                        snowLoad.SnowLoadForSpecificReturnPeriod);
            else
                SnowLoadOnMiddleRoof =
                    SnowLoadCalc.CalculateSnowLoad(
                        ShapeCoefficient,
                        buildingSite.ExposureCoefficient,
                        Building.ThermalCoefficient,
                        snowLoad.DesignExceptionalSnowLoadForSpecificReturnPeriod);
        }

        #endregion // Methods
    }
}
