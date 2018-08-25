using SnowLoads.Exceptional;

namespace KPK_CalcSite.Models.SnowLoads
{
    public class ExceptionalSnowLoadSnowBehindParapet
    {
        public BuildingData BuildingData { get; set; }
        public ExceptionalSnowBehindParapet ExceptionalSnowBehindParapet { get; set; }

        public ExceptionalSnowLoadSnowBehindParapet()
        {
            BuildingData = new BuildingData();
            ExceptionalSnowBehindParapet = new ExceptionalSnowBehindParapet(BuildingData.Building, 0, 0);
        }
    }
}