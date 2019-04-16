using Build_IT_WindLoads.TerrainOrographies.Interfaces;
using System;

namespace Build_IT_WindLoads
{
    public class TerrainCategoryII : Terrain
    {
        public TerrainCategoryII(ITerrainOrography terrainOrography = null)
            : base(roughnessLength: 0.05, minimumHeight: 2,
                  maximumHeight: 300, terrainOrography: terrainOrography)
        {
        }

        public override double GetRoughnessFactorAt(double height)
        {
            height = CheckMinimumHeight(height);
            return 1.0 * Math.Pow(height / 10, 0.17);
        }
    }
}
