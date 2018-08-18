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
    public class RoofAbuttingToTallerConstructionTests
    {
        [Test()]
        [Description("Check constructor for the RoofAbuttingToTallerConstruction.")]
        public void RoofAbuttingToTallerConstructionTest_Constructor_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var roofAbuttingToTallerConstruction = new RoofAbuttingToTallerConstruction(building, 20, 10, 5, 
                new MonopitchRoof(building, 30));

            Assert.IsNotNull(roofAbuttingToTallerConstruction, "RoofAbuttingToTallerConstruction should be created.");
            Assert.AreEqual(20, roofAbuttingToTallerConstruction.WidthOfUpperBuilding, 
                "Width should be set at construction time.");
            Assert.AreEqual(10, roofAbuttingToTallerConstruction.WidthOfLowerBuilding, 
                "Width should be set at construction time.");
            Assert.AreEqual(5, roofAbuttingToTallerConstruction.HeightDifference, 
                "Height should be set at construction time.");
            Assert.IsNotNull(roofAbuttingToTallerConstruction.UpperRoof,
                "Upper roof should be set at construction time.");
            Assert.AreEqual(30, roofAbuttingToTallerConstruction.UpperRoof.Slope,
                "Slope should be set at construction time.");
        }

        [Test()]
        [Description("Check calculations of snow loads for the RoofAbuttingToTallerConstruction.")]
        public void RoofAbuttingToTallerConstructionTest_CalculateSnowLoad_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var roofAbuttingToTallerConstruction = new RoofAbuttingToTallerConstruction(building, 20, 10, 5,
                new MonopitchRoof(building, 30));

            roofAbuttingToTallerConstruction.CalculateSnowLoad();
            Assert.AreEqual(3.024, Math.Round(roofAbuttingToTallerConstruction.SnowLoadOnRoofValue, 3),
                "Snow load near the taller construction is not calculated properly.");
            Assert.AreEqual(0.72, Math.Round(roofAbuttingToTallerConstruction.SnowLoadOnRoofValueAtTheEnd, 3),
                "Snow load at the end of drifting length is not calculated properly.");
        }

        [Test()]
        [Description("Check calculations of drift length for the RoofAbuttingToTallerConstruction.")]
        public void RoofAbuttingToTallerConstructionTest_CalculateDriftLength_Success()
        {
            var building = BuildingImplementation.CreateBuilding();
            
            var roofAbuttingToTallerConstruction = new RoofAbuttingToTallerConstruction(building, 20, 10, 5,
                new MonopitchRoof(building, 30));

            roofAbuttingToTallerConstruction.CalculateDriftLength();
            Assert.AreEqual(10, Math.Round(roofAbuttingToTallerConstruction.DriftLength, 3),
                "Drift length for roof is not calculated properly.");
        }        
    }
}