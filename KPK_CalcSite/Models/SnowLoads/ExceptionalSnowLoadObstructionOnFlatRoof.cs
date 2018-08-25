using SnowLoads.Exceptional;

namespace KPK_CalcSite.Models.SnowLoads
{
    public class ExceptionalSnowLoadObstructionOnFlatRoof
    {
        public BuildingData BuildingData { get; set; }
        public ExceptionalObstructionOnFlatRoof ExceptionalObstructionOnFlatRoof { get; set; }

        public ExceptionalSnowLoadObstructionOnFlatRoof()
        {
            BuildingData = new BuildingData();
            ExceptionalObstructionOnFlatRoof = new ExceptionalObstructionOnFlatRoof(BuildingData.Building, 0, 0, 0, 0);
        }
    }
}