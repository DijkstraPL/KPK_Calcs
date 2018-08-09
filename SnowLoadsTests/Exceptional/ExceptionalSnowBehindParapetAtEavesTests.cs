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
    public class ExceptionalSnowBehindParapetAtEavesTests
    {
        [Test()]
        [Description("Check constructor for the ExceptionalSnowBehindParapetAtEaves.")]
        public void ExceptionalSnowBehindParapetAtEavesTest_Constructor_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var exceptionalSnowBehindParapetAtEaves =
                new ExceptionalSnowBehindParapetAtEaves(building, 5, 20, 1);

            Assert.IsNotNull(exceptionalSnowBehindParapetAtEaves,
                "ExceptionalSnowBehindParapetAtEaves should be created.");
            Assert.AreEqual(5, exceptionalSnowBehindParapetAtEaves.RidgeDistance,
                "Width should be set at construction time.");
            Assert.AreEqual(20, exceptionalSnowBehindParapetAtEaves.BuildingWidth,
                "Width should be set at construction time.");
            Assert.AreEqual(1, exceptionalSnowBehindParapetAtEaves.HeightDifference,
                "Height should be set at construction time.");
        }

        [Test()]
        [Description("Check calculations of snow loads for the ExceptionalSnowBehindParapetAtEaves.")]
        public void ExceptionalSnowBehindParapetAtEavesTest_CalculateSnowLoad_Success()
        {
            var building = BuildingImplementation.CreateBuilding();
            building.SnowLoad.ExcepctionalSituation = true;
            building.SnowLoad.CurrentDesignSituation = DesignSituation.B2;

            var exceptionalSnowBehindParapetAtEaves =
                new ExceptionalSnowBehindParapetAtEaves(building, 5, 20, 1);

            exceptionalSnowBehindParapetAtEaves.CalculateSnowLoad();

            Assert.AreEqual(2, Math.Round(exceptionalSnowBehindParapetAtEaves.SnowLoad, 3),
                "Snow load for roof is not calculated properly.");
        }

        [Test()]
        [Description("Check calculations of drift length for the ExceptionalSnowBehindParapetAtEaves.")]
        public void ExceptionalSnowBehindParapetAtEavesTest_CalculateDriftLength_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var exceptionalSnowBehindParapetAtEaves =
                new ExceptionalSnowBehindParapetAtEaves(building, 5, 20, 1);

            exceptionalSnowBehindParapetAtEaves.CalculateDriftLength();
            Assert.AreEqual(5, Math.Round(exceptionalSnowBehindParapetAtEaves.DriftLength, 3),
                "Drift length for roof is not calculated properly.");
        }
    }
}