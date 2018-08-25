using SnowLoads.BuildingTypes;

namespace KPK_CalcSite.Models.SnowLoads
{
    public class SnowLoadRoofAbuttingToTallerConstruction
    {
        public BuildingData BuildingData { get; set; }
        public RoofAbuttingToTallerConstruction RoofAbuttingToTallerConstruction { get; set; }

        public SnowLoadRoofAbuttingToTallerConstruction()
        {
            BuildingData = new BuildingData();
            RoofAbuttingToTallerConstruction = new RoofAbuttingToTallerConstruction(BuildingData.Building, 0,0,0,0);
        }
    }
}