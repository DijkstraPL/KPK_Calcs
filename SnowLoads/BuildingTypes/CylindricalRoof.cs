using SnowLoads.API;
using SnowLoads.Interfaces;
using System;
using System.Collections.Generic;

namespace SnowLoads.BuildingTypes
{
    /// <summary>
    /// Calculation class for cylindrical roof.
    /// </summary>
    public class CylindricalRoof : ICalculatable, ILengthProvider
    {
        #region Properties

        /// <summary>
        /// Width of the roof.
        /// </summary>
        [Abbreviation("b")]
        public double Width { get; set; }

        /// <summary>
        /// Height of the roof.
        /// </summary>
        [Abbreviation("h")]
        public double Height { get; set; }

        /// <summary>
        /// Length of the load.
        /// </summary>
        [Abbreviation("l_s")]
        public double DriftLength { get; private set; }

        /// <summary>
        /// Snow load shape coefficient.
        /// </summary>
        [Abbreviation("mi_3")]
        public double ShapeCoefficient { get; private set; }

        /// <summary>
        /// Snow load on the roof [kN/m2]
        /// </summary>
        [Abbreviation("s")]
        public double SnowLoadOnRoofValue { get; private set; }

        /// <summary>
        /// Snow load on roof for all cases.
        /// </summary>
        public Dictionary<int, double> RoofCasesSnowLoad { get; private set; }

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
        /// Constructor for the cylindrical roof.
        /// </summary>
        /// <param name="building">Instance of a building</param>
        /// <param name="width">Width of the roof.</param>
        /// <param name="height">Height of the roof.</param>
        public CylindricalRoof(IBuilding building, double width, double height)
        {
            RoofCasesSnowLoad = new Dictionary<int, double>();

            Building = building;
            Width = width;
            Height = height;
            SetReferences();
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Calculate range of the load.
        /// </summary>
        public void CaluclateDriftLength()
        {
            DriftLength = Math.Min((Math.Pow(Width, 2) + 4 * Math.Pow(Height, 2)) / (8 * Height) * Math.Sqrt(3), Width);
        }

        /// <summary>
        /// Calculate Snow Load On Roof 
        /// </summary>
        public void CalculateSnowLoad()
        {
            CalculateSnowLoadShapeCoefficient();
            CalculateSnowLoadOnRoof();
            SetCasesSnowLoad();
        }

        public void SetCasesSnowLoad()
        {
            RoofCasesSnowLoad.Clear();

            double snowLoad = CalculateSnowLoadOnRoof(0.8);
            RoofCasesSnowLoad.Add(1, snowLoad);
            RoofCasesSnowLoad.Add(2, SnowLoadOnRoofValue * 0.5);
            RoofCasesSnowLoad.Add(3, SnowLoadOnRoofValue);
        }

        private void SetReferences()
        {
            snowLoad = Building.SnowLoad;
            buildingSite = snowLoad.BuildingSite;
        }

        /// <summary>
        /// Calculate shape coefficient for cylindrical roof.
        /// </summary>
        private void CalculateSnowLoadShapeCoefficient()
        {
            ShapeCoefficient = 0.2 + 10 * Height / Width;
            if (ShapeCoefficient > 2)
                ShapeCoefficient = 2;
        }

        /// <summary>
        /// Calculate snow load on roof.
        /// </summary>
        private void CalculateSnowLoadOnRoof()
        {
            if (!snowLoad.ExcepctionalSituation)
                SnowLoadOnRoofValue =
                    SnowLoadCalc.CalculateSnowLoad(
                        ShapeCoefficient,
                        buildingSite.ExposureCoefficient,
                        Building.ThermalCoefficient,
                        snowLoad.SnowLoadForSpecificReturnPeriod);
            else
                SnowLoadOnRoofValue =
                    SnowLoadCalc.CalculateSnowLoad(
                        ShapeCoefficient,
                        buildingSite.ExposureCoefficient,
                        Building.ThermalCoefficient,
                        snowLoad.DesignExceptionalSnowLoadForSpecificReturnPeriod);
        }

        /// <summary>
        /// Calculate snow load on roof.
        /// </summary>
        private double CalculateSnowLoadOnRoof(double shapeCoefficient)
        {
            if (!snowLoad.ExcepctionalSituation)
                return SnowLoadCalc.CalculateSnowLoad(
                        shapeCoefficient,
                        buildingSite.ExposureCoefficient,
                        Building.ThermalCoefficient,
                        snowLoad.SnowLoadForSpecificReturnPeriod);
            else
                return SnowLoadCalc.CalculateSnowLoad(
                        shapeCoefficient,
                        buildingSite.ExposureCoefficient,
                        Building.ThermalCoefficient,
                        snowLoad.DesignExceptionalSnowLoadForSpecificReturnPeriod);
        }

        #endregion // Methods
    }
}
