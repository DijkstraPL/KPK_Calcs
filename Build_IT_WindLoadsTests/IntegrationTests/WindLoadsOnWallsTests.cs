using Build_IT_WindLoads;
using Build_IT_WindLoads.BuildingData;
using Build_IT_WindLoads.Terrains;
using Build_IT_WindLoads.WindLoadsCases;
using NUnit.Framework;

namespace Build_IT_WindLoadsTests.IntegrationTests
{
    [TestFixture]
    public class WindLoadsOnWallsTests
    {
        [Test]
        public void GetPeakVelocityPressureTest_Success()
        {
            //Arrange:
            var building = new FlatRoofBuilding(10, 10, 10);
            var terrain = new TerrainCategoryI();

            var buildingSite = new BuildingSite(325, WindZone.I, terrain);
            var windLoadData = new WindLoadData(buildingSite, building);

            //Act:
            var result = windLoadData.GetPeakVelocityPressureAt(10);

            //Assert:
            Assert.That(result, Is.EqualTo(0.904).Within(0.001));
        }

        [Test]
        public void ExternalWindPressureCalculationsTest_Walls_Success()
        {
            //Arrange:
            var building = new FlatRoofBuilding(10, 10, 15);
            var terrain = new TerrainCategoryIII();
            var buildingSite = new BuildingSite(325, WindZone.I_III, terrain);
            var windLoadData = new WindLoadData(buildingSite, building);
            var verticalWallOfRectangularBuilding = new VerticalWallsOfRectangularBuilding(building, windLoadData);

            //Act:
            var result = verticalWallOfRectangularBuilding.GetExternalWindPressureMaxAt(building.Height);

            //Assert:
            Assert.Multiple(() =>
            {
                Assert.That(result[Field.A], Is.EqualTo(-0.754).Within(0.001));
                Assert.That(result[Field.B], Is.EqualTo(-0.503).Within(0.001));
                Assert.That(result[Field.D], Is.EqualTo(0.503).Within(0.001));
                Assert.That(result[Field.E], Is.EqualTo(-0.330).Within(0.001));
            });
        }
        
        [Test]
        public void ExternalWindPressureCalculationsTest_AS_SX01a_Success()
        {
            //Arrange:
            var building = new FlatRoofBuilding(
                length: 72, width: 30, height: 7.3);
            var terrain = new TerrainCategoryII();
            var buildingSite = new BuildingSite(325, WindZone.II, terrain);
            var windLoadData = new WindLoadData(buildingSite, building);
            var verticalWallOfRectangularBuilding = new VerticalWallsOfRectangularBuilding(building, windLoadData);

            //Act:
            var result = verticalWallOfRectangularBuilding.GetExternalWindPressureMaxAt(building.Height);

            //Assert:
            Assert.Multiple(() =>
            {
                Assert.That(result[Field.D], Is.EqualTo(0.638).Within(0.001));
                Assert.That(result[Field.E], Is.EqualTo(-0.273).Within(0.001));
            });
        }

        [Test]
        public void ExternalWindPressureCalculationsTest_8_1a_Success()
        {
            //Arrange:
            var building = new FlatRoofBuilding(
                length: 28.8, width: 42, height: 10.6);
            var terrain = new TerrainCategoryIII();
            var buildingSite = new BuildingSite(175, WindZone.I, terrain);
            var windLoadData = new WindLoadData(buildingSite, building);
            var verticalWallOfRectangularBuilding = new VerticalWallsOfRectangularBuilding(building, windLoadData);

            //Act:
            var result = verticalWallOfRectangularBuilding.GetExternalWindPressureMaxAt(building.Height);

            //Assert:
            Assert.Multiple(() =>
            {
                Assert.That(result[Field.A], Is.EqualTo(-0.704).Within(0.001));
                Assert.That(result[Field.B], Is.EqualTo(-0.470).Within(0.001));
                Assert.That(result[Field.C], Is.EqualTo(-0.294).Within(0.001));
                Assert.That(result[Field.D], Is.EqualTo(0.420).Within(0.001));
                Assert.That(result[Field.E], Is.EqualTo(-0.194).Within(0.001));
            });
        }

        [Test]
        public void ExternalWindPressureCalculationsTest_8_1b_Success()
        {
            //Arrange:
            var building = new FlatRoofBuilding(
                length: 28.8, width: 42, height: 10.6, rotated: true);
            var terrain = new TerrainCategoryIII();
            var buildingSite = new BuildingSite(175, WindZone.I, terrain);
            var windLoadData = new WindLoadData(buildingSite, building);
            var verticalWallOfRectangularBuilding = new VerticalWallsOfRectangularBuilding(building, windLoadData);

            //Act:
            var result = verticalWallOfRectangularBuilding.GetExternalWindPressureMaxAt(building.Height);

            //Assert:
            Assert.Multiple(() =>
            {
                Assert.That(result[Field.A], Is.EqualTo(-0.704).Within(0.001));
                Assert.That(result[Field.B], Is.EqualTo(-0.470).Within(0.001));
                Assert.That(result[Field.C], Is.EqualTo(-0.294).Within(0.001));
                Assert.That(result[Field.D], Is.EqualTo(0.411).Within(0.001));
                Assert.That(result[Field.E], Is.EqualTo(-0.177).Within(0.001));
            });
        }
    }
}
