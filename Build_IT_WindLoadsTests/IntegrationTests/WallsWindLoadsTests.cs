using Build_IT_WindLoads;
using Build_IT_WindLoads.BuildingData;
using Build_IT_WindLoads.BuildingData.Walls;
using Build_IT_WindLoads.DynamicCharacteristics;
using Build_IT_WindLoads.DynamicCharacteristics.Enums;
using Build_IT_WindLoads.Factors;
using Build_IT_WindLoads.Terrains;
using Build_IT_WindLoads.WindLoadsCases;
using NUnit.Framework;

namespace Build_IT_WindLoadsTests.IntegrationTests
{
    [TestFixture]
    public class WallsWindLoadsTests
    {
        [Test]
        public void GetPeakVelocityPressureTest_Success()
        {
            //Arrange:
            var building = new EqualHeightWalls(10, 10, 10);
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
            var building = new EqualHeightWalls(10, 10, 15);
            var terrain = new TerrainCategoryIII();
            var buildingSite = new BuildingSite(325, WindZone.I_III, terrain);
            var windLoadData = new WindLoadData(buildingSite, building);
            var verticalWallOfRectangularBuilding = new WallsWindLoads(building, windLoadData);

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
            var building = new EqualHeightWalls(
                length: 72, width: 30, height: 7.3);
            var terrain = new TerrainCategoryII();
            var buildingSite = new BuildingSite(325, WindZone.II, terrain);
            var windLoadData = new WindLoadData(buildingSite, building);
            var verticalWallOfRectangularBuilding = new WallsWindLoads(building, windLoadData);

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
            var building = new EqualHeightWalls(
                length: 28.8, width: 42, height: 10.6);
            var terrain = new TerrainCategoryIII();
            var buildingSite = new BuildingSite(175, WindZone.I, terrain);
            var windLoadData = new WindLoadData(buildingSite, building);
            var verticalWallOfRectangularBuilding = new WallsWindLoads(building, windLoadData);

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
            var building = new EqualHeightWalls(
                length: 28.8, width: 42, height: 10.6, 
                EqualHeightWalls.Rotation.Degrees_90);
            var terrain = new TerrainCategoryIII();
            var buildingSite = new BuildingSite(175, WindZone.I, terrain);
            var windLoadData = new WindLoadData(buildingSite, building);
            var verticalWallOfRectangularBuilding = new WallsWindLoads(building, windLoadData);

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
        
        [Test]
        public void ExternalWindPressureForceCalculationsTest_8_2_48m_Success()
        {
            //Arrange:
            var building = new EqualHeightWalls(
                length: 16, width: 20, height: 48);
            var heightDisplacement = new HeightDisplacement(
                building,
                horizontalDistanceToObstruction: 10,
                obstructionHeight: 15);
            var terrain = new TerrainCategoryIV(heightDisplacement);
            var buildingSite = new BuildingSite(360, WindZone.III, terrain);
            var windLoadData = new WindLoadData(buildingSite, building);
            var verticalWallOfRectangularBuilding = new WallsWindLoads(building, windLoadData);

            var structuralFactorCalculator = new StructuralFactorCalculator(
                building, terrain, windLoadData, StructuralType.SteelBuilding);

            var externalPressureWindForce = 
                new ExternalPressureWindForce(
                    windLoadData, 
                    verticalWallOfRectangularBuilding, 
                    structuralFactorCalculator);

            //Act:
            var result = externalPressureWindForce.GetExternalPressureWindForceMaxAt(
                building.Height, calculateStructuralFactor: true);

            //Assert:
            Assert.Multiple(() =>
            {
                Assert.That(result[Field.A], Is.EqualTo(-0.628).Within(0.001));
                Assert.That(result[Field.B], Is.EqualTo(-0.418).Within(0.001));
                Assert.That(result[Field.D], Is.EqualTo(0.418).Within(0.001));
                Assert.That(result[Field.E], Is.EqualTo(-0.314).Within(0.001));
            });
        }

        [Test]
        public void ExternalWindPressureForceCalculationsTest_8_2_28m_Success()
        {
            //Arrange:
            var building = new EqualHeightWalls(
                length: 16, width: 20, height: 48);
            var heightDisplacement = new HeightDisplacement(
                building,
                horizontalDistanceToObstruction: 10,
                obstructionHeight: 15);
            var terrain = new TerrainCategoryIV(heightDisplacement);
            var buildingSite = new BuildingSite(360, WindZone.III, terrain);
            var windLoadData = new WindLoadData(buildingSite, building);
            var verticalWallOfRectangularBuilding = new WallsWindLoads(building, windLoadData);

            var structuralFactorCalculator = new StructuralFactorCalculator(
                building, terrain, windLoadData, StructuralType.SteelBuilding);

            var externalPressureWindForce =
                new ExternalPressureWindForce(
                    windLoadData,
                    verticalWallOfRectangularBuilding,
                    structuralFactorCalculator);

            //Act:
            var result = externalPressureWindForce.GetExternalPressureWindForceMaxAt(
                28, calculateStructuralFactor: true);

            //Assert:
            Assert.Multiple(() =>
            {
                Assert.That(result[Field.A], Is.EqualTo(-0.507).Within(0.001));
                Assert.That(result[Field.B], Is.EqualTo(-0.338).Within(0.001));
                Assert.That(result[Field.D], Is.EqualTo(0.338).Within(0.001));
                Assert.That(result[Field.E], Is.EqualTo(-0.254).Within(0.001));
            });
        }
        
        [Test]
        public void ExternalWindPressureForceCalculationsTest_8_2_24m_Success()
        {
            //Arrange:
            var building = new EqualHeightWalls(
                length: 16, width: 20, height: 48);
            var heightDisplacement = new HeightDisplacement(
                building,
                horizontalDistanceToObstruction: 10,
                obstructionHeight: 15);
            var terrain = new TerrainCategoryIV(heightDisplacement);
            var buildingSite = new BuildingSite(360, WindZone.III, terrain);
            var windLoadData = new WindLoadData(buildingSite, building);
            var verticalWallOfRectangularBuilding = new WallsWindLoads(building, windLoadData);

            var structuralFactorCalculator = new StructuralFactorCalculator(
                building, terrain, windLoadData, StructuralType.SteelBuilding);

            var externalPressureWindForce =
                new ExternalPressureWindForce(
                    windLoadData,
                    verticalWallOfRectangularBuilding,
                    structuralFactorCalculator);

            //Act:
            var result = externalPressureWindForce.GetExternalPressureWindForceMaxAt(
                24, calculateStructuralFactor: true);

            //Assert:
            Assert.Multiple(() =>
            {
                Assert.That(result[Field.A], Is.EqualTo(-0.479).Within(0.001));
                Assert.That(result[Field.B], Is.EqualTo(-0.319).Within(0.001));
                Assert.That(result[Field.D], Is.EqualTo(0.319).Within(0.001));
                Assert.That(result[Field.E], Is.EqualTo(-0.239).Within(0.001));
            });
        }

        [Test]
        public void ExternalWindPressureForceCalculationsTest_8_2_20m_Success()
        {
            //Arrange:
            var building = new EqualHeightWalls(
                length: 16, width: 20, height: 48);
            var heightDisplacement = new HeightDisplacement(
                building,
                horizontalDistanceToObstruction: 10,
                obstructionHeight: 15);
            var terrain = new TerrainCategoryIV(heightDisplacement);
            var buildingSite = new BuildingSite(360, WindZone.III, terrain);
            var windLoadData = new WindLoadData(buildingSite, building);
            var verticalWallOfRectangularBuilding = new WallsWindLoads(building, windLoadData);

            var structuralFactorCalculator = new StructuralFactorCalculator(
                building, terrain, windLoadData, StructuralType.SteelBuilding);

            var externalPressureWindForce =
                new ExternalPressureWindForce(
                    windLoadData,
                    verticalWallOfRectangularBuilding,
                    structuralFactorCalculator);

            //Act:
            var result = externalPressureWindForce.GetExternalPressureWindForceMaxAt(
                20, calculateStructuralFactor: true);

            //Assert:
            Assert.Multiple(() =>
            {
                Assert.That(result[Field.A], Is.EqualTo(-0.464).Within(0.001));
                Assert.That(result[Field.B], Is.EqualTo(-0.309).Within(0.001));
                Assert.That(result[Field.D], Is.EqualTo(0.309).Within(0.001));
                Assert.That(result[Field.E], Is.EqualTo(-0.232).Within(0.001));
            });
        }
    }
}
