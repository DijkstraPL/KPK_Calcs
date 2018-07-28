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
    /// Calculation class for snow load near the obstruction.
    /// </summary>
    public class DriftingAtProjectionsObstructions : ICalculatable, ILengthProvider
    {
        #region Properties

        /// <summary>
        /// Length of the drift.
        /// </summary>
        [Abbreviation("l_s")]
        public double DriftLength { get; private set; }

        /// <summary>
        /// Height of the obstruction.
        /// </summary>
        [Abbreviation("h")]
        public double ObstructionHeight { get; set; }

        /// <summary>
        /// Snow load shape coefficient.
        /// </summary>
        [Abbreviation("mi_1")]
        public double FirstShapeCoefficient { get; private set; }

        /// <summary>
        /// Snow load shape coefficient.
        /// </summary>
        [Abbreviation("mi_2")]
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
            ObstructionHeight = obstructionHeight;
            SetReferences();
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Calculate drift length.
        /// </summary>
        public void CaluclateDriftLength()
        {
            DriftLength = 2 * ObstructionHeight;
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
            CalculateSnowLoadShapeCoefficient();
            CalculateSnowLoadOnRoof();
        }

        private void SetReferences()
        {
            snowLoad = Building.SnowLoad;
            buildingSite = snowLoad.BuildingSite;
        }

        /// <summary>
        /// Calculate shape coefficient due to wind.
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
        /// Calclate snow load.
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
