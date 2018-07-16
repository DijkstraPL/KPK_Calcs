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
    public class ExceptionalOverDoorOrLoadingBay : ICalculatable
    {
        #region Properties

        [Abbreviation("h")]
        public double HeightDifference { get; set; }
        
        private double width1;
        [Abbreviation("b_1")]
        public double Width1
        {
            get { return width1; }
            set {
                if (value > 5)
                    throw new ArgumentOutOfRangeException("Width shouldn't be over 5m");
                width1 = value;
            }
        }

        [Abbreviation("b_2")]
        public double Width2 { get; set; }

        [Abbreviation("mi_1")]
        public double ShapeCoefficient1 { get; private set; }

        [Abbreviation("l_s")]
        public double DriftLength { get; private set; }

        public double SnowLoad1 { get; private set; }
        public double SnowLoad2 { get; private set; }

        public IBuilding Building { get; private set; }

        #endregion // Properties

        #region Fields

        private ISnowLoad snowLoad;

        #endregion // Fields

        #region Constructors

        public ExceptionalOverDoorOrLoadingBay(IBuilding building, double width1, double width2, double heightDifference)
        {
            Building = building;
            Width1 = width1;
            Width2 = width2;
            HeightDifference = heightDifference;
            SetReferences();
        }

        #endregion // Constructors

        #region Methods

        public void CalculateDriftLength()
        {
            if (HeightDifference > 1)
                DriftLength = Width1;
            else
                DriftLength = Math.Min(5 * HeightDifference, Width1);
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
            ShapeCoefficient1 = Math.Min(2 * HeightDifference / snowLoad.SnowLoadForSpecificReturnPeriod, 5);
            if (Width1 <= 5)
                ShapeCoefficient1 = Math.Min(ShapeCoefficient1, 2 * Math.Max(Width1, Width2) / DriftLength);
        }

        private void CalculateSnowLoadOnRoof()
        {
            if (ConditionChecker.ForDesignSituation(snowLoad.ExcepctionalSituation, snowLoad.CurrentDesignSituation, true))
                SnowLoad1 = SnowLoadCalc.CalculateSnowLoadForAnnexB(ShapeCoefficient1, snowLoad.SnowLoadForSpecificReturnPeriod);
        }

        #endregion // Methods
    }
}
