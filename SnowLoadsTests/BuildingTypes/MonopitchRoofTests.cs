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
    public class MonopitchRoofTests
    {
        [Test()]
        [Description("Check constructor for the monopitchRoof.")]
        public void MonopitchRoofTest_Constructor_Success()
        {
            var monopitchRoof = new MonopitchRoof(new BuildingImplementation()
            { SnowLoad = new SnowLoadImplementation() }, 15);
            Assert.IsNotNull(monopitchRoof, "MonopitchRoof should be created.");
            Assert.AreEqual(15, monopitchRoof.Slope, "Slope should be set at construction time.");
        }

        [Test()]
        [Description("Check calculations of snow loads for the monopitchRoof.")]
        public void MonopitchRoofTest_CalculateSnowLoad_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var monopitchRoof = new MonopitchRoof(building, 15);

            monopitchRoof.CalculateSnowLoad();
            Assert.AreEqual(0.72, Math.Round(monopitchRoof.SnowLoadOnRoofValue, 3), "Snow load is not calculated properly.");
        }

    }
}