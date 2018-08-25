using SnowLoads.BuildingTypes;

namespace KPK_CalcSite.Models.SnowLoads
{
    public class SnowLoadPitchedRoof
    {
        public BuildingData BuildingData { get; set; }
        public PitchedRoof PitchedRoof { get; set; }

        public SnowLoadPitchedRoof()
        {
            BuildingData = new BuildingData();
            PitchedRoof = new PitchedRoof(BuildingData.Building, 0, 0);
        }
    }
}