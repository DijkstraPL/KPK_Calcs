using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SnowLoads.BuildingTypes;

namespace KPK_CalcSite.Models.SnowLoads
{
    public class SnowLoadSnowguards
    {
        public BuildingData BuildingData { get; set; }
        public Snowguards Snowguards { get; set; }

        public SnowLoadSnowguards()
        {
            BuildingData = new BuildingData();
            Snowguards = new Snowguards(0,0,0);
        }
    }
}