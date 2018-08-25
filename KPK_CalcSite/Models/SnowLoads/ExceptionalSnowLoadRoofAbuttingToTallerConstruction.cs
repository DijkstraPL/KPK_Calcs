using SnowLoads.Exceptional;

namespace KPK_CalcSite.Models.SnowLoads
{
    public class ExceptionalSnowLoadRoofAbuttingToTallerConstruction
    {
        public BuildingData BuildingData { get; set; }
        public ExceptionalRoofAbuttingToTallerConstruction ExceptionalRoofAbuttingToTallerConstruction { get; set; }

        public ExceptionalSnowLoadRoofAbuttingToTallerConstruction()
        {
            BuildingData = new BuildingData();
            ExceptionalRoofAbuttingToTallerConstruction = new ExceptionalRoofAbuttingToTallerConstruction(BuildingData.Building,0,0,0,0);
        }
    }
}