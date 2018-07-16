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
        public IMonopitchRoof LeftRoof { get; set; }

        /// <summary>
        /// Right roof.
        /// </summary>
        public IMonopitchRoof RightRoof { get; set; }

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
        public IBuilding Building { get; private set; }

        #endregion // Properties

        #region Fields

        private ISnowLoad snowLoad;
        private IBuildingSite buildingSite;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="building">Instance of buildinng.</param>
        public MultiSpanRoof(IBuilding building, double leftRoofSlope, double rightRoofSlope,
            bool leftRoofSnowFences = false, bool rightRoofSnowFences = false)
        {
            Building = building;

            LeftRoof = new MonopitchRoof(Building, leftRoofSlope, leftRoofSnowFences);
            RightRoof = new MonopitchRoof(Building, rightRoofSlope, rightRoofSnowFences);

            SetReferences();
        }

        public MultiSpanRoof(IBuilding building, IMonopitchRoof leftRoof, IMonopitchRoof rightRoof)
        {
            Building = building;

            LeftRoof = leftRoof;
            RightRoof = rightRoof;
        }

        #endregion // Constructors

        #region Methods

        private void SetReferences()
        {
            snowLoad = Building.SnowLoad;
            buildingSite = snowLoad.BuildingSite;
        }

        /// <summary>
        /// Calculate Snow Load On Roof 
        /// </summary>
        public void CalculateSnowLoad()
        {
            LeftRoof.CalculateSnowLoad();
            RightRoof.CalculateSnowLoad();
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
