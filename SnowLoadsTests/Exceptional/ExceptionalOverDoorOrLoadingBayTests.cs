using NUnit.Framework;
using SnowLoads.Exceptional;
using SnowLoads.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads.Exceptional.Tests
{
    [TestFixture()]
    public class ExceptionalOverDoorOrLoadingBayTests
    {
        [Test()]
        [Description("Check constructor for the ExceptionalOverDoorOrLoadingBay.")]
        public void ExceptionalOverDoorOrLoadingBayTest_Constructor_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var exceptionalOverDoorOrLoadingBay =
                new ExceptionalOverDoorOrLoadingBay(building, 3, 20, 1);

            Assert.IsNotNull(exceptionalOverDoorOrLoadingBay,
                "ExceptionalOverDoorOrLoadingBay should be created.");
            Assert.AreEqual(3, exceptionalOverDoorOrLoadingBay.WidthAboveDoor,
                "Width should be set at construction time.");
            Assert.AreEqual(20, exceptionalOverDoorOrLoadingBay.BuildingWidth,
                "Width should be set at construction time.");
            Assert.AreEqual(1, exceptionalOverDoorOrLoadingBay.HeightDifference,
                "Height should be set at construction time.");
        }

        [Test()]
        [Description("Check calculations of snow loads for the ExceptionalOverDoorOrLoadingBay.")]
        public void ExceptionalOverDoorOrLoadingBayTest_CalculateSnowLoad_Success()
        {
            var building = BuildingImplementation.CreateBuilding();
            building.SnowLoad.ExcepctionalSituation = true;
            building.SnowLoad.CurrentDesignSituation = DesignSituation.B2;

            var exceptionalOverDoorOrLoadingBay =
                new ExceptionalOverDoorOrLoadingBay(building, 3, 20, 1);

            exceptionalOverDoorOrLoadingBay.CalculateSnowLoad();

            Assert.AreEqual(2, Math.Round(exceptionalOverDoorOrLoadingBay.SnowLoad, 3),
                "Snow load for roof is not calculated properly.");
        }

        [Test()]
        [Description("Check calculations of drift length for the ExceptionalOverDoorOrLoadingBay.")]
        public void ExceptionalOverDoorOrLoadingBayTest_CalculateDriftLength_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var exceptionalOverDoorOrLoadingBay =
                new ExceptionalOverDoorOrLoadingBay(building, 3, 20, 1);

            exceptionalOverDoorOrLoadingBay.CalculateDriftLength();
            Assert.AreEqual(3, Math.Round(exceptionalOverDoorOrLoadingBay.DriftLength, 3),
                "Drift length for roof is not calculated properly.");
        }
    }
}