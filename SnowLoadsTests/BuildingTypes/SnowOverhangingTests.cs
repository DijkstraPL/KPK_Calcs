using NUnit.Framework;
using SnowLoads.BuildingTypes;
using SnowLoads.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads.BuildingTypes.Tests
{
    [TestFixture()]
    public class SnowOverhangingTests
    {
        [Test()]
        [Description("Check constructor for the snowOverhanging.")]
        public void SnowOverhangingTest_Constructor_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var snowOverhanging = new SnowOverhanging(building, 0.2, 0.72);
            Assert.IsNotNull(snowOverhanging, "SnowOverhanging should be created.");
            Assert.AreEqual(0.2, snowOverhanging.SnowLayerDepth,
                "Snow layer should be set at construction time.");
            Assert.AreEqual(0.72, snowOverhanging.SnowLoadOnRoofValue,
                "Snow load should be set at construction time.");
        }

        [Test()]
        [Description("Check calculations of snow loads for the snowOverhanging.")]
        public void SnowOverhangingTest_CalculateSnowLoad_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var snowOverhanging = new SnowOverhanging(building, 0.2, 0.72);

            snowOverhanging.CalculateSnowLoad();
            Assert.AreEqual(0.104, Math.Round(snowOverhanging.SnowLoad, 3),
                "Snow load is not calculated properly.");
        }
    }
}