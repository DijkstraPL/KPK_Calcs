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
    /// Calculation class for monopitch roofs.
    /// </summary>
    public class MonopitchRoof : IMonopitchRoof
    {
        #region Properties

        /// <summary>
        /// Slope for roof.
        /// </summary>
        [Abbreviation("alpha")]
        public double Slope { get; set; }

        /// <summary>
        /// Is there any obstacles, like snow fences.
        /// </summary>
        public bool SnowFences { get; set; }

        /// <summary>
        /// Snow load shape coefficient
        /// </summary>
        [Abbreviation("mi_1")]
        public double ShapeCoefficient { get; private set; }

        /// <summary>
        /// Snow load on the roof [kN/m2]
        /// </summary>
        [Abbreviation("s")]
        public double SnowLoadOnRoofValue { get; private set; }

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
        public MonopitchRoof(IBuilding building, double slope, bool snowFences = false)
        {
            Building = building;
            Slope = slope;
            SnowFences = snowFences;
            SetReferences();
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
        
        private void SetReferences()
        {
            snowLoad = Building.SnowLoad;
            buildingSite = snowLoad.BuildingSite;
        }

        /// <summary>
        /// Method calculate shape coefficient for monopitch roof.
        /// </summary>
        private void CalculateSnowLoadShapeCoefficient()
        {
            ShapeCoefficient = ShapeCoefficientCalc.CalculateSnowLoadShapeCoefficient1(Slope, SnowFences);
        }

        /// <summary>
        /// Calculate snow load on roof.
        /// </summary>
        private void CalculateSnowLoadOnRoof()
        {
            if (!Building.SnowLoad.ExcepctionalSituation)
                SnowLoadOnRoofValue =
                    SnowLoadCalc.CalculateSnowLoad(
                        ShapeCoefficient,
                        Building.SnowLoad.BuildingSite.ExposureCoefficient,
                        Building.ThermalCoefficient,
                        Building.SnowLoad.SnowLoadForSpecificReturnPeriod);
            else
                SnowLoadOnRoofValue =
                    SnowLoadCalc.CalculateSnowLoad(
                        ShapeCoefficient,
                        Building.SnowLoad.BuildingSite.ExposureCoefficient,
                        Building.ThermalCoefficient,
                        Building.SnowLoad.DesignExceptionalSnowLoadForSpecificReturnPeriod);
        }

        #endregion // Methods
    }
}
