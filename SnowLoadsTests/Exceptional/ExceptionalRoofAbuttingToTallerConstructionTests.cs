using NUnit.Framework;
using SnowLoads.Exceptional;
using SnowLoads.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads.Exceptional.Tests
{
    [TestFixture()]
    public class ExceptionalRoofAbuttingToTallerConstructionTests
    {
        [Test()]
        [Description("Check constructor for the ExceptionalRoofAbuttingToTallerConstruction.")]
        public void ExceptionalRoofAbuttingToTallerConstructionTest_Constructor_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var exceptionalRoofAbuttingToTallerConstruction = 
                new ExceptionalRoofAbuttingToTallerConstruction(building, 20, 10, 3, 15);

            Assert.IsNotNull(exceptionalRoofAbuttingToTallerConstruction, 
                "ExceptionalRoofAbuttingToTallerConstruction should be created.");
            Assert.AreEqual(20, exceptionalRoofAbuttingToTallerConstruction.UpperBuildingWidth, 
                "Width should be set at construction time.");
            Assert.AreEqual(10, exceptionalRoofAbuttingToTallerConstruction.LowerBuildingWidth,
                "Width should be set at construction time.");
            Assert.AreEqual(3, exceptionalRoofAbuttingToTallerConstruction.HeightDifference,
                "Height should be set at construction time.");
            Assert.AreEqual(15, exceptionalRoofAbuttingToTallerConstruction.Angle,
                "Angle should be set at construction time.");
        }

        [Test()]
        [Description("Check calculations of snow loads for the ExceptionalRoofAbuttingToTallerConstruction.")]
        public void ExceptionalRoofAbuttingToTallerConstructionTest_CalculateSnowLoad_Success()
        {
            var building = BuildingImplementation.CreateBuilding();
            building.SnowLoad.ExcepctionalSituation = true;
            building.SnowLoad.CurrentDesignSituation = DesignSituation.B2;

            var exceptionalRoofAbuttingToTallerConstruction =
                new ExceptionalRoofAbuttingToTallerConstruction(building, 20, 10, 3, 15);

            exceptionalRoofAbuttingToTallerConstruction.CalculateSnowLoad();

            Assert.AreEqual(3.6, Math.Round(exceptionalRoofAbuttingToTallerConstruction.SnowLoad1, 3),
                "Snow load for roof is not calculated properly.");
            Assert.AreEqual(3.6, Math.Round(exceptionalRoofAbuttingToTallerConstruction.SnowLoad2, 3),
                "Snow load for roof is not calculated properly.");
        }

        [Test()]
        [Description("Check calculations of drift length for the ExceptionalRoofAbuttingToTallerConstruction.")]
        public void ExceptionalRoofAbuttingToTallerConstructionTest_CalculateDriftLength_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var exceptionalRoofAbuttingToTallerConstruction =
                new ExceptionalRoofAbuttingToTallerConstruction(building, 20, 10, 3, 15);

            exceptionalRoofAbuttingToTallerConstruction.CalculateDriftLength();
            Assert.AreEqual(10, Math.Round(exceptionalRoofAbuttingToTallerConstruction.DriftLength, 3),
                "Drift length for roof is not calculated properly.");
        }
    }
}