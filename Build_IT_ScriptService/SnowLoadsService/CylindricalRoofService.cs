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
    [Export("SnowLoad-CylindricalRoof", typeof(ICalculator))]
    [ExportMetadata("Document", "PN-EN 1991-1-3")]
    [ExportMetadata("Type", "SnowLoad")]
    public class CylindricalRoofService : SnowLoadBaseService, ICalculator
    {
        #region Properties
        
        public Property<double> Width { get; } =
            new Property<double>("Width", 
                v => Convert.ToDouble(v));
        public Property<double> Height { get; } =
            new Property<double>("Height",
                v => Convert.ToDouble(v));

        #endregion // Properties

        #region Constructors

        public CylindricalRoofService()
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
            CylindricalRoof cylindricalRoof = GetCylindricalRoof(building);

            if (!ExposureCoefficient.HasValue)
                buildingSite.CalculateExposureCoefficient();
            snowLoad.CalculateSnowLoad();
            building.CalculateThermalCoefficient();
            cylindricalRoof.CalculateSnowLoad();

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
            result.Properties.Add("l_s_", cylindricalRoof.DriftLength);
            result.Properties.Add("μ_3_", cylindricalRoof.ShapeCoefficient);
            result.Properties.Add("s_I_", cylindricalRoof.RoofCasesSnowLoad[1]);
            result.Properties.Add("s_l,II_", cylindricalRoof.RoofCasesSnowLoad[2]);
            result.Properties.Add("s_r,II_", cylindricalRoof.RoofCasesSnowLoad[3]);

            return result;
        }

        #endregion // Public_Methods

        #region Private_Methods
           
        private CylindricalRoof GetCylindricalRoof(Building building)
        {
            return new CylindricalRoof(building, Width.Value, Height.Value);
        }

        #endregion // Private_Methods
    }
}
