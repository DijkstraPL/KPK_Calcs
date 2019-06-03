using Build_IT_SnowLoads;
using Build_IT_SnowLoads.Enums;
using System;

namespace Build_IT_ScriptService.SnowLoadsService
{
    public abstract class SnowLoadBaseService
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

        #endregion // Properties

        #region Protected_Methods

        protected BuildingSite GetBuildingSite()
        {
            if (ExposureCoefficient.HasValue)
                return new BuildingSite(
                    Zone.Value, Topography.Value,
                    AltitudeAboveSea.Value, ExposureCoefficient.Value);
            return new BuildingSite(
                Zone.Value, Topography.Value, AltitudeAboveSea.Value);
        }
        protected SnowLoad GetSnowLoad(BuildingSite buildingSite)
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
        protected Building GetBuilding(SnowLoad snowLoad)
        {
            if (InternalTemperature.HasValue && OverallHeatTransferCoefficient.HasValue)
                return new Building(snowLoad, InternalTemperature.Value,
                    OverallHeatTransferCoefficient.Value);
            else
                return new Building(snowLoad);
        }

        #endregion // Protected_Methods
    }
}
