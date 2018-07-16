using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SnowLoads.Exceptional;

namespace KPK_CalcSite.Models.SnowLoads
{
    public class ExceptionalSnowLoadMultispanRoof
    {
        public BuildingData BuildingData { get; set; }
        public ExceptionalMultiSpanRoof ExceptionalMultispanRoof { get; set; }

        public ExceptionalSnowLoadMultispanRoof()
        {
            BuildingData = new BuildingData();
            ExceptionalMultispanRoof = new ExceptionalMultiSpanRoof(BuildingData.Building, 0, 0, 0);
        }
    }
}