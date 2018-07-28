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
    public class ExceptionalOverDoorOrLoadingBay : ICalculatable
    {
        #region Properties

        [Abbreviation("h")]
        public double HeightDifference { get; set; }
        
        private double widthAboveDoor;
        [Abbreviation("b_1")]
        public double WidthAboveDoor
        {
            get { return widthAboveDoor; }
            set {
                if (value > 5)
                    throw new ArgumentOutOfRangeException("Width shouldn't be over 5m");
                widthAboveDoor = value;
            }
        }

        [Abbreviation("b_2")]
        public double BuildingWidth { get; set; }

        [Abbreviation("mi_1")]
        public double ShapeCoefficient1 { get; private set; }

        [Abbreviation("l_s")]
        public double DriftLength { get; private set; }

        public double SnowLoad { get; private set; }

        public IBuilding Building { get; private set; }

        #endregion // Properties

        #region Fields

        private ISnowLoad snowLoad;

        #endregion // Fields

        #region Constructors

        public ExceptionalOverDoorOrLoadingBay(IBuilding building, double widthAboveDoor, double buildingWidth, double heightDifference)
        {
            Building = building;
            WidthAboveDoor = widthAboveDoor;
            BuildingWidth = buildingWidth;
            HeightDifference = heightDifference;
            SetReferences();
        }

        #endregion // Constructors

        #region Methods

        public void CalculateDriftLength()
        {
            if (HeightDifference > 1)
                DriftLength = WidthAboveDoor;
            else
                DriftLength = Math.Min(5 * HeightDifference, WidthAboveDoor);
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
            if (WidthAboveDoor <= 5)
                ShapeCoefficient1 = Math.Min(ShapeCoefficient1, 2 * Math.Max(WidthAboveDoor, BuildingWidth) / DriftLength);
        }

        private void CalculateSnowLoadOnRoof()
        {
            if (ConditionChecker.ForDesignSituation(snowLoad.ExcepctionalSituation, snowLoad.CurrentDesignSituation, true))
                SnowLoad = SnowLoadCalc.CalculateSnowLoadForAnnexB(ShapeCoefficient1, snowLoad.SnowLoadForSpecificReturnPeriod);
        }

        #endregion // Methods
    }
}
