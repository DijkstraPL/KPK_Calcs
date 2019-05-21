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


        public Property<Zones> Zone { get; } =
            new Property<Zones>("Zone",
            v => Enum.Parse<Zones>(v));
        public Property<Topographies> Topography { get; } =
            new Property<Topographies>("Topography",
            v => Enum.Parse<Topographies>(v));
        public Property<double> AltitudeAboveSea { get; } =
            new Property<double>("AltitudeAboveSea", 
                v => Convert.ToDouble(v));
        public Property<double> ExposureCoefficient { get; } =
            new Property<double>("ExposureCoefficient", 
                v => Convert.ToDouble(v));
        public Property<double> SnowDensity { get; } =
            new Property<double>("SnowDensity", 
                v => Convert.ToDouble(v));
        public Property<int> ReturnPeriod { get; } =
            new Property<int>("ReturnPeriod", 
                v => Convert.ToInt32(v));
        public Property<DesignSituation> DesignSituation { get; } =
            new Property<DesignSituation>("DesignSituation",
            v => Enum.Parse<DesignSituation>(v));
        public Property<bool> ExceptionalSituation { get; } =
            new Property<bool>("ExceptionalSituation", 
            v => v == "true");
        public Property<double> InternalTemperature { get; } =
            new Property<double>("InternalTemperature", 
            v => Convert.ToDouble(v));
        public Property<double> OverallHeatTransferCoefficient { get; } =
            new Property<double>("OverallHeatTransferCoefficient", 
            v => Convert.ToDouble(v));
        public Property<double> Slope { get; } =
            new Property<double>("Slope", 
                v => Convert.ToDouble(v));
        public Property<bool> SnowFences { get; } =
            new Property<bool>("SnowFences", 
                v => v == "true");

        #endregion // Properties

        #region Constructors

        public MonopitchRoofService()
        {
        }

        #endregion // Constructors

        #region Public_Methods

        public void Map(IList<object> args)
        {
            for (int i = 0; i < args.Count; i += 2)
            {
                var properties = this.GetType().GetProperties().Select(
                    p => p.GetValue(this, null) as Property);

                var property = properties.SingleOrDefault(p => p.Name == args[i].ToString());
                if (property != null)
                    property.SetValue(args[i + 1]);
            }
        }

        /// <summary>
        /// "MonopitchRoof,
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public IResult Calculate()
        {
            BuildingSite buildingSite = GetBuildingSite();
            SnowLoad snowLoad = GetSnowLoad(buildingSite);
            Building building = GetBuilding(snowLoad);
            MonopitchRoof monopitchRoof = GetMonopitchRoof(building);

            if (!ExposureCoefficient.HasValue)
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

        #region Private_Methods
        
        private BuildingSite GetBuildingSite()
        {
            if (ExposureCoefficient.HasValue)
                return new BuildingSite(
                    Zone.Value, Topography.Value,
                    AltitudeAboveSea.Value, ExposureCoefficient.Value);
            return new BuildingSite(
                Zone.Value, Topography.Value, AltitudeAboveSea.Value);
        }
        private SnowLoad GetSnowLoad(BuildingSite buildingSite)
        {
            if (SnowDensity.HasValue &&
                ReturnPeriod.HasValue)
                return new SnowLoad(buildingSite,
                    SnowDensity.Value,
                    ReturnPeriod.Value,
                    DesignSituation.HasValue ? DesignSituation.Value : default,
                    ExceptionalSituation.HasValue ? ExceptionalSituation.Value : default);
            else if (SnowDensity.HasValue)
                return new SnowLoad(buildingSite,
                     SnowDensity.Value,
                     DesignSituation.HasValue ? DesignSituation.Value : default,
                     ExceptionalSituation.HasValue ? ExceptionalSituation.Value : default);
            else if (ReturnPeriod.HasValue)
                return new SnowLoad(buildingSite,
                     ReturnPeriod.Value,
                     DesignSituation.HasValue ? DesignSituation.Value : default,
                     ExceptionalSituation.HasValue ? ExceptionalSituation.Value : default);
            else
                return new SnowLoad(buildingSite,
                     DesignSituation.HasValue ? DesignSituation.Value : default,
                     ExceptionalSituation.HasValue ? ExceptionalSituation.Value : default);
        }
        private Building GetBuilding(SnowLoad snowLoad)
        {
            if (InternalTemperature.HasValue && OverallHeatTransferCoefficient.HasValue)
                return new Building(snowLoad, InternalTemperature.Value,
                    OverallHeatTransferCoefficient.Value);
            else
                return new Building(snowLoad);
        }
        private MonopitchRoof GetMonopitchRoof(Building building)
        {
            return new MonopitchRoof(building, Slope.Value,
                SnowFences.HasValue ? SnowFences.Value : default);
        }

        #endregion // Private_Methods
    }
}
