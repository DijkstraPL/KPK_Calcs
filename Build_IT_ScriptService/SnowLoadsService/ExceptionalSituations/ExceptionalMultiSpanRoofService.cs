using Build_IT_Data.Calculators;
using Build_IT_Data.Calculators.Interfaces;
using Build_IT_SnowLoads;
using Build_IT_SnowLoads.Exceptional;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;

namespace Build_IT_ScriptService.SnowLoadsService.ExceptionalSituations
{
    [Export("SnowLoad-ExceptionalMultiSpanRoof", typeof(ICalculator))]
    [Export(typeof(ICalculator))]
    [ExportMetadata("Document", "PN-EN 1991-1-3")]
    [ExportMetadata("Type", "SnowLoad")]
    public class ExceptionalMultiSpanRoofService : SnowLoadBaseService, ICalculator
    {
        #region Properties

        public Property<double> LeftDriftLength { get; } =
            new Property<double>("LeftDriftLength",
                v => Convert.ToDouble(v));
        public Property<double> RightDriftLength { get; } =
            new Property<double>("RightDriftLength",
                v => Convert.ToDouble(v));
        public Property<double> HeightInTheLowestPart { get; } =
            new Property<double>("HeightInTheLowestPart",
                v => Convert.ToDouble(v));
        
        #endregion // Properties

        #region Constructors

        public ExceptionalMultiSpanRoofService()
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
            ExceptionalMultiSpanRoof exceptionalMultiSpanRoof = GetExceptionalMultiSpanRoof(building);

            if (!ExposureCoefficient.HasValue)
                buildingSite.CalculateExposureCoefficient();
            snowLoad.CalculateSnowLoad();
            building.CalculateThermalCoefficient();
            exceptionalMultiSpanRoof.CalculateSnowLoad();

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
            result.Properties.Add("b_3_", exceptionalMultiSpanRoof.HorizontalDimensionOfThreeSlopes);
            result.Properties.Add("μ_1_", exceptionalMultiSpanRoof.ShapeCoefficient);
            result.Properties.Add("s", exceptionalMultiSpanRoof.SnowLoad);

            return result;
        }


        #endregion // Public_Methods

        #region Private_Methods

        private ExceptionalMultiSpanRoof GetExceptionalMultiSpanRoof(Building building)
        {
            return new ExceptionalMultiSpanRoof(building, LeftDriftLength.Value,
                RightDriftLength.Value, HeightInTheLowestPart.Value);
        }

        #endregion // Private_Methods
    }
}
