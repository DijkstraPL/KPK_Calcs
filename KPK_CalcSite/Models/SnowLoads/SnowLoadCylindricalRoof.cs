using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SnowLoads.BuildingTypes;

namespace KPK_CalcSite.Models.SnowLoads
{
    public class SnowLoadCylindricalRoof
    {
        public BuildingData BuildingData { get; set; }
        public CylindricalRoof CylindricalRoof { get; set; }

        public SnowLoadCylindricalRoof()
        {
            BuildingData = new BuildingData();
            CylindricalRoof = new CylindricalRoof(BuildingData.Building, 0, 0);
        }
    }
}