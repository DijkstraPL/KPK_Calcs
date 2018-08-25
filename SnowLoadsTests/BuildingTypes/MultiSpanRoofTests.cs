using NUnit.Framework;
using SnowLoads.Tests;
using System;

namespace SnowLoads.BuildingTypes.Tests
{
    [TestFixture()]
    public class MultiSpanRoofTests
    {
        [Test()]
        [Description("Check constructor for the MultiSpanRoof.")]
        public void MultiSpanRoofTest_Constructor_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var multiSpanRoof = new MultiSpanRoof(building,
                new MonopitchRoof(building, 45),
                new MonopitchRoof(building, 15));
            Assert.IsNotNull(multiSpanRoof, "MultiSpanRoof should be created.");
            Assert.AreEqual(45, multiSpanRoof.LeftRoof.Slope, "Slope should be set at construction time.");
            Assert.AreEqual(15, multiSpanRoof.RightRoof.Slope, "Slope should be set at construction time.");
        }

        [Test()]
        [Description("Check calculations of snow loads for the MultiSpanRoof.")]
        public void MultiSpanRoofTest_CalculateSnowLoad_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var multiSpanRoof = new MultiSpanRoof(building,
               new MonopitchRoof(building, 45),
               new MonopitchRoof(building, 15));

            multiSpanRoof.CalculateSnowLoad();
            Assert.AreEqual(0.36, Math.Round(multiSpanRoof.LeftRoof.SnowLoadOnRoofValue, 3),
                "Snow load for left roof is not calculated properly.");
            Assert.AreEqual(0.72, Math.Round(multiSpanRoof.RightRoof.SnowLoadOnRoofValue, 3),
                "Snow load for right roof is not calculated properly.");
            Assert.AreEqual(1.44, Math.Round(multiSpanRoof.SnowLoadOnMiddleRoof, 3),
                "Snow load for middle roof is not calculated properly.");
        }
    }
}