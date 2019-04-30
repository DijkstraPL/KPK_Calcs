﻿using Build_IT_WindLoads;
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
    public class MonopitchedRoofWindLoadsRotation90Tests
    {
        [Test]
        public void ExternalWindPressureForceCalculationsTest_Success()
        {
            //Arrange:
            double heightAboveSeaLevel = 250;
            double length = 30;
            double width = 30;
            double maxHeight = 20;
            double minHeight = 14.71;
            WindZone windZone = WindZone.I;
            double referenceHeight = maxHeight;

            var building = new MonopitchRoof(
                length, width, maxHeight, minHeight, MonopitchRoof.Rotation.Degrees_90);
            var heightDisplacement = new HeightDisplacement(
                building, horizontalDistanceToObstruction: 10, obstructionHeight: 15);
            var terrain = new TerrainCategoryIV(heightDisplacement);
            var buildingSite = new BuildingSite(heightAboveSeaLevel, windZone, terrain);
            var windLoadData = new WindLoadData(buildingSite, building);
            var flatRoofWindLoads = new MonopitchedRoofWindLoadsRotation90(
                building, windLoadData);

            var externalPressureWindForce =
                new ExternalPressureWindForce(
                    windLoadData,
                    flatRoofWindLoads);

            referenceHeight = windLoadData.GetReferenceHeightAt(referenceHeight)
                - heightDisplacement.GetFactor();

            //Act:
            var resultMax = externalPressureWindForce.GetExternalPressureWindForceMaxAt(
                building.Height, calculateStructuralFactor: true);
            var resultMin = externalPressureWindForce.GetExternalPressureWindForceMinAt(
                building.Height, calculateStructuralFactor: true);

            //Assert:
            Assert.Multiple(() =>
            {
                // e
                Assert.That(building.EdgeDistance, Is.EqualTo(30));
                // v_b,0
                Assert.That(buildingSite.FundamentalValueBasicWindVelocity, Is.EqualTo(22).Within(0.01));
                // c_dir

                // v_b
                Assert.That(buildingSite.BasicWindVelocity, Is.EqualTo(22).Within(0.01));
                // z_e

                // c_r(z_e)
                Assert.That(terrain.GetRoughnessFactorAt(referenceHeight), Is.EqualTo(0.6).Within(0.01));
                // c_0(z_e)

                // v_m(z_e)
                Assert.That(windLoadData.GetMeanWindVelocityAt(referenceHeight),
                    Is.EqualTo(13.2).Within(0.01));
                // I_v(z_e)
                Assert.That(windLoadData.GetTurbulenceIntensityAt(referenceHeight),
                    Is.EqualTo(0.434).Within(0.001));
                // q_p(z_e)
                Assert.That(windLoadData.GetPeakVelocityPressureAt(referenceHeight),
                    Is.EqualTo(0.440).Within(0.001));
                // c_sc_d

                Assert.That(resultMax[Field.Fup], Is.EqualTo(-0.990).Within(0.001));
                Assert.That(resultMax[Field.Flow], Is.EqualTo(-0.814).Within(0.001));
                Assert.That(resultMax[Field.G], Is.EqualTo(-0.814).Within(0.001));
                Assert.That(resultMax[Field.H], Is.EqualTo(-0.308).Within(0.001));
                Assert.That(resultMax[Field.I], Is.EqualTo(-0.264).Within(0.001));
                
                Assert.That(resultMin[Field.Fup], Is.EqualTo(-0.990).Within(0.001));
                Assert.That(resultMin[Field.Flow], Is.EqualTo(-0.814).Within(0.001));
                Assert.That(resultMin[Field.G], Is.EqualTo(-0.814).Within(0.001));
                Assert.That(resultMin[Field.H], Is.EqualTo(-0.308).Within(0.001));
                Assert.That(resultMin[Field.I], Is.EqualTo(-0.264).Within(0.001));
            });
        }
    }
}
