using SnowLoads.Exceptional;

namespace KPK_CalcSite.Models.SnowLoads
{
    public class ExceptionalSnowLoadSnowInValleyBehindParapet
    {
        public BuildingData BuildingData { get; set; }
        public ExceptionalSnowInValleyBehindParapet ExceptionalSnowInValleyBehindParapet { get; set; }

        public ExceptionalSnowLoadSnowInValleyBehindParapet()
        {
            BuildingData = new BuildingData();
            ExceptionalSnowInValleyBehindParapet = new ExceptionalSnowInValleyBehindParapet(BuildingData.Building, 0, 0);
        }
    }
}