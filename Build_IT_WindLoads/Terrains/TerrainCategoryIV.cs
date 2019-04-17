using Build_IT_WindLoads.TerrainOrographies.Interfaces;
using System;

namespace Build_IT_WindLoads.Terrains
{
    public class TerrainCategoryIV : Terrain
    {
        public TerrainCategoryIV(ITerrainOrography terrainOrography = null)
            : base(roughnessLength: 1, minimumHeight: 10,
                  maximumHeight: 500, terrainOrography: terrainOrography)
        {
        }

        public override double GetRoughnessFactorAt(double height)
        {
            height = CheckMinimumHeight(height);
            return 0.6 * Math.Pow(height / 10, 0.24);
        }
    }
}
