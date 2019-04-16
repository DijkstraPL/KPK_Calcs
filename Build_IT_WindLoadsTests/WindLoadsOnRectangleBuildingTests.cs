using Build_IT_WindLoads;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_WindLoadsTests
{
    [TestFixture]
    public class WindLoadsOnRectangleBuildingTests
    {
        [Test]
        public void CalculationsTest_Success()
        {
            var building = new Building(10, 10, 10);
            var terrain = new TerrainCategoryI();

            var buildingSite = new BuildingSite(325, WindZone.I, terrain);
            var windLoad = new WindLoad(buildingSite, building, false);

           var result = windLoad.GetPeakVelocityPressureAt(10);

            Assert.That(result, Is.EqualTo(0.904).Within(0.001));
        }

        [Test]
        public void Calculations2Test_Success()
        {
            var building = new Building(10, 10, 15);
            var terrain = new TerrainCategoryIII();

            var buildingSite = new BuildingSite(325, WindZone.I_III, terrain);
            var windLoad = new WindLoad(buildingSite, building, false);

            var result = windLoad.GetPeakVelocityPressureAt(15);

            Assert.That(result, Is.EqualTo(0.628).Within(0.001));
        }
    }
}
