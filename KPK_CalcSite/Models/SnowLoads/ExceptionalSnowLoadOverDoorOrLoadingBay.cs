using SnowLoads.Exceptional;

namespace KPK_CalcSite.Models.SnowLoads
{
    public class ExceptionalSnowLoadOverDoorOrLoadingBay
    {
        public BuildingData BuildingData { get; set; }
        public ExceptionalOverDoorOrLoadingBay ExceptionalOverDoorOrLoadingBay { get; set; }

        public ExceptionalSnowLoadOverDoorOrLoadingBay()
        {
            BuildingData = new BuildingData();
            ExceptionalOverDoorOrLoadingBay = new ExceptionalOverDoorOrLoadingBay(BuildingData.Building, 0, 0, 0);
        }
    }
}