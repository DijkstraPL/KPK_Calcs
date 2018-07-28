using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SnowLoads.Exceptional;

namespace KPK_CalcSite.Models.SnowLoads
{
    public class ExceptionalSnowLoadObstructionOnPitchedOrCurvedRoof
    {
        public BuildingData BuildingData { get; set; }
        public ExceptionalObstructionOnPitchedOrCurvedRoof ExceptionalObstructionOnPitchedOrCurvedRoof { get; set; }

        public ExceptionalSnowLoadObstructionOnPitchedOrCurvedRoof()
        {
            BuildingData = new BuildingData();
            ExceptionalObstructionOnPitchedOrCurvedRoof = new ExceptionalObstructionOnPitchedOrCurvedRoof(BuildingData.Building, 0, 0, 0, 0);
        }
    }
}