using Build_IT_WindLoads.TerrainOrographies.Interfaces;
using System;

namespace Build_IT_WindLoads.Terrains
{
    public class TerrainCategoryIII : Terrain
    {
        public TerrainCategoryIII(ITerrainOrography terrainOrography = null)
            : base(roughnessLength: 0.3, minimumHeight: 5,
                  maximumHeight: 400, terrainOrography: terrainOrography)
        {
        }

        public override double GetRoughnessFactorAt(double height)
        {
            height = CheckMinimumHeight(height);
            return 0.8 * Math.Pow(height / 10, 0.19);
        }
    }
}
