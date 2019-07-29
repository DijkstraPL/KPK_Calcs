using Build_IT_Data.Calculators;
using Build_IT_Data.Calculators.Interfaces;
using Build_IT_SnowLoads;
using Build_IT_SnowLoads.Exceptional;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;

namespace Build_IT_ScriptService.SnowLoadsService.ExceptionalSituations
{
    [Export("SnowLoad-ExceptionalOverDoorOrLoadingBay", typeof(ICalculator))]
    [Export(typeof(ICalculator))]
    [ExportMetadata("Document", "PN-EN 1991-1-3")]
    [ExportMetadata("Type", "SnowLoad")]
    class ExceptionalOverDoorOrLoadingBayService : SnowLoadBaseService, ICalculator
    {
        #region Properties

        public Property<double> WidthAboveDoor { get; } =
            new Property<double>("WidthAboveDoor",
                v => Convert.ToDouble(v));
        public Property<double> HeightDifference { get; } =
            new Property<double>("HeightDifference",
                v => Convert.ToDouble(v));
        public Property<double> BuildingWidth { get; } =
            new Property<double>("BuildingWidth",
                v => Convert.ToDouble(v));

        #endregion // Properties

        #region Constructors

        public ExceptionalOverDoorOrLoadingBayService()
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

        public IResult Calculate()
        {
            BuildingSite buildingSite = GetBuildingSite();
            SnowLoad snowLoad = GetSnowLoad(buildingSite);
            Building building = GetBuilding(snowLoad);
            ExceptionalOverDoorOrLoadingBay exceptionalOverDoorOrLoadingBay = GetExceptionalOverDoorOrLoadingBay(building);

            if (!ExposureCoefficient.HasValue)
                buildingSite.CalculateExposureCoefficient();
            snowLoad.CalculateSnowLoad();
            building.CalculateThermalCoefficient();
            exceptionalOverDoorOrLoadingBay.CalculateDriftLength();
            exceptionalOverDoorOrLoadingBay.CalculateSnowLoad();

            var result = new Result();
            result.Properties.Add("C_e_", buildingSite.ExposureCoefficient);
            result.Properties.Add("s_k_", snowLoad.DefaultCharacteristicSnowLoad);
            result.Properties.Add("V", snowLoad.VariationCoefficient);
            result.Properties.Add("C_esl_", snowLoad.ExceptionalSnowLoadCoefficient);
            result.Properties.Add("s_n_", snowLoad.SnowLoadForSpecificReturnPeriod);
            result.Properties.Add("s_Ad_", snowLoad.DesignExceptionalSnowLoadForSpecificReturnPeriod);
            result.Properties.Add("t_i_", building.InternalTemperature);
            result.Properties.Add("∆_t_", building.TempreatureDifference);
            result.Properties.Add("U", building.OverallHeatTransferCoefficient);
            result.Properties.Add("C_t_", building.ThermalCoefficient);
            result.Properties.Add("l_s_", exceptionalOverDoorOrLoadingBay.DriftLength);
            result.Properties.Add("μ_1_", exceptionalOverDoorOrLoadingBay.ShapeCoefficient);
            result.Properties.Add("s_1_", exceptionalOverDoorOrLoadingBay.SnowLoad);

            return result;
        }


        #endregion // Public_Methods

        #region Private_Methods

        private ExceptionalOverDoorOrLoadingBay GetExceptionalOverDoorOrLoadingBay(Building building)
        {
            return new ExceptionalOverDoorOrLoadingBay(building, WidthAboveDoor.Value,
                BuildingWidth.Value, HeightDifference.Value);
        }

        #endregion // Private_Methods
    }
}
