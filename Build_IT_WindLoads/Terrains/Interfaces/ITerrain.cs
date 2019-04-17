using Build_IT_CommonTools;
using Build_IT_WindLoads.TerrainOrographies.Interfaces;

namespace Build_IT_WindLoads.Terrains.Interfaces
{
    public interface ITerrain
    {
        ITerrainOrography TerrainOrography { get; }

        [Abbreviation("z_min")]
        [Unit("m")]
         double MinimumHeight { get; }

        [Abbreviation("z_0")]
        [Unit("m")]
         double RoughnessLength { get; }

        double GetRoughnessFactorAt(double height);
    }
}