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
    public class CylindricalRoofTests
    {
        [Test()]
        [Description("Check constructor for the CylindricalRoof.")]
        public void CylindricalRoofTest_Constructor_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var cylindricalRoof = new CylindricalRoof(building, 20, 10);
            Assert.IsNotNull(cylindricalRoof, "CylindricalRoof should be created.");
            Assert.AreEqual(20, cylindricalRoof.Width, "Width should be set at construction time.");
            Assert.AreEqual(10, cylindricalRoof.Height, "Height should be set at construction time.");
        }

        [Test()]
        [Description("Check calculations of snow loads for the CylindricalRoof.")]
        public void CylindricalRoofTest_CalculateSnowLoad_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var cylindricalRoof = new CylindricalRoof(building, 20, 10);
            
            cylindricalRoof.CalculateSnowLoad();
            cylindricalRoof.SetCasesSnowLoad();
            Assert.AreEqual(0.72, Math.Round(cylindricalRoof.RoofCasesSnowLoad[1], 3),
                "Snow load for roof is not calculated properly.");
            Assert.AreEqual(0.9, Math.Round(cylindricalRoof.RoofCasesSnowLoad[2], 3),
                "Snow load for roof is not calculated properly.");
            Assert.AreEqual(1.8, Math.Round(cylindricalRoof.RoofCasesSnowLoad[3], 3),
                "Snow load for roof is not calculated properly.");
        }

        [Test()]
        [Description("Check calculations of drift length for the CylindricalRoof.")]
        public void CylindricalRoofTest_CalculateDriftLength_Success()
        {
            var building = BuildingImplementation.CreateBuilding();

            var cylindricalRoof = new CylindricalRoof(building, 20, 10);

            cylindricalRoof.CalculateDriftLength();
            Assert.AreEqual(17.321, Math.Round(cylindricalRoof.DriftLength, 3),
                "Drift length for roof is not calculated properly.");
        }
    }
}