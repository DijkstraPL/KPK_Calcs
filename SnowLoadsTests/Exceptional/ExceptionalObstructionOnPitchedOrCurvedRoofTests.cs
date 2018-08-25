using NUnit.Framework;
using SnowLoads.Tests;
using System;

namespace SnowLoads.Exceptional.Tests
{
    [TestFixture()]
    public class ExceptionalObstructionOnPitchedOrCurvedRoofTests
    {
        [Test()]
        [Description("Check constructor for the ExceptionalObstructionOnPitchedOrCurvedRoof.")]
        public void ExceptionalObstructionOnPitchedOrCurvedRoofTest_Constructor_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var exceptionalObstructionOnPitchedOrCurvedRoof =
                new ExceptionalObstructionOnPitchedOrCurvedRoof(building, 15, 20, 1, 0.5);

            Assert.IsNotNull(exceptionalObstructionOnPitchedOrCurvedRoof,
                "ExceptionalObstructionOnPitchedOrCurvedRoof should be created.");
            Assert.AreEqual(15, exceptionalObstructionOnPitchedOrCurvedRoof.LeftWidth,
                "Width should be set at construction time.");
            Assert.AreEqual(20, exceptionalObstructionOnPitchedOrCurvedRoof.RightWidth,
                "Width should be set at construction time.");
            Assert.AreEqual(1, exceptionalObstructionOnPitchedOrCurvedRoof.LeftHeightDifference,
                "Height should be set at construction time.");
            Assert.AreEqual(0.5, exceptionalObstructionOnPitchedOrCurvedRoof.RightHeightDifference,
                "Height should be set at construction time.");
        }

        [Test()]
        [Description("Check calculations of snow loads for the ExceptionalObstructionOnPitchedOrCurvedRoof.")]
        public void ExceptionalObstructionOnPitchedOrCurvedRoofTest_CalculateSnowLoad_Success()
        {
            var building = BuildingImplementation.CreateBuilding();
            building.SnowLoad.ExcepctionalSituation = true;
            building.SnowLoad.CurrentDesignSituation = DesignSituation.B2;

            var exceptionalObstructionOnPitchedOrCurvedRoof =
                new ExceptionalObstructionOnPitchedOrCurvedRoof(building, 15, 20, 1, 0.5);

            exceptionalObstructionOnPitchedOrCurvedRoof.CalculateSnowLoad();

            Assert.AreEqual(2, Math.Round(exceptionalObstructionOnPitchedOrCurvedRoof.LeftSnowLoad, 3),
                "Snow load for roof is not calculated properly.");
            Assert.AreEqual(1, Math.Round(exceptionalObstructionOnPitchedOrCurvedRoof.RightSnowLoad, 3),
                "Snow load for roof is not calculated properly.");
        }

        [Test()]
        [Description("Check calculations of drift length for the ExceptionalObstructionOnPitchedOrCurvedRoof.")]
        public void ExceptionalObstructionOnPitchedOrCurvedRoofTest_CalculateDriftLength_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var exceptionalObstructionOnPitchedOrCurvedRoof =
                new ExceptionalObstructionOnPitchedOrCurvedRoof(building, 15, 20, 1, 0.5);

            exceptionalObstructionOnPitchedOrCurvedRoof.CalculateDriftLength();
            Assert.AreEqual(5, Math.Round(exceptionalObstructionOnPitchedOrCurvedRoof.LeftDriftLength, 3),
                "Drift length for roof is not calculated properly.");
            Assert.AreEqual(2.5, Math.Round(exceptionalObstructionOnPitchedOrCurvedRoof.RightDriftLength, 3),
                "Drift length for roof is not calculated properly.");
        }
    }
}