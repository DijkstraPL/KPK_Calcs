using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using SnowLoads;
using SnowLoads.BuildingTypes;

namespace KPK_CalcSite.Models
{
    public class SnowLoadMonopitchRoof
    {
        //public BuildingSite BuildingSite { get; set; }
        //public SnowLoad SnowLoad { get; set; }
        //public Building Building { get; set; }
        public BuildingData BuildingData { get; set; }
        public MonopitchRoof MonopitchRoof { get; set; }

        public SnowLoadMonopitchRoof()
        {
            BuildingData = new BuildingData();
            //BuildingSite = new BuildingSite();
            //SnowLoad = new SnowLoad(BuildingSite);
            //Building = new Building(SnowLoad);
            MonopitchRoof = new MonopitchRoof(BuildingData.Building, 0);
        }
    }

    public class BuildingData
    {
       public BuildingSite BuildingSite { get; set; }
       public SnowLoad SnowLoad { get; set; }
       public Building Building { get; set; }

        public BuildingData()
        {
            BuildingSite = new BuildingSite();
            SnowLoad = new SnowLoad(BuildingSite);
            Building = new Building(SnowLoad);
        }
    }
}