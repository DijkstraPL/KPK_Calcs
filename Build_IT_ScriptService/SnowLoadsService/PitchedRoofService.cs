using Build_IT_Data.Calculators;
using Build_IT_Data.Calculators.Interfaces;
using Build_IT_SnowLoads;
using Build_IT_SnowLoads.BuildingTypes;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;

namespace Build_IT_ScriptService.SnowLoadsService
{
    [Export("SnowLoad-PitchedRoof", typeof(ICalculator))]
    [Export(typeof(ICalculator))]
    [ExportMetadata("Document", "PN-EN 1991-1-3")]
    [ExportMetadata("Type", "SnowLoad")]
    public class PitchedRoofService : SnowLoadBaseService, ICalculator
    {
        #region Properties
        
        public Property<double> LeftSlope { get; } =
            new Property<double>("LeftSlope", 
                v => Convert.ToDouble(v));
        public Property<bool> LeftSnowFences { get; } =
            new Property<bool>("LeftSnowFences", 
                v => v == "true");
        public Property<double> RightSlope { get; } =
            new Property<double>("RightSlope",
                v => Convert.ToDouble(v));
        public Property<bool> RightSnowFences { get; } =
            new Property<bool>("RightSnowFences",
                v => v == "true");

        #endregion // Properties

        #region Constructors

        public PitchedRoofService()
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
            PitchedRoof pitchedRoof = GetPitchedRoof(building);

            if (!ExposureCoefficient.HasValue)
                buildingSite.CalculateExposureCoefficient();
            snowLoad.CalculateSnowLoad();
            building.CalculateThermalCoefficient();
            pitchedRoof.CalculateSnowLoad();

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
            result.Properties.Add("μ_l,1_", pitchedRoof.LeftRoof.ShapeCoefficient);
            result.Properties.Add("μ_r,1_", pitchedRoof.RightRoof.ShapeCoefficient);
            result.Properties.Add("s_l,I_", pitchedRoof.LeftRoofCasesSnowLoad[1]);
            result.Properties.Add("s_r,I_", pitchedRoof.RightRoofCasesSnowLoad[1]);
            result.Properties.Add("s_l,II_", pitchedRoof.LeftRoofCasesSnowLoad[2]);
            result.Properties.Add("s_r,II_", pitchedRoof.RightRoofCasesSnowLoad[2]);
            result.Properties.Add("s_l,III_", pitchedRoof.LeftRoofCasesSnowLoad[3]);
            result.Properties.Add("s_r,III_", pitchedRoof.RightRoofCasesSnowLoad[3]);

            return result;
        }

        #endregion // Public_Methods

        #region Private_Methods
           
        private PitchedRoof GetPitchedRoof(Building building)
        {
            return new PitchedRoof(building, LeftSlope.Value, RightSlope.Value,
                LeftSnowFences.HasValue ? LeftSnowFences.Value : default,
                RightSnowFences.HasValue ? RightSnowFences.Value : default);
        }

        #endregion // Private_Methods
    }
}
