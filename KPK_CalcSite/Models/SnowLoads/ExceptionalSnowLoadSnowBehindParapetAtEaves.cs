using SnowLoads.Exceptional;

namespace KPK_CalcSite.Models.SnowLoads
{
    public class ExceptionalSnowLoadSnowBehindParapetAtEaves
    {
        public BuildingData BuildingData { get; set; }
        public ExceptionalSnowBehindParapetAtEaves ExceptionalSnowBehindParapetAtEaves { get; set; }

        public ExceptionalSnowLoadSnowBehindParapetAtEaves()
        {
            BuildingData = new BuildingData();
            ExceptionalSnowBehindParapetAtEaves = new ExceptionalSnowBehindParapetAtEaves(BuildingData.Building, 0, 0, 0);
        }
    }
}