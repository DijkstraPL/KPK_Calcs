using Build_IT_Data.Calculators;
using Build_IT_Data.Calculators.Interfaces;
using Build_IT_SnowLoads;
using Build_IT_SnowLoads.BuildingTypes;
using Build_IT_SnowLoads.Enums;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Build_IT_ScriptService.SnowLoadsService
{
    [Export("SnowLoad-MonopitchRoof", typeof(ICalculator))]
    public class MonopitchRoofService : ICalculator
    {
        #region Properties
        
        #endregion // Properties

        #region Fields

        public  Property<Zones> Zone { get; } =
            new Property<Zones>(orderNumber: 0, "Zone",
            v => Enum.Parse<Zones>(v));
        public  Property<Topographies> Topography { get; } = 
            new Property<Topographies>(orderNumber: 1, "Topography",
            v => Enum.Parse<Topographies>(v));
        public  Property<double> AltitudeAboveSea { get; } = 
            new Property<double>(orderNumber: 2, "AltitudeAboveSea",
                v => Convert.ToDouble(v));
        public  Property<double> Slope { get; } = 
            new Property<double>(orderNumber: 3, "Slope",
                v => Convert.ToDouble(v));
        
        #endregion // Fields

        #region Constructors

        public MonopitchRoofService()
        {
        }

        #endregion // Constructors

        #region Public_Methods

        public void Map(IList<object> args)
        {
            for (int i = 0; i < args.Count; i+=2)
            {
                var propertyInfo = this.GetType().GetProperty(
                    args[i].ToString());
                if (propertyInfo == null)
                    continue;
                var property = propertyInfo?.GetValue(this, null) as Property;
                if (property != null)
                    property.SetValue(args[i+1]);
            }
            //if (args.Any(a => a.ToString().Contains(':')))
            //    foreach (var arg in args)
            //    {
            //        var parameter = arg.ToString().Split(':');

            //        var propertyInfo = this.GetType().GetProperty(parameter[0]);
            //        if (propertyInfo == null)
            //            continue;
            //        var property = propertyInfo?.GetValue(this, null) as Property;
            //        if (property != null)
            //            property.SetValue(parameter[1]);
            //    }
        }

        /// <summary>
        /// "MonopitchRoof,
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public IResult Calculate()
        {
            Zones zone = Zone.Value;
            Topographies topography = Topography.Value;
            double altitudeAboveSea = AltitudeAboveSea.Value;
            double slope = Slope.Value;


            var buildingSite = new BuildingSite(zone, topography, altitudeAboveSea);
            var snowLoad = new SnowLoad(buildingSite);
            var building = new Building(snowLoad);
            var monopitchRoof = new MonopitchRoof(building, slope);

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
