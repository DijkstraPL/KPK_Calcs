using NUnit.Framework;
using SnowLoads.Tests;
using System;

namespace SnowLoads.BuildingTypes.Tests
{
    [TestFixture()]
    public class DriftingAtProjectionsObstructionsTests
    {
        [Test()]
        [Description("Check constructor for the DriftingAtProjectionsObstructions.")]
        public void DriftingAtProjectionsObstructionsTest_Constructor_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var driftingAtProjectionsObstructions = new DriftingAtProjectionsObstructions(building, 2);
            Assert.IsNotNull(driftingAtProjectionsObstructions, "DriftingAtProjectionsObstructions should be created.");
            Assert.AreEqual(2, driftingAtProjectionsObstructions.ObstructionHeight, 
                "Height should be set at construction time.");
        }

        [Test()]
        [Description("Check calculations of snow loads for the DriftingAtProjectionsObstructions.")]
        public void DriftingAtProjectionsObstructionsTest_CalculateSnowLoad_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var driftingAtProjectionsObstructions = new DriftingAtProjectionsObstructions(building, 4);

            driftingAtProjectionsObstructions.CalculateSnowLoad();
            Assert.AreEqual(1.8, Math.Round(driftingAtProjectionsObstructions.SnowLoadOnRoofValue, 3),
                "Snow load near the obstruction is not calculated properly.");
            Assert.AreEqual(0.72, Math.Round(driftingAtProjectionsObstructions.SnowLoadOnRoofValueAtTheEnd, 3),
                "Snow load at the end of drifting length is not calculated properly.");
        }

        [Test()]
        [Description("Check calculations of drift length for the DriftingAtProjectionsObstructions.")]
        public void DriftingAtProjectionsObstructionsTest_CalculateDriftLength_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var driftingAtProjectionsObstructions = new DriftingAtProjectionsObstructions(building, 4);

            driftingAtProjectionsObstructions.CalculateDriftLength();
            Assert.AreEqual(8, Math.Round(driftingAtProjectionsObstructions.DriftLength, 3),
                "Drift length for roof is not calculated properly.");
        }
    }
}