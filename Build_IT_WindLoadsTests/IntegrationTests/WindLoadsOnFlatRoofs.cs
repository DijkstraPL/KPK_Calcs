using Build_IT_WindLoads;
using Build_IT_WindLoads.BuildingData;
using Build_IT_WindLoads.BuildingData.Roofs;
using Build_IT_WindLoads.Factors;
using Build_IT_WindLoads.TerrainOrographies;
using Build_IT_WindLoads.Terrains;
using Build_IT_WindLoads.WindLoadsCases;
using Build_IT_WindLoads.WindLoadsCases.Roofs;
using NUnit.Framework;

namespace Build_IT_WindLoadsTests.IntegrationTests
{
    [TestFixture]
    public class WindLoadsOnFlatRoofs
    {
        [Test]
        public void ExternalWindPressureCalculationsTest_Roof_MaxValues_Success()
        {
            //Arrange:
            var windZone = WindZone.III;
            var building = new FlatRoof(20, 10, 15);
            var terrainOrography = new CliffEscarpmentOrography(
                actualLengthUpwindSlope: 15,
                effectiveFeatureHeight: 5,
                horizontalDistanceFromCrestTop: 2);
            var terrain = new TerrainCategoryIII(terrainOrography);
            var directionalFactor = new DirectionalFactor(windZone, windDirection: 40);
            var buildingSite = new BuildingSite(
                325, windZone, terrain,
                directionalFactor: directionalFactor);
            var windLoadData = new WindLoadData(buildingSite, building);
            var flatRoofWindLoads = new FlatRoofWindLoads(building, windLoadData);

            //Act:
            var result = flatRoofWindLoads.GetExternalWindPressureMaxAt(building.Height);

            //Assert:
            Assert.Multiple(() =>
            {
                Assert.That(result[Field.F], Is.EqualTo(-0.818).Within(0.001));
                Assert.That(result[Field.G], Is.EqualTo(-0.530).Within(0.001));
                Assert.That(result[Field.H], Is.EqualTo(-0.258).Within(0.001));
                Assert.That(result[Field.I], Is.EqualTo(0.074).Within(0.001));
            });
        }

        [Test]
        public void ExternalWindPressureCalculationsTest_Roof_MinValues_Success()
        {
            //Arrange:
            var windZone = WindZone.III;
            var building = new FlatRoof(20, 10, 15);
            var terrainOrography = new CliffEscarpmentOrography(
                actualLengthUpwindSlope: 15,
                effectiveFeatureHeight: 5,
                horizontalDistanceFromCrestTop: 2);
            var terrain = new TerrainCategoryIII(terrainOrography);
            var directionalFactor = new DirectionalFactor(windZone, windDirection: 40);
            var buildingSite = new BuildingSite(
                325, windZone, terrain,
                directionalFactor: directionalFactor);
            var windLoadData = new WindLoadData(buildingSite, building);
            var flatRoofWindLoads = new FlatRoofWindLoads(building, windLoadData);

            //Act:
            var result = flatRoofWindLoads.GetExternalWindPressureMinAt(building.Height);

            //Assert:
            Assert.Multiple(() =>
            {
                Assert.That(result[Field.F], Is.EqualTo(-0.818).Within(0.001));
                Assert.That(result[Field.G], Is.EqualTo(-0.530).Within(0.001));
                Assert.That(result[Field.H], Is.EqualTo(-0.258).Within(0.001));
                Assert.That(result[Field.I], Is.EqualTo(-0.074).Within(0.001));
            });
        }
    }
}
