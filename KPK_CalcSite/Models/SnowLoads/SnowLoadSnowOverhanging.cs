using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SnowLoads.BuildingTypes;

namespace KPK_CalcSite.Models.SnowLoads
{
    public class SnowLoadSnowOverhanging
    {
        public BuildingData BuildingData { get; set; }
        public SnowOverhanging SnowOverhanging { get; set; }

        public SnowLoadSnowOverhanging()
        {
            BuildingData = new BuildingData();
            SnowOverhanging = new SnowOverhanging(BuildingData.Building, 0, 0);
        }

    }
}