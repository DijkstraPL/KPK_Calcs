using Build_IT_SnowLoads;
using Build_IT_SnowLoads.Exceptional;
using NUnit.Framework;
using System;

namespace Build_IT_SnowLoadsTests.Exceptional
{
    [TestFixture()]
    public class ExceptionalMultiSpanRoofTests
    {
        [Test()]
        [Description("Check constructor for the ExceptionalMultiSpanRoof.")]
        public void ExceptionalMultiSpanRoofTest_Constructor_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var exceptionalMultiSpanRoof = new ExceptionalMultiSpanRoof(building, 10, 5, 2);

            Assert.IsNotNull(exceptionalMultiSpanRoof, "MultiSpan should be created.");
            Assert.AreEqual(10, exceptionalMultiSpanRoof.LeftDriftLength,
                "Drift length should be set at construction time.");
            Assert.AreEqual(5, exceptionalMultiSpanRoof.RightDriftLength,
                "Drift length should be set at construction time.");
            Assert.AreEqual(2, exceptionalMultiSpanRoof.HeightInTheLowestPart,
                "Height should be set at construction time.");         
        }

        [Test()]
        [Description("Check calculations of snow loads for the ExceptionalMultiSpanRoof.")]
        public void ExceptionalMultiSpanRoofTest_CalculateSnowLoad_Success()
        {
            var building = BuildingImplementation.CreateBuilding();
            building.SnowLoad.ExcepctionalSituation = true;
            building.SnowLoad.CurrentDesignSituation = DesignSituation.B2;

            var exceptionalMultiSpanRoof = new ExceptionalMultiSpanRoof(building, 10, 5, 2);

            exceptionalMultiSpanRoof.CalculateSnowLoad();
            Assert.AreEqual(2.7, Math.Round(exceptionalMultiSpanRoof.SnowLoad, 3),
                "Snow load between roofs is not calculated properly.");
        }
    }
}