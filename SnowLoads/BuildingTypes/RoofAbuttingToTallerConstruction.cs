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
    /// Roof which abutte to taller construction.
    /// </summary>
    public class RoofAbuttingToTallerConstruction : ICalculatable, ILengthProvider
    {
        #region Properties

        /// <summary>
        /// Snow load shape coefficient due to sliiding of snow.
        /// </summary>
        [Abbreviation("mi_s")]
        public double ShapeCoefficientSlidingSnow { get; private set; }

        /// <summary>
        /// Snow load shape coefficient due to wind.
        /// </summary>
        [Abbreviation("mi_w")]
        public double ShapeCoefficientWind { get; private set; }

        /// <summary>
        /// Snow load shape coefficient.
        /// </summary>
        [Abbreviation("mi_2")]
        public double ShapeCoefficient { get; private set; }

        /// <summary>
        /// Snow load shape coefficient at the end of drift length.
        /// </summary>
        [Abbreviation("mi")]
        public double ShapeCoefficientAtTheEnd { get; private set; }

        /// <summary>
        /// Upper roof instance.
        /// </summary>
        public IMonopitchRoof UpperRoof { get; set; }

        /// <summary>
        /// Width of the taller building [m].
        /// </summary>
        [Abbreviation("b_1")]
        public double WidthOfUpperBuilding { get; set; }

        /// <summary>
        /// Width of the lower building [m].
        /// </summary>
        [Abbreviation("b_2")]
        public double WidthOfLowerBuilding { get; set; }

        /// <summary>
        /// Height difference between buildings [m].
        /// </summary>
        [Abbreviation("h")]
        public double HeightDifference { get; set; }
        
        /// <summary>
        /// Snow load on the roof [kN/m2]
        /// </summary>
        [Abbreviation("s")]
        public double SnowLoadOnRoofValue { get; private set; }

        /// <summary>
        /// Snow load on the roof [kN/m2]
        /// </summary>
        [Abbreviation("s_2")]
        public double SnowLoadOnRoofValueAtTheEnd { get; private set; }

        /// <summary>
        /// Length of the drift [m].
        /// </summary>
        [Abbreviation("l_s")]
        public double DriftLength { get; private set; }

        /// <summary>
        /// Instance of building.
        /// </summary>
        public IBuilding Building { get; private set; }

        #endregion

        #region Fields

        private ISnowLoad snowLoad;
        private IBuildingSite buildingSite;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="building">Instance of buildinng.</param>
        public RoofAbuttingToTallerConstruction(IBuilding building, double widthOfUpperBuilding, double widthOfLowerBuilding,
           double heightDifference, double slopeOfHigherRoof, bool snowFencesOnHigherRoof = false)
        {
            Building = building;

            UpperRoof = new MonopitchRoof(Building, slopeOfHigherRoof, snowFencesOnHigherRoof);

            WidthOfUpperBuilding = widthOfUpperBuilding;
            WidthOfLowerBuilding = widthOfLowerBuilding;
            HeightDifference = heightDifference;

            SetReferences();
        }

        public RoofAbuttingToTallerConstruction(IBuilding building, double widthOfUpperBuilding, double widthOfLowerBuilding,
           double heightDifference, IMonopitchRoof upperRoof)
        {
            Building = building;

            UpperRoof = upperRoof;

            WidthOfUpperBuilding = widthOfUpperBuilding;
            WidthOfLowerBuilding = widthOfLowerBuilding;
            HeightDifference = heightDifference;

            SetReferences();
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Calculate drift length.
        /// </summary>
        public void CaluclateDriftLength()
        {
            DriftLength = 2 * HeightDifference;
            if (DriftLength < 5)
                DriftLength = 5;
            else if (DriftLength > 15)
                DriftLength = 15;
        }

        /// <summary>
        /// Calculate Snow Load On Roof 
        /// </summary>
        public void CalculateSnowLoad()
        {
            UpperRoof.CalculateSnowLoad();
            CaluclateShapeCoefficients();
            CalculateSnowLoadOnRoof();
        }

        private void SetReferences()
        {
            snowLoad = Building.SnowLoad;
            buildingSite = snowLoad.BuildingSite;
        }

        private void CaluclateShapeCoefficients()
        {
            CalculateShapeCoefficientSlidingSnow();
            CalculateShapeCoefficientWind();
            CaluclateShapeCoefficient();

            if (DriftLength == 0)
                CaluclateDriftLength();
            CalculateShapeCoefficientAtTheEnd();
        }

        /// <summary>
        /// Calculate shape coefficient due to sliding snow.
        /// </summary>
        private void CalculateShapeCoefficientSlidingSnow()
        {
            if (UpperRoof.Slope <= 15)
                ShapeCoefficientSlidingSnow = 0.8;
            else
                ShapeCoefficientSlidingSnow = 0.5 * UpperRoof.SnowLoadOnRoofValue;
        }

        /// <summary>
        /// Calculate shape coefficient due to wind.
        /// </summary>
        private void CalculateShapeCoefficientWind()
        {
            ShapeCoefficientWind = Math.Min((WidthOfUpperBuilding + WidthOfLowerBuilding) / (2 * HeightDifference),
                snowLoad.SnowDensity * HeightDifference / snowLoad.SnowLoadForSpecificReturnPeriod);

            if (ShapeCoefficientWind < 0.8)
                ShapeCoefficientWind = 0.8;
            else if (ShapeCoefficientWind > 4)
                ShapeCoefficientWind = 4;
        }

        /// <summary>
        /// Calculate shape coefficient for the roof.
        /// </summary>
        private void CaluclateShapeCoefficient()
        {
            ShapeCoefficient = ShapeCoefficientSlidingSnow + ShapeCoefficientWind;
        }

        /// <summary>
        /// Calculate shape coefficient at the end of drift length.
        /// </summary>
        private void CalculateShapeCoefficientAtTheEnd()
        {
            if (DriftLength <= WidthOfLowerBuilding)
                ShapeCoefficientAtTheEnd = 0.8;
            else
                ShapeCoefficientAtTheEnd = ShapeCoefficient - WidthOfLowerBuilding / DriftLength * (ShapeCoefficient - 0.8);
        }

        /// <summary>
        /// Calculate snow load for the roof.
        /// </summary>
        private void CalculateSnowLoadOnRoof()
        {
            if (!snowLoad.ExcepctionalSituation)
            {
                SnowLoadOnRoofValue =
                    SnowLoadCalc.CalculateSnowLoad(
                        ShapeCoefficient,
                        buildingSite.ExposureCoefficient,
                        Building.ThermalCoefficient,
                        snowLoad.SnowLoadForSpecificReturnPeriod);

                SnowLoadOnRoofValueAtTheEnd =
                    SnowLoadCalc.CalculateSnowLoad(
                        ShapeCoefficientAtTheEnd,
                        buildingSite.ExposureCoefficient,
                        Building.ThermalCoefficient,
                        snowLoad.SnowLoadForSpecificReturnPeriod);
            }
            else
            {
                SnowLoadOnRoofValue =
                    SnowLoadCalc.CalculateSnowLoad(
                        ShapeCoefficient,
                        buildingSite.ExposureCoefficient,
                        Building.ThermalCoefficient,
                        snowLoad.DesignExceptionalSnowLoadForSpecificReturnPeriod);

                SnowLoadOnRoofValueAtTheEnd =
                    SnowLoadCalc.CalculateSnowLoad(
                        ShapeCoefficientAtTheEnd,
                        buildingSite.ExposureCoefficient,
                        Building.ThermalCoefficient,
                        snowLoad.DesignExceptionalSnowLoadForSpecificReturnPeriod);
            }
        }


        #endregion // Methods
    }
}
