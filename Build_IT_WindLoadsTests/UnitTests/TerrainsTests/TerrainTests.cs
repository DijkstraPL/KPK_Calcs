using Build_IT_WindLoads;
using Build_IT_WindLoads.Terrains;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_WindLoadsTests.UnitTests.TerrainsTests
{
    [TestFixture]
    public class TerrainTests
    {
        [Test]
        [TestCase(TerrainType.Terrain_0, 0.003, 1, 200)]
        [TestCase(TerrainType.Terrain_I, 0.01, 1, 200)]
        [TestCase(TerrainType.Terrain_II, 0.05, 2,300)]
        [TestCase(TerrainType.Terrain_III, 0.3, 5, 400)]
        [TestCase(TerrainType.Terrain_IV, 1, 10,500)]
        public void CreationTests_Success(TerrainType terrainType, 
            double roughnessLength, double minimumHeight, double maximumHeight )
        {
           var terrain = GetProperTerraint(terrainType);

           Assert.That(terrain.RoughnessLength, Is.EqualTo(roughnessLength));
           Assert.That(terrain.MinimumHeight, Is.EqualTo(minimumHeight));
           Assert.That(terrain.MaximumHeight, Is.EqualTo(maximumHeight));
        }

        [Test]
        [TestCase(TerrainType.Terrain_0, 0.156036)]
        [TestCase(TerrainType.Terrain_II, 0.19)]
        public void RoughnessFactorTest_Success(TerrainType terrainType, double result)
        {
            var terrain = GetProperTerraint(terrainType);

            Assert.That(terrain.TerrainFactor, Is.EqualTo(result).Within(0.000001));
        }

        [Test]
        [TestCase(TerrainType.Terrain_0, 2, 1.089072)]
        [TestCase(TerrainType.Terrain_II, 2, 0.760633)]
        [TestCase(TerrainType.Terrain_II, 5, 0.888843)]
        public void GetRoughnessFactorAtTest_Success(TerrainType terrainType, double height, double result)
        {
            var terrain = GetProperTerraint(terrainType);

            Assert.That(terrain.GetRoughnessFactorAt(height), Is.EqualTo(result).Within(0.000001));
        }

        public enum TerrainType
        {
            Terrain_0,
            Terrain_I,
            Terrain_II,
            Terrain_III,
            Terrain_IV
        }

        private Terrain GetProperTerraint(TerrainType terrainType)
        {
            switch (terrainType)
            {
                case TerrainType.Terrain_0:
                    return new TerrainCategory0();
                case TerrainType.Terrain_I:
                    return new TerrainCategoryI();
                case TerrainType.Terrain_II:
                    return new TerrainCategoryII();
                case TerrainType.Terrain_III:
                    return new TerrainCategoryIII();
                case TerrainType.Terrain_IV:
                    return new TerrainCategoryIV();
                default:
                    return null;
            }
        }
    }
}
