using Build_IT_SnowLoads;
using Build_IT_SnowLoads.Exceptional;
using NUnit.Framework;
using System;

namespace Build_IT_SnowLoadsTests.Exceptional
{
    [TestFixture()]
    public class ExceptionalObstructionOnFlatRoofTests
    {
        [Test()]
        [Description("Check constructor for the ExceptionalObstructionOnFlatRoof.")]
        public void ExceptionalObstructionOnFlatRoofTest_Constructor_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var exceptionalObstructionOnFlatRoof =
                new ExceptionalObstructionOnFlatRoof(building, 15, 20, 1, 0.5);

            Assert.IsNotNull(exceptionalObstructionOnFlatRoof,
                "ExceptionalObstructionOnFlatRoof should be created.");
            Assert.AreEqual(15, exceptionalObstructionOnFlatRoof.LeftWidth,
                "Width should be set at construction time.");
            Assert.AreEqual(20, exceptionalObstructionOnFlatRoof.RightWidth,
                "Width should be set at construction time.");
            Assert.AreEqual(1, exceptionalObstructionOnFlatRoof.LeftHeightDifference,
                "Height should be set at construction time.");
            Assert.AreEqual(0.5, exceptionalObstructionOnFlatRoof.RightHeightDifference,
                "Height should be set at construction time.");
        }

        [Test()]
        [Description("Check calculations of snow loads for the ExceptionalObstructionOnFlatRoof.")]
        public void ExceptionalObstructionOnFlatRoofTest_CalculateSnowLoad_Success()
        {
            var building = BuildingImplementation.CreateBuilding();
            building.SnowLoadImplementation.ExcepctionalSituation = true;
            building.SnowLoadImplementation.CurrentDesignSituation = DesignSituation.B2;

            var exceptionalObstructionOnFlatRoof =
                new ExceptionalObstructionOnFlatRoof(building, 15, 20, 1, 0.5);

            exceptionalObstructionOnFlatRoof.CalculateSnowLoad();

            Assert.AreEqual(2, Math.Round(exceptionalObstructionOnFlatRoof.LeftSnowLoad, 3),
                "Snow load for roof is not calculated properly.");
            Assert.AreEqual(1, Math.Round(exceptionalObstructionOnFlatRoof.RightSnowLoad, 3),
                "Snow load for roof is not calculated properly.");
        }

        [Test()]
        [Description("Check calculations of drift length for the ExceptionalObstructionOnFlatRoof.")]
        public void ExceptionalObstructionOnFlatRoofTest_CalculateDriftLength_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var exceptionalObstructionOnFlatRoof =
                new ExceptionalObstructionOnFlatRoof(building, 15, 20, 1, 0.5);

            exceptionalObstructionOnFlatRoof.CalculateDriftLength();
            Assert.AreEqual(5, Math.Round(exceptionalObstructionOnFlatRoof.LeftDriftLength, 3),
                "Drift length for roof is not calculated properly.");
            Assert.AreEqual(2.5, Math.Round(exceptionalObstructionOnFlatRoof.RightDriftLength, 3),
                "Drift length for roof is not calculated properly.");
        }
    }
}