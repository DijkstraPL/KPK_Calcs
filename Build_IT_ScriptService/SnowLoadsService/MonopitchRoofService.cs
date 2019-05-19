using Build_IT_Data.Calculators.Interfaces;
using Build_IT_SnowLoads;
using Build_IT_SnowLoads.BuildingTypes;
using Build_IT_SnowLoads.Enums;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace Build_IT_ScriptService.SnowLoadsService
{
    [Export("MonopitchRoof", typeof(ICalculator))]
    public class MonopitchRoofService : ICalculator
    {
        private const string Zone = "Zone";
        private const string Topography = "Topography";
        private const string AltitudeAboveSea = "AltitudeAboveSea";
        private const string Slope = "Slope";

        public IDictionary<string, object> Properties { get; private set; }

        public void Map(object[] args)
        {
            Properties.Add(Zone, args[1]);
            Properties.Add(Topography, args[2]);
            Properties.Add(AltitudeAboveSea, args[3]);
            Properties.Add(Slope, args[4]);
        }

        /// <summary>
        /// "MonopitchRoof,
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object Calculate()
        {
            var buildingSite = new BuildingSite(
                (Zones)Convert.ToInt32(Properties[Zone]),
                (Topographies)Convert.ToInt32(Properties[Topography]),
                altitudeAboveSea: Convert.ToDouble(Properties[AltitudeAboveSea]));
            var snowLoad = new SnowLoad(buildingSite);
            var building = new Building(snowLoad);
            var monopitchRoof = new MonopitchRoof(building, 
                Convert.ToDouble(Properties[Slope]));

            buildingSite.CalculateExposureCoefficient();
            snowLoad.CalculateSnowLoad();
            building.CalculateThermalCoefficient();
            monopitchRoof.CalculateSnowLoad();

            return monopitchRoof.SnowLoadOnRoofValue;
        }

        public MonopitchRoofService()
        {
            Properties = new Dictionary<string, object>();
        }
    }
}
