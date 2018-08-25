using SnowLoads.API;
using SnowLoads.BuildingTypes;
using SnowLoads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace SnowLoads.Exceptional
{   
    /// <summary>
    /// Calculation class for exceptional snow behind parapet at eaves.
    /// </summary>
    /// <remarks>[PN-EN 1991-1-3 B4]</remarks>
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
    ///         ExceptionalSnowBehindParapetAtEaves exceptionalSnowBehindParapetAtEaves = 
    ///             new ExceptionalSnowBehindParapetAtEaves(building, 10, 20, 0.7);
    ///         exceptionalSnowBehindParapetAtEaves.CalculateDriftLength();
    ///         exceptionalSnowBehindParapetAtEaves.CalculateSnowLoad();
    ///     }
    /// }
    /// </code>
    /// </example>
    /// <seealso cref="ExceptionalMultiSpanRoof"/>
    /// <seealso cref="ExceptionalRoofAbuttingToTallerConstruction"/>
    /// <seealso cref="ExceptionalObstructionOnFlatRoof"/>
    /// <seealso cref="ExceptionalObstructionOnPitchedOrCurvedRoof"/>
    /// <seealso cref="ExceptionalOverDoorOrLoadingBay"/>
    /// <seealso cref="ExceptionalSnowBehindParapet"/>
    /// <seealso cref="ExceptionalSnowInValleyBehindParapet"/>
    public class ExceptionalSnowBehindParapetAtEaves : ICalculatable
    {
        #region Properties

        /// <summary>
        /// Height difference.
        /// </summary>
        /// <remarks>[PN-EN 1991-1-3 Fig.B4]</remarks>
        [Abbreviation("h_1")]
        [Unit("m")]
        public double HeightDifference { get; set; }

        /// <summary>
        /// Distance to the ridge of roof.
        /// </summary>
        /// <remarks>[PN-EN 1991-1-3 Fig.B4]</remarks>
        [Abbreviation("b_1")]
        [Unit("m")]
        public double RidgeDistance { get; set; }
        /// <summary>
        /// Width of roof.
        /// </summary>
        /// <remarks>[PN-EN 1991-1-3 Fig.B4]</remarks>
        [Abbreviation("b_2")]
        [Unit("m")]
        public double BuildingWidth { get; set; }

        /// <summary>
        /// Snow load shape coefficient.
        /// </summary>
        /// <remarks>[PN-EN 1991-1-3 Fig.B4]</remarks>
        [Abbreviation("mi_1")]
        [Unit("")]
        public double ShapeCoefficient { get; private set; }

        /// <summary>
        /// Length of the drift.
        /// </summary>
        /// <remarks>[PN-EN 1991-1-3 Fig.B4]</remarks>
        [Abbreviation("l_s")]
        [Unit("m")]
        public double DriftLength { get; private set; }

        /// <summary>
        /// Snow load.
        /// </summary>
        /// <remarks>[PN-EN 1991-1-3 Fig.B4]</remarks>
        [Abbreviation("s")]
        [Unit("kN/m2")]
        public double SnowLoad { get; private set; }

        public IBuilding Building { get; private set; }

        #endregion // Properties

        #region Fields

        private ISnowLoad snowLoad;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionalSnowBehindParapetAtEaves"/> class.
        /// </summary>
        /// <param name="building">Set instance of a class implementing <see cref="IBuilding"/> for <see cref="Building"/>.</param>
        /// <param name="ridgeDistance">Set <see cref="RidgeDistance"/>.</param>
        /// <param name="buildingWidth">Set <see cref="BuildingWidth"/>.</param>
        /// <param name="heightDifference">Set <see cref="HeightDifference"/>.</param>
        public ExceptionalSnowBehindParapetAtEaves(IBuilding building, double ridgeDistance, double buildingWidth, double heightDifference)
        {
            Building = building;
            RidgeDistance = ridgeDistance;
            BuildingWidth = buildingWidth;
            HeightDifference = heightDifference;
            SetReferences();
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Calculate <see cref="DriftLength"/>.
        /// </summary>
        /// <remarks>[PN-EN 1991-1-3 B4.(4)</remarks>
        public void CalculateDriftLength()
        {
            DriftLength = Math.Min(5 * HeightDifference, RidgeDistance);
            DriftLength = Math.Min(DriftLength, 15);
        }

        /// <summary>
        /// Calculate <see cref="SnowLoad"/>.
        /// </summary>
        /// <remarks>[PN-EN 1991-1-3 B4.(4)</remarks>
        public void CalculateSnowLoad()
        {
            CalculateShapeCoefficient();
            CalculateSnowLoadOnRoof();
        }

        private void SetReferences()
        {
            snowLoad = Building.SnowLoad;
        }

        private void CalculateShapeCoefficient()
        {
            ShapeCoefficient = Math.Min(2 * HeightDifference / snowLoad.SnowLoadForSpecificReturnPeriod, 8);
            ShapeCoefficient = Math.Min(ShapeCoefficient, 2 * Math.Max(RidgeDistance,BuildingWidth) / DriftLength);
        }

        private void CalculateSnowLoadOnRoof()
        {
            if (ConditionChecker.ForDesignSituation(snowLoad.ExcepctionalSituation, snowLoad.CurrentDesignSituation, true))
                SnowLoad = SnowLoadCalc.CalculateSnowLoadForAnnexB(ShapeCoefficient, snowLoad.SnowLoadForSpecificReturnPeriod);
        }

        #endregion // Methods
    }
}
