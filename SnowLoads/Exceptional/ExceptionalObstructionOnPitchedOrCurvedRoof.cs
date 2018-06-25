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
    public class ExceptionalObstructionOnPitchedOrCurvedRoof : ICalculatable
    {
        #region Properties

        [Abbreviation("h_1")]
        public double HeightDifference1 { get; set; }
        [Abbreviation("h_2")]
        public double HeightDifference2 { get; set; }

        [Abbreviation("b_1")]
        public double Width1 { get; set; }
        [Abbreviation("b_2")]
        public double Width2 { get; set; }

        [Abbreviation("mi_1")]
        public double ShapeCoefficient1 { get; private set; }
        [Abbreviation("mi_2")]
        public double ShapeCoefficient2 { get; private set; }

        [Abbreviation("l_s1")]
        public double DriftLength_1 { get; private set; }
        [Abbreviation("l_s2")]
        public double DriftLength_2 { get; private set; }

        public double SnowLoad1 { get; private set; }
        public double SnowLoad2 { get; private set; }

        public Building Building { get; private set; }

        #endregion // Properties

        #region Fields

        private SnowLoad snowLoad;

        #endregion // Fields

        #region Constructors

        public ExceptionalObstructionOnPitchedOrCurvedRoof(Building building, double width1, double width2, double heightDifference1, double heightDifference2)
        {
            Building = building;
            Width1 = width1;
            Width2 = width2;
            HeightDifference1 = heightDifference1;
            HeightDifference2 = heightDifference2;
            SetReferences();
        }

        #endregion // Constructors

        #region Methods

        public void CalculateDriftLength()
        {
            if (HeightDifference1 > 1)
                DriftLength_1 = Width1;
            else
                DriftLength_1 = Math.Min(5 * HeightDifference1, Width1);

            if (HeightDifference2 > 1)
                DriftLength_2 = Width2;
            else
                DriftLength_2 = Math.Min(5 * HeightDifference2, Width2);
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
            ShapeCoefficient1 = Math.Min(2 * HeightDifference1 / snowLoad.SnowLoadForSpecificReturnPeriod, 5);
            ShapeCoefficient2 = Math.Min(2 * HeightDifference2 / snowLoad.SnowLoadForSpecificReturnPeriod, 5);
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
