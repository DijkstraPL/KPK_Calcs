using Build_IT_WindLoads.TerrainOrographies.Interfaces;
using System;

namespace Build_IT_WindLoads
{
    public class TerrainCategoryI : Terrain
    {
        public TerrainCategoryI(ITerrainOrography terrainOrography = null)
            : base(roughnessLength: 0.01, minimumHeight: 1,
                  maximumHeight: 200, terrainOrography: terrainOrography)
        {
        }

        public override double GetRoughnessFactorAt(double height)
        {
            height = CheckMinimumHeight(height);
            return 1.2 * Math.Pow(height / 10, 0.13);
        }
    }
}
