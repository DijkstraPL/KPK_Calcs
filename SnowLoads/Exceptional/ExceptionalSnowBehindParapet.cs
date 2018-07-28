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
    public class ExceptionalSnowBehindParapet : ICalculatable
    {
        #region Properties

        [Abbreviation("h_1")]
        public double HeightDifference { get; set; }

        [Abbreviation("b_1")]
        public double Width { get; set; }

        [Abbreviation("mi_1")]
        public double ShapeCoefficient { get; private set; }

        [Abbreviation("l_s")]
        public double DriftLength { get; private set; }

        public double SnowLoad { get; private set; }

        public IBuilding Building { get; private set; }

        #endregion // Properties

        #region Fields

        private ISnowLoad snowLoad;

        #endregion // Fields

        #region Constructors

        public ExceptionalSnowBehindParapet(IBuilding building, double width, double heightDifference)
        {
            Building = building;
            Width = width;
            HeightDifference = heightDifference;

            SetReferences();
        }

        #endregion // Coonstructors

        #region Methods

        public void CalculateDriftLength()
        {
            DriftLength = Math.Min(5 * HeightDifference, Width);
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
            ShapeCoefficient = Math.Min(2 * HeightDifference / snowLoad.SnowLoadForSpecificReturnPeriod, 8);
            ShapeCoefficient = Math.Min(ShapeCoefficient, 2 * Width / DriftLength);
        }

        private void CalculateSnowLoadOnRoof()
        {
            if (ConditionChecker.ForDesignSituation(snowLoad.ExcepctionalSituation, snowLoad.CurrentDesignSituation, true))
                SnowLoad = SnowLoadCalc.CalculateSnowLoadForAnnexB(ShapeCoefficient, snowLoad.SnowLoadForSpecificReturnPeriod);
        }

        #endregion // Methods
    }
}
