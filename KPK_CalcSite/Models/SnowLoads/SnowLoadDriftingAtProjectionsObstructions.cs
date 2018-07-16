using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SnowLoads.BuildingTypes;

namespace KPK_CalcSite.Models.SnowLoads
{
    public class SnowLoadDriftingAtProjectionsObstructions
    {
        public BuildingData BuildingData { get; set; }
        public DriftingAtProjectionsObstructions DriftingAtProjectionsObstructions { get; set; }

        public SnowLoadDriftingAtProjectionsObstructions()
        {
            BuildingData = new BuildingData();
            //BuildingSite = new BuildingSite();
            //SnowLoad = new SnowLoad(BuildingSite);
            //Building = new Building(SnowLoad);
            DriftingAtProjectionsObstructions = new DriftingAtProjectionsObstructions(BuildingData.Building, 0);
        }
    }
}