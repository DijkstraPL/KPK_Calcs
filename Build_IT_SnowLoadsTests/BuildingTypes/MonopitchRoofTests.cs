using Build_IT_SnowLoads;
using Build_IT_SnowLoads.BuildingTypes;
using Build_IT_SnowLoads.Enums;
using Build_IT_SnowLoads.Interfaces;
using Moq;
using NUnit.Framework;
using System;

namespace Build_IT_SnowLoadsTests.BuildingTypes
{
    [TestFixture()]
    public class MonopitchRoofTests
    {
        [Test()]
        public void MonopitchRoofTest_Constructor_MinusValues_Success()
        {
            var building = new Mock<IBuilding>();
            Assert.Throws<ArgumentOutOfRangeException>(()
                => new MonopitchRoof(building.Object, -20));
        }

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

        [Test()]
        [Description("Example number 2 from \"Obciążenia budynków i konstrukcji budowlanych według Eurokodów\" - Anna Rawska-Skotniczy")]
        public void ExampleTest2_CalculateSnowLoad_Success()
        {
            var buildingSite = new BuildingSite(Zones.ThirdZone, Topographies.Normal, 360);
            var snowLoad = new SnowLoad(buildingSite);
            var building = new Building(snowLoad);

            var monopitchRoof = new MonopitchRoof(building, 5);

            buildingSite.CalculateExposureCoefficient();
            snowLoad.CalculateSnowLoad();
            building.CalculateThermalCoefficient();
            monopitchRoof.CalculateSnowLoad();
            Assert.AreEqual(1.248, Math.Round(monopitchRoof.SnowLoadOnRoofValue, 3),
                "Snow load for roof is not calculated properly.");
        }

        [Test()]
        [Description("Example number 4 from \"Obciążenia budynków i konstrukcji budowlanych według Eurokodów\" - Anna Rawska-Skotniczy")]
        public void ExampleTest4_CalculateSnowLoad_Success()
        {
            var buildingSite = new BuildingSite(Zones.SecondZone, Topographies.Normal, altitudeAboveSea: 175);
            var snowLoad = new SnowLoad(buildingSite);
            var building = new Building(snowLoad);
            var monopitchRoof = new MonopitchRoof(building, 10);

            buildingSite.CalculateExposureCoefficient();
            snowLoad.CalculateSnowLoad();
            building.CalculateThermalCoefficient();
            monopitchRoof.CalculateSnowLoad();
            Assert.AreEqual(0.72, Math.Round(monopitchRoof.SnowLoadOnRoofValue, 3),
                "Snow load is not calculated properly.");
        }
    }
}