using KPK_CalcSite.Models.SnowLoads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPK_CalcSite.ViewModels
{
    public class SnowLoadsViewModel
    {
        public BuildingData BuildingData { get; set; }
        public SnowLoadMonopitchRoof SnowLoadMonopitchRoof { get; set; }
        public SnowLoadPitchedRoof SnowLoadPitchedRoof { get; set; }
        public SnowLoadMultispanRoof SnowLoadMultispanRoof { get; set; }
        public SnowLoadCylindricalRoof SnowLoadCylindricalRoof { get; set; }
        public SnowLoadRoofAbuttingToTallerConstruction SnowLoadRoofAbuttingToTallerConstruction { get; set; }
        public SnowLoadDriftingAtProjectionsObstructions SnowLoadDriftingAtProjectionsObstructions { get; set; }
        public SnowLoadSnowOverhanging SnowLoadSnowOverhanging { get; set; }
        public SnowLoadSnowguards SnowLoadSnowguards { get; set; }
        public ExceptionalSnowLoadMultispanRoof ExceptionalSnowLoadMultispanRoof { get; set; }


    }
}