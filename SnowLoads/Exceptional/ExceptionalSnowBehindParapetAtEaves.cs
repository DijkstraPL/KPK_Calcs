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
    public class ExceptionalSnowBehindParapetAtEaves : ICalculatable
    {
        #region Properties

        [Abbreviation("h_1")]
        public double HeightDifference { get; set; }

        [Abbreviation("b_1")]
        public double Width1 { get; set; }
        [Abbreviation("b_2")]
        public double Width2 { get; set; }

        [Abbreviation("mi_1")]
        public double ShapeCoefficient1 { get; private set; }

        [Abbreviation("l_s")]
        public double DriftLength { get; private set; }

        public double SnowLoad { get; private set; }

        public Building Building { get; private set; }

        #endregion // Properties

        #region Fields

        private SnowLoad snowLoad;

        #endregion // Fields

        #region Constructors

        public ExceptionalSnowBehindParapetAtEaves(Building building, double width1, double width2, double heightDifference)
        {
            Building = building;
            Width1 = width1;
            Width2 = width2;
            HeightDifference = heightDifference;
            SetReferences();
        }

        #endregion // Constructors

        public void CalculateDriftLength()
        {
            DriftLength = Math.Min(5 * HeightDifference, Width1);
            DriftLength = Math.Min(DriftLength, 15);
        }

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
            ShapeCoefficient1 = Math.Min(2 * HeightDifference / snowLoad.SnowLoadForSpecificReturnPeriod, 8);
            ShapeCoefficient1 = Math.Min(ShapeCoefficient1, 2 * Math.Max(Width1,Width2) / DriftLength);
        }

        private void CalculateSnowLoadOnRoof()
        {
            if (ConditionChecker.ForDesignSituation(snowLoad.ExcepctionalSituation, snowLoad.CurrentDesignSituation, true))
                SnowLoad = SnowLoadCalc.CalculateSnowLoadForAnnexB(ShapeCoefficient1, snowLoad.SnowLoadForSpecificReturnPeriod);
        }

    }
}
