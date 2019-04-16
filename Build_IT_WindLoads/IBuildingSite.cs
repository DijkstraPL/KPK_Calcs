using Build_IT_CommonTools;

namespace Build_IT_WindLoads
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