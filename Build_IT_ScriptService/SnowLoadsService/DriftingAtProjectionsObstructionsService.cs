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
    [Export("SnowLoad-DriftingAtProjectionsObstructions", typeof(ICalculator))]
    [Export(typeof(ICalculator))]
    [ExportMetadata("Document", "PN-EN 1991-1-3")]
    [ExportMetadata("Type", "SnowLoad")]
    public class DriftingAtProjectionsObstructionsService : SnowLoadBaseService, ICalculator
    {
        #region Properties
        
        public Property<double> ObstructionHeight { get; } =
            new Property<double>("ObstructionHeight", 
                v => Convert.ToDouble(v));
       
        #endregion // Properties

        #region Constructors

        public DriftingAtProjectionsObstructionsService()
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
            DriftingAtProjectionsObstructions driftingAtProjectionsObstructions = GetDriftingAtProjectionsObstructions(building);

            if (!ExposureCoefficient.HasValue)
                buildingSite.CalculateExposureCoefficient();
            snowLoad.CalculateSnowLoad();
            building.CalculateThermalCoefficient();
            driftingAtProjectionsObstructions.CalculateSnowLoad();

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
            result.Properties.Add("μ_1_", driftingAtProjectionsObstructions.FirstShapeCoefficient);
            result.Properties.Add("μ_2_", driftingAtProjectionsObstructions.SecondShapeCoefficient);
            result.Properties.Add("l_s_", driftingAtProjectionsObstructions.DriftLength);
            result.Properties.Add("s_2_", driftingAtProjectionsObstructions.SnowLoadOnRoofValue);
            result.Properties.Add("s_1_", driftingAtProjectionsObstructions.SnowLoadOnRoofValueAtTheEnd);

            return result;
        }

        #endregion // Public_Methods

        #region Private_Methods
           
        private DriftingAtProjectionsObstructions GetDriftingAtProjectionsObstructions(Building building)
        {
            return new DriftingAtProjectionsObstructions(building, ObstructionHeight.Value);
        }

        #endregion // Private_Methods
    }
}
