using Build_IT_WindLoads;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_WindLoadsTests
{
    [TestFixture]
    public class TerrainTests
    {
        [Test]
        [TestCase(TerrainType.Terrain_0, 0.003, 1)]
        [TestCase(TerrainType.Terrain_I, 0.01, 1)]
        [TestCase(TerrainType.Terrain_II, 0.05, 2)]
        [TestCase(TerrainType.Terrain_III, 0.3, 5)]
        [TestCase(TerrainType.Terrain_IV, 1, 10)]
        public void CreationTests_Success(TerrainType terrainType, 
            double roughnessLength, double minimumHeight )
        {
           var terrain = Terrain.Create(terrainType);

            Assert.That(terrain.RoughnessLength, Is.EqualTo(roughnessLength));
            Assert.That(terrain.MinimumHeight, Is.EqualTo(minimumHeight));
        }

        [Test]
        [TestCase(TerrainType.Terrain_0, 0.156036)]
        [TestCase(TerrainType.Terrain_II, 0.19)]
        public void RoughnessFactorTest_Success(TerrainType terrainType, double result)
        {
            var terrain = Terrain.Create(terrainType);

            Assert.That(terrain.TerrainFactor, Is.EqualTo(result).Within(0.000001));
        }

        [Test]
        [TestCase(TerrainType.Terrain_0, 2, 1.014590)]
        [TestCase(TerrainType.Terrain_II, 2, 0.700887)]
        [TestCase(TerrainType.Terrain_II, 5, 0.874982)]
        public void GetRoughnessFactorAtTest_Success(TerrainType terrainType, double height, double result)
        {
            var terrain = Terrain.Create(terrainType);
            
            Assert.That(terrain.GetRoughnessFactorAt(height), Is.EqualTo(result).Within(0.000001));
        }
    }
}
