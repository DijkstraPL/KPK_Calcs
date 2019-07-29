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
    [Export("SnowLoad-RoofAbuttingToTallerConstruction", typeof(ICalculator))]
    [Export(typeof(ICalculator))]
    [ExportMetadata("Document", "PN-EN 1991-1-3")]
    [ExportMetadata("Type", "SnowLoad")]
    public class RoofAbuttingToTallerConstructionService : SnowLoadBaseService, ICalculator
    {
        #region Properties
        
        public Property<double> UpperBuildingWidth { get; } =
            new Property<double>("UpperBuildingWidth", 
                v => Convert.ToDouble(v));
        public Property<double> LowerBuildingWidth { get; } =
            new Property<double>("LowerBuildingWidth",
                v => Convert.ToDouble(v));
        public Property<double> HeightDifference { get; } =
            new Property<double>("HeightDifference",
                v => Convert.ToDouble(v));
        public Property<double> HigherRoofSlope { get; } =
            new Property<double>("HigherRoofSlope",
                v => Convert.ToDouble(v));
        public Property<bool> HigherRoofSnowFences { get; } =
            new Property<bool>("HigherRoofSnowFences",
                v => v == "true");

        #endregion // Properties

        #region Constructors

        public RoofAbuttingToTallerConstructionService()
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
            RoofAbuttingToTallerConstruction roofAbuttingToTallerConstruction = GetRoofAbuttingToTallerConstruction(building);

            if (!ExposureCoefficient.HasValue)
                buildingSite.CalculateExposureCoefficient();
            snowLoad.CalculateSnowLoad();
            building.CalculateThermalCoefficient();
            roofAbuttingToTallerConstruction.CalculateSnowLoad();

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
            result.Properties.Add("μ_s_", roofAbuttingToTallerConstruction.ShapeCoefficientSlidingSnow);
            result.Properties.Add("μ_w_", roofAbuttingToTallerConstruction.ShapeCoefficientWind);
            result.Properties.Add("μ_2_", roofAbuttingToTallerConstruction.ShapeCoefficient);
            result.Properties.Add("μ_1_", roofAbuttingToTallerConstruction.ShapeCoefficientAtTheEnd);
            result.Properties.Add("l_s_", roofAbuttingToTallerConstruction.DriftLength);
            result.Properties.Add("s_I_", roofAbuttingToTallerConstruction.SnowLoadsNearTallerBuilding[1]);
            result.Properties.Add("s_l,II_", roofAbuttingToTallerConstruction.SnowLoadsNearTallerBuilding[2]);
            result.Properties.Add("s_r,II_", roofAbuttingToTallerConstruction.SnowLoadOnRoofValueAtTheEnd);

            return result;
        }

        #endregion // Public_Methods

        #region Private_Methods
           
        private RoofAbuttingToTallerConstruction GetRoofAbuttingToTallerConstruction(Building building)
        {
            return new RoofAbuttingToTallerConstruction(building, 
                UpperBuildingWidth.Value, LowerBuildingWidth.Value,
                HeightDifference.Value, HigherRoofSlope.Value, 
                HigherRoofSnowFences.HasValue ? HigherRoofSnowFences.Value : default );
        }

        #endregion // Private_Methods
    }
}
