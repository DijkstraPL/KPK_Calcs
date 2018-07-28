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
    public class ExceptionalObstructionOnPitchedOrCurvedRoof : ICalculatable
    {
        #region Properties

        [Abbreviation("h_1")]
        public double LeftHeightDifference { get; set; }
        [Abbreviation("h_2")]
        public double RightHeightDifference { get; set; }

        [Abbreviation("b_1")]
        public double LeftWidth { get; set; }
        [Abbreviation("b_2")]
        public double RightWidth { get; set; }

        [Abbreviation("mi_1")]
        public double LeftShapeCoefficient { get; private set; }
        [Abbreviation("mi_2")]
        public double RightShapeCoefficient { get; private set; }

        [Abbreviation("l_s1")]
        public double LeftDriftLength { get; private set; }
        [Abbreviation("l_s2")]
        public double RightDriftLength { get; private set; }

        public double LeftSnowLoad { get; private set; }
        public double RightSnowLoad { get; private set; }

        public IBuilding Building { get; private set; }

        #endregion // Properties

        #region Fields

        private ISnowLoad snowLoad;

        #endregion // Fields

        #region Constructors

        public ExceptionalObstructionOnPitchedOrCurvedRoof(IBuilding building, double leftWidth, double rightWidth, 
            double leftHeightDifference, double rightHeightDifference)
        {
            Building = building;
            LeftWidth = leftWidth;
            RightWidth = rightWidth;
            LeftHeightDifference = leftHeightDifference;
            RightHeightDifference = rightHeightDifference;
            SetReferences();
        }

        #endregion // Constructors

        #region Methods

        public void CalculateDriftLength()
        {
            if (LeftHeightDifference > 1)
                LeftDriftLength = LeftWidth;
            else
                LeftDriftLength = Math.Min(5 * LeftHeightDifference, LeftWidth);

            if (RightHeightDifference > 1)
                RightDriftLength = RightWidth;
            else
                RightDriftLength = Math.Min(5 * RightHeightDifference, RightWidth);
        }

        public void CalculateSnowLoad()
        {
            CalculateShapeCoefficient();
            CalculateSnowLoad1();
            CalculateSnowLoad2();
        }

        private void SetReferences()
        {
            snowLoad = Building.SnowLoad;
        }

        private void CalculateShapeCoefficient()
        {
            LeftShapeCoefficient = Math.Min(2 * LeftHeightDifference / snowLoad.SnowLoadForSpecificReturnPeriod, 5);
            RightShapeCoefficient = Math.Min(2 * RightHeightDifference / snowLoad.SnowLoadForSpecificReturnPeriod, 5);
        }

        private void CalculateSnowLoad1()
        {
            if (ConditionChecker.ForDesignSituation(snowLoad.ExcepctionalSituation, snowLoad.CurrentDesignSituation, true))
                LeftSnowLoad = SnowLoadCalc.CalculateSnowLoadForAnnexB(LeftShapeCoefficient, snowLoad.SnowLoadForSpecificReturnPeriod);
        }
        private void CalculateSnowLoad2()
        {
            if (ConditionChecker.ForDesignSituation(snowLoad.ExcepctionalSituation, snowLoad.CurrentDesignSituation, true))
                RightSnowLoad = SnowLoadCalc.CalculateSnowLoadForAnnexB(RightShapeCoefficient, snowLoad.SnowLoadForSpecificReturnPeriod);
        }


        #endregion // Methods
    }
}
