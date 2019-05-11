using Build_IT_CommonTools;
using Build_IT_SnowLoads.API;
using Build_IT_SnowLoads.Interfaces;
using System;

namespace Build_IT_SnowLoads.BuildingTypes
{
    /// <summary>
    /// Calculation class for roofs abutting to taller constructions.
    /// </summary>
    /// <remarks>[PN-EN 1991-1-3 5.3.6]</remarks>
    /// <example>
    /// <code>
    /// class TestClass
    /// {
    ///     static void Main()
    ///     {
    ///         BuildingSite buildingSite = new BuildingSite();
    ///         buildingSite.CalculateExposureCoefficient();
    ///         SnowLoad snowLoad = new SnowLoad(buildingSite, DesignSituation.A, false);
    ///         snowLoad.CalculateSnowLoad();
    ///         Building building = new Building(snowLoad, 15, 3);
    ///         building.CalculateThermalCoefficient();
    ///         RoofAbuttingToTallerConstruction roofAbuttingToTallerConstruction =
    ///           new RoofAbuttingToTallerConstruction(building, 20, 10, 2, 25, false);
    ///         roofAbuttingToTallerConstruction.CalculateDriftLength();
    ///         roofAbuttingToTallerConstruction.CalculateSnowLoad();
    ///     }
    /// }
    /// </code>
    /// </example>
    /// <seealso cref="Snowguards"/>
    /// <seealso cref="SnowOverhanging"/>
    public class DriftingAtProjectionsObstructions : ICalculatable, ILengthProvider
    {
        #region Properties

        /// <summary>
        /// Length of the drift.
        /// </summary>
        [Abbreviation("l_s")]
        [Unit("m")]
        public double DriftLength { get; private set; }

        /// <summary>
        /// Height of the obstruction.
        /// </summary>
        [Abbreviation("h")]
        [Unit("m")]
        public double ObstructionHeight { get; }

        /// <summary>
        /// Snow load shape coefficient.
        /// </summary>
        [Abbreviation("mi_1")]
        [Unit("")]
        public double FirstShapeCoefficient { get; private set; }

        /// <summary>
        /// Snow load shape coefficient.
        /// </summary>
        [Abbreviation("mi_2")]
        [Unit("")]
        public double SecondShapeCoefficient { get; private set; }

        /// <summary>
        /// Snow load on the roof [kN/m2]
        /// </summary>
        [Abbreviation("s")]
        public double SnowLoadOnRoofValue { get; private set; }

        /// <summary>
        /// Snow load on the roof [kN/m2]
        /// </summary>
        [Abbreviation("s_2")]
        [Unit("kN/m2")]
        public double SnowLoadOnRoofValueAtTheEnd { get; private set; }

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
        public DriftingAtProjectionsObstructions(IBuilding building, double obstructionHeight)
        {
            Building = building;
            ObstructionHeight = obstructionHeight > 0 ? obstructionHeight 
                : throw new ArgumentOutOfRangeException(nameof(obstructionHeight));
            SetReferences();
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Calculate <see cref="DriftLength"/>.
        /// </summary>
        public void CalculateDriftLength()
        {
            DriftLength = 2 * ObstructionHeight;
            if (DriftLength < 5)
                DriftLength = 5;
            else if (DriftLength > 15)
                DriftLength = 15;
        }

        /// <summary>
        /// Calculate <see cref="FirstShapeCoefficient"/>, <see cref="SecondShapeCoefficient"/> and <see cref="SnowLoadOnRoofValue"/>.
        /// </summary>
        public void CalculateSnowLoad()
        {
            CalculateSnowLoadShapeCoefficient();
            CalculateSnowLoadOnRoof();
        }

        private void SetReferences()
        {
            snowLoad = Building.SnowLoad;
            buildingSite = snowLoad.BuildingSite;
        }

        /// <summary>
        /// Calculate <see cref="FirstShapeCoefficient"/> and <see cref="SecondShapeCoefficient"/>.
        /// </summary>
        private void CalculateSnowLoadShapeCoefficient()
        {
            FirstShapeCoefficient = 0.8;

            SecondShapeCoefficient = snowLoad.SnowDensity * ObstructionHeight / snowLoad.SnowLoadForSpecificReturnPeriod;

            if (SecondShapeCoefficient < 0.8)
                SecondShapeCoefficient = 0.8;
            else if (SecondShapeCoefficient > 2)
                SecondShapeCoefficient = 2;
        }

        /// <summary>
        /// Calclate <see cref="SnowLoadOnRoofValue"/>.
        /// </summary>
        private void CalculateSnowLoadOnRoof()
        {
            if (!snowLoad.ExcepctionalSituation)
            {
                SnowLoadOnRoofValue =
                    SnowLoadCalc.CalculateSnowLoad(
                        SecondShapeCoefficient,
                        buildingSite.ExposureCoefficient,
                        Building.ThermalCoefficient,
                        snowLoad.SnowLoadForSpecificReturnPeriod);

                SnowLoadOnRoofValueAtTheEnd =
                    SnowLoadCalc.CalculateSnowLoad(
                        FirstShapeCoefficient,
                        buildingSite.ExposureCoefficient,
                        Building.ThermalCoefficient,
                        snowLoad.SnowLoadForSpecificReturnPeriod);
            }
            else
            {
                SnowLoadOnRoofValue =
                    SnowLoadCalc.CalculateSnowLoad(
                        SecondShapeCoefficient,
                        buildingSite.ExposureCoefficient,
                        Building.ThermalCoefficient,
                        snowLoad.DesignExceptionalSnowLoadForSpecificReturnPeriod);

                SnowLoadOnRoofValueAtTheEnd =
                    SnowLoadCalc.CalculateSnowLoad(
                        FirstShapeCoefficient,
                        buildingSite.ExposureCoefficient,
                        Building.ThermalCoefficient,
                        snowLoad.DesignExceptionalSnowLoadForSpecificReturnPeriod);
            }
        }

        #endregion // Methods
    }
}
