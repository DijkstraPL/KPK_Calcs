using SnowLoads;
using SnowLoads.Interfaces;

namespace KPK_CalcSite.Models.SnowLoads
{
    public class BuildingData
    {
       public IBuildingSite BuildingSite { get; set; }
       public ISnowLoad SnowLoad { get; set; }
       public IBuilding Building { get; set; }

        public BuildingData()
        {
            BuildingSite = new BuildingSite();
            SnowLoad = new SnowLoad(BuildingSite);
            Building = new Building(SnowLoad);
        }
    }
}