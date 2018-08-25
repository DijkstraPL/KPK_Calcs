using SnowLoads.BuildingTypes;

namespace KPK_CalcSite.Models.SnowLoads
{
    public class SnowLoadMultispanRoof
    {
        public BuildingData BuildingData { get; set; }
        public MultiSpanRoof MultiSpanRoof { get; set; }

        public SnowLoadMultispanRoof()
        {
            BuildingData = new BuildingData();
            MultiSpanRoof = new MultiSpanRoof(BuildingData.Building, 0, 0);
        }
    }
}