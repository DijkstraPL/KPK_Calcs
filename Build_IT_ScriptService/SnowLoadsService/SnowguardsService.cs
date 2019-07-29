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
    [Export("SnowLoad-Snowguards", typeof(ICalculator))]
    [Export(typeof(ICalculator))]
    [ExportMetadata("Document", "PN-EN 1991-1-3")]
    [ExportMetadata("Type", "SnowLoad")]
    public class SnowguardsService : ICalculator
    {
        #region Properties
        
        public Property<double> Slope { get; } =
            new Property<double>("Slope", 
                v => Convert.ToDouble(v));
        public Property<double> SnowLoad { get; } =
            new Property<double>("SnowLoad", 
                v => Convert.ToDouble(v));
        public Property<double> Width { get; } =
            new Property<double>("Width",
                v => Convert.ToDouble(v));

        #endregion // Properties

        #region Constructors

        public SnowguardsService()
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
            Snowguards snowguards = GetSnowguards();

            snowguards.CalculateSnowLoad();

            var result = new Result();
            result.Properties.Add("F_s_", snowguards.ForceExertedBySnow);

            return result;
        }

        #endregion // Public_Methods

        #region Private_Methods
           
        private Snowguards GetSnowguards()
        {
            return new Snowguards(Width.Value, Slope.Value, SnowLoad.Value);
        }

        #endregion // Private_Methods
    }
}
