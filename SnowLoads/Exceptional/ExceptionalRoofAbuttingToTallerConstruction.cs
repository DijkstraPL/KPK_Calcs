using SnowLoads.API;
using SnowLoads.BuildingTypes;
using SnowLoads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads.Exceptional
{
    public class ExceptionalRoofAbuttingToTallerConstruction : ICalculatable
    {
        #region Properties

        [Abbreviation("h")]
        public double HeightDifference { get; set; }

        [Abbreviation("l_s")]
        public double DriftLength { get; private set; }

        [Abbreviation("b_1")]
        public double LowerBuildingWidth { get; set; }

        [Abbreviation("b_2")]
        public double UpperBuildingWidth { get; set; }

        [Abbreviation("mi_1")]
        public double ShapeCoefficient1 { get; private set; }
        [Abbreviation("mi_2")]
        public double ShapeCoefficient2 { get; private set; }
        [Abbreviation("mi_3")]
        public double ShapeCoefficient3 { get; private set; }

        public double SnowLoad1 { get; private set; }
        public double SnowLoad2 { get; private set; }

        [Abbreviation("alfa")]
        public double Angle { get; set; }

        public Building Building { get; private set; }

        #endregion // Properties

        #region Fields

        private SnowLoad snowLoad;

        #endregion // Fields

        #region Constructors

        public ExceptionalRoofAbuttingToTallerConstruction(Building building, double upperBuildingWidth, double lowerBuildingWidth,
            double heightDifference, double angle)
        {
            Building = building;
            UpperBuildingWidth = upperBuildingWidth;
            LowerBuildingWidth = lowerBuildingWidth;
            HeightDifference = heightDifference;
            Angle = angle;
            SetReferences();
        }

        #endregion // Constructors

        #region Methods

        public void CalculateDriftLength()
        {
            DriftLength = Math.Min(5 * HeightDifference, LowerBuildingWidth);

            DriftLength = Math.Min(DriftLength, 15);
        }

        public void CalculateSnowLoad()
        {
            CalculateShapeCoefficient1();
            CalculateShapeCoefficient2();
            CalculateShapeCoefficient3();
            CalculateSnowLoad1();
            CalculateSnowLoad2();
        }

        private void SetReferences()
        {
            snowLoad = Building.SnowLoad;
        }

        private void CalculateShapeCoefficient1()
        {
            if (Angle < 0)
                throw new ArgumentOutOfRangeException("Angle shouldn't be less than 0.");
            else if (Angle <= 15)
                ShapeCoefficient1 = ShapeCoefficient3;
            else if (Angle <= 30)
                ShapeCoefficient1 = ShapeCoefficient3 * ((30 - Angle) / 15);
            else
                ShapeCoefficient1 = 0;
        }

        private void CalculateShapeCoefficient2()
        {
            if (Angle < 0)
                throw new ArgumentOutOfRangeException("Angle shouldn't be less than 0.");
            else if (Angle <= 30)
                ShapeCoefficient2 = ShapeCoefficient3;
            else if (Angle <= 60)
                ShapeCoefficient2 = ShapeCoefficient3 * ((60 - Angle) / 30);
            else
                ShapeCoefficient2 = 0;
        }

        private void CalculateShapeCoefficient3()
        {
            ShapeCoefficient3 = Math.Min(
                2 * HeightDifference / snowLoad.SnowLoadForSpecificReturnPeriod,
                2 * Math.Max(LowerBuildingWidth, UpperBuildingWidth) / DriftLength);

            ShapeCoefficient3 = Math.Min(ShapeCoefficient3, 8);
        }

        private void CalculateSnowLoad1()
        {
            if (ConditionChecker.ForDesignSituation(snowLoad.ExcepctionalSituation, snowLoad.CurrentDesignSituation, true))
                SnowLoad1 = SnowLoadCalc.CalculateSnowLoadForAnnexB(ShapeCoefficient1, snowLoad.SnowLoadForSpecificReturnPeriod);
        }
        
        private void CalculateSnowLoad2()
        {
            if (ConditionChecker.ForDesignSituation(snowLoad.ExcepctionalSituation, snowLoad.CurrentDesignSituation, true))
                SnowLoad2 = SnowLoadCalc.CalculateSnowLoadForAnnexB(ShapeCoefficient2, snowLoad.SnowLoadForSpecificReturnPeriod);
        }

        #endregion // Methods
    }
}
