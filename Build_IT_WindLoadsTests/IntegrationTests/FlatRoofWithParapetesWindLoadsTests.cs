﻿using Build_IT_WindLoads;
using Build_IT_WindLoads.BuildingData;
using Build_IT_WindLoads.BuildingData.Roofs;
using Build_IT_WindLoads.DynamicCharacteristics.Enums;
using Build_IT_WindLoads.Factors;
using Build_IT_WindLoads.TerrainOrographies;
using Build_IT_WindLoads.Terrains;
using Build_IT_WindLoads.WindLoadsCases;
using Build_IT_WindLoads.WindLoadsCases.Roofs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_WindLoadsTests.IntegrationTests
{
    [TestFixture]
    public class FlatRoofWithParapetesWindLoadsTests
    {
        [Test]
        public void ExternalWindPressureForceCalculationsTest_Example2019_04_28_Success()
        {
            //Arrange:
            double heightAboveSeaLevel = 123;
            double length = 70;
            double width = 100;
            double height = 45;
            double parapetHeight = 3;
            WindZone windZone = WindZone.I_III;
            double referenceHeight = height + parapetHeight;

            double actualLengthUpwindSlope = 20;
            double actualLengthDownwindSlope = 20;
            double effectiveFeatureHeight = 10;
            double horizontalDistanceFromCrestTop = 7;

            double windDirection = 220;

            var building = new FlatRoofWithParapetes(
                length, width, height, parapetHeight, FlatRoof.Rotation.Degrees_90);
            var orographyFactor = new HillRidgeOrography(
                actualLengthUpwindSlope,
                actualLengthDownwindSlope,
                effectiveFeatureHeight,
                horizontalDistanceFromCrestTop);
            var terrain = new TerrainCategoryII(orographyFactor);
            var directionalFactor = new DirectionalFactor(windZone, windDirection);
            var buildingSite = new BuildingSite(heightAboveSeaLevel, windZone, terrain,
                directionalFactor: directionalFactor);
            var windLoadData = new WindLoadData(buildingSite, building);
            var flatRoofWindLoads = new FlatRoofWithParapetesWindLoads(
                building, windLoadData, parapetHeight);
           // var heightDisplacement = new HeightDisplacement(building:, )

            var structuralFactorCalculator = new StructuralFactorCalculator(
                building, terrain, windLoadData, StructuralType.ReinforcementConcreteBuilding);

            var externalPressureWindForce =
                new ExternalPressureWindForce(
                    windLoadData,
                    flatRoofWindLoads,
                    structuralFactorCalculator);

            referenceHeight = windLoadData.GetReferenceHeightAt(referenceHeight);

            //Act:
            var resultMax = externalPressureWindForce.GetExternalPressureWindForceMaxAt(
                referenceHeight, calculateStructuralFactor: true);
            var resultMin = externalPressureWindForce.GetExternalPressureWindForceMinAt(
                referenceHeight, calculateStructuralFactor: true);

            //Assert:
            Assert.Multiple(() =>
            {
                // e
                Assert.That(building.EdgeDistance, Is.EqualTo(70));
                // v_b,0
                Assert.That(buildingSite.FundamentalValueBasicWindVelocity, Is.EqualTo(22).Within(0.01));
                // c_dir
                Assert.That(directionalFactor.GetFactor(), Is.EqualTo(1));
                // v_b
                Assert.That(buildingSite.BasicWindVelocity, Is.EqualTo(22).Within(0.01));
                // z_e

                // c_r(z_e)
                Assert.That(terrain.GetRoughnessFactorAt(referenceHeight), Is.EqualTo(1.31).Within(0.01));
                // c_0(z_e)
                Assert.That(orographyFactor.GetFactorAt(referenceHeight), Is.EqualTo(1.06).Within(0.01));
                // v_m(z_e)
                Assert.That(windLoadData.GetMeanWindVelocityAt(referenceHeight),
                    Is.EqualTo(30.30).Within(0.01));
                // I_v(z_e)
                Assert.That(windLoadData.GetTurbulenceIntensityAt(referenceHeight),
                    Is.EqualTo(0.138).Within(0.001));
                // q_p(z_e)
                Assert.That(windLoadData.GetPeakVelocityPressureAt(referenceHeight),
                    Is.EqualTo(1.128).Within(0.001));
                // c_sc_d
                Assert.That(structuralFactorCalculator.GetStructuralFactor(true),
                    Is.EqualTo(0.852).Within(0.001));

                Assert.That(resultMax[Field.F], Is.EqualTo(-1.298).Within(0.001));
                Assert.That(resultMax[Field.G], Is.EqualTo(-0.842).Within(0.001));
                Assert.That(resultMax[Field.H], Is.EqualTo(-0.673).Within(0.001));
                Assert.That(resultMax[Field.I], Is.EqualTo(0.192).Within(0.001));

                Assert.That(resultMin[Field.F], Is.EqualTo(-1.298).Within(0.001));
                Assert.That(resultMin[Field.G], Is.EqualTo(-0.842).Within(0.001));
                Assert.That(resultMin[Field.H], Is.EqualTo(-0.673).Within(0.001));
                Assert.That(resultMin[Field.I], Is.EqualTo(-0.192).Within(0.001));
            });
        }
    }
}
