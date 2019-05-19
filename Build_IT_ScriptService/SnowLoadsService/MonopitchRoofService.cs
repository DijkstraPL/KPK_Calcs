using Build_IT_Data.Calculators;
using Build_IT_Data.Calculators.Interfaces;
using Build_IT_SnowLoads;
using Build_IT_SnowLoads.BuildingTypes;
using Build_IT_SnowLoads.Enums;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Reflection;
using System.Text;

namespace Build_IT_ScriptService.SnowLoadsService
{
    [Export("SnowLoad-MonopitchRoof", typeof(ICalculator))]
    public class MonopitchRoofService : ICalculator
    {
        #region Properties

        public IDictionary<string, object> Properties { get; private set; }

        #endregion // Properties

        #region Fields

        private const string Zone = "Zone";
        private const string Topography = "Topography";
        private const string AltitudeAboveSea = "AltitudeAboveSea";
        private const string Slope = "Slope";

        #endregion // Fields

        #region Constructors

        public MonopitchRoofService()
        {
            Properties = new Dictionary<string, object>();
        }

        #endregion // Constructors

        #region Public_Methods

        public void Map(IList<object> args)
        {
            Properties.Add(Zone, args[0]);
            Properties.Add(Topography, args[1]);
            Properties.Add(AltitudeAboveSea, args[2]);
            Properties.Add(Slope, args[3]);
        }

        /// <summary>
        /// "MonopitchRoof,
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public IResult Calculate()
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

            var result = new Result();
            result.Properties.Add("C_e_", buildingSite.ExposureCoefficient);
            result.Properties.Add("s_k_", snowLoad.DefaultCharacteristicSnowLoad);
            result.Properties.Add("s", monopitchRoof.SnowLoadOnRoofValue);

            return result;
        }

        #endregion // Public_Methods
    }
}
