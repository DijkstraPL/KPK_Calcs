using Build_IT_WindLoads.TerrainOrographies.Interfaces;
using System;

namespace Build_IT_WindLoads.Terrains
{
    public class TerrainCategory0 : Terrain
    {
        public TerrainCategory0(ITerrainOrography terrainOrography = null) 
            : base(roughnessLength: 0.003, minimumHeight: 1,
                  maximumHeight: 200, terrainOrography: terrainOrography)
        {
        }

        public override double GetRoughnessFactorAt(double height)
        {
            height = CheckMinimumHeight(height);
            return 1.3 * Math.Pow(height / 10, 0.11);
        }
    }
}
