using NUnit.Framework;
using SnowLoads.Tests;
using System;

namespace SnowLoads.BuildingTypes.Tests
{
    [TestFixture()]
    public class PitchedRoofTests
    {
        [Test()]
        [Description("Check constructor for the pitechedRoof.")]
        public void PitchedRoofTest_Constructor_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var pitchedRoof = new PitchedRoof(building, 
                new MonopitchRoof(building, 45),
                new MonopitchRoof(building, 15));
            Assert.IsNotNull(pitchedRoof, "PitchedRoof should be created.");
            Assert.AreEqual(45, pitchedRoof.LeftRoof.Slope, "Slope should be set at construction time.");
            Assert.AreEqual(15, pitchedRoof.RightRoof.Slope, "Slope should be set at construction time.");
        }

        [Test()]
        [Description("Check calculations of snow loads for the pitechedRoof.")]
        public void PitchedRoofTest_CalculateSnowLoad_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var pitchedRoof = new PitchedRoof(building,
               new MonopitchRoof(building, 45),
               new MonopitchRoof(building, 15));

            pitchedRoof.CalculateSnowLoad();
            Assert.AreEqual(0.36, Math.Round(pitchedRoof.LeftRoof.SnowLoadOnRoofValue, 3), 
                "Snow load for left roof is not calculated properly.");
            Assert.AreEqual(0.72, Math.Round(pitchedRoof.RightRoof.SnowLoadOnRoofValue, 3), 
                "Snow load for right roof is not calculated properly.");
        }
        
        [Test()]
        [Description("Example number 1 from \"Obciążenia budynków i konstrukcji budowlanych według Eurokodów\" - Anna Rawska-Skotniczy")]
        public void ExampleTest1_CalculateSnowLoad_Success()
        {
            var buildingSite = new BuildingSite(ZoneEnum.FirstZone, TopographyEnum.Normal, 127);
            buildingSite.CalculateExposureCoefficient();
            var snowLoad = new SnowLoad(buildingSite);
            snowLoad.CalculateSnowLoad();
            var building = new Building(snowLoad);
            building.CalculateThermalCoefficient();

            var pitchedRoof = new PitchedRoof(building, 35, 5);

            pitchedRoof.CalculateSnowLoad();
            Assert.AreEqual(0.467, Math.Round(pitchedRoof.LeftRoof.SnowLoadOnRoofValue, 3),
                "Snow load for left roof is not calculated properly.");
            Assert.AreEqual(0.56, Math.Round(pitchedRoof.RightRoof.SnowLoadOnRoofValue, 3),
                "Snow load for right roof is not calculated properly.");
        }
    }
}