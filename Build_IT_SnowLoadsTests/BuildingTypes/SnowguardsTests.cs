using Build_IT_SnowLoads.BuildingTypes;
using NUnit.Framework;
using System;

namespace Build_IT_SnowLoadsTests.BuildingTypes
{
    [TestFixture()]
    public class SnowguardsTests
    {
        [Test()]
        [Description("Check constructor for the Snowguards.")]
        public void SnowguardsTest_Constructor_Success()
        {
            var snowguards = new Snowguards(10, 30, 0.9);
            Assert.IsNotNull(snowguards, "Snowguards should be created.");
            Assert.AreEqual(10, snowguards.Width,
                "Width should be set at construction time.");
            Assert.AreEqual(30, snowguards.Slope,
                "Slope should be set at construction time.");
            Assert.AreEqual(0.9, snowguards.SnowLoadOnRoofValue,
                "Snow load should be set at construction time.");
        }

        [Test()]
        [Description("Check calculations of snow loads for the Snowguards.")]
        public void SnowguardsTest_CalculateSnowLoad_Success()
        { 
            var snowguards = new Snowguards(10, 30, 0.9);

            snowguards.CalculateSnowLoad();
            Assert.AreEqual(4.5, Math.Round(snowguards.ForceExertedBySnow, 3),
                "Force exerted by snow is not calculated properly.");
        }
    }
}