using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using SnowLoads.BuildingTypes;

namespace KPK_CalcSite.Models.SnowLoads
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
}