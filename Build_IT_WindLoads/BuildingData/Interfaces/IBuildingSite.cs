using Build_IT_CommonTools;
using Build_IT_WindLoads.Terrains.Interfaces;

namespace Build_IT_WindLoads.BuildingData.Interfaces
{
    public interface IBuildingSite
    {
        [Abbreviation("a")]
        [Unit("m")]
         double HeightAboveSeaLevel { get; }
        WindZone WindZone { get; }

        ITerrain Terrain { get; }
        double BasicWindVelocity { get; }
    }
}