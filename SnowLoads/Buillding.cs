using SnowLoads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads.BuildingTypes
{
    /// <summary>
    /// Class containing informations about the building.
    /// </summary>
    public class Building
    {
        #region Properties

        /// <summary>
        /// Ct - thermal coefficient - 
        /// coefficient defining the reduction of snow load on roofs
        /// as a function of the heat flux through the roof, causing snow melting.
        /// </summary>
        /// <remarks>
        /// The thermal coefficient Ct should be used to account for the reduction of
        /// snow loads on roofs with high thermal transmittance(> 1 W/m2K), in particular
        /// for some glass covered roofs, because of melting caused by heat loss.
        /// </remarks>
        [Abbreviation("C_t")]
        public double ThermalCoefficient { get; private set; }

        private double internalTemperature;
        /// <summary>
        /// Internal temperature in degrees of Celsius
        /// </summary>
        [Abbreviation("t_i")]
        public double InternalTemperature
        {
            get { return internalTemperature; }
            set
            {
                if (value > 5 && value <= 18)
                    internalTemperature = value;
                else if (value > 18)
                    internalTemperature = 18;
                else
                    internalTemperature = 0;
            }
        }

        /// <summary>
        /// Difference between temperatures
        /// </summary>
        [Abbreviation("delta-t")]
        public double TempreatureDifference { get; private set; }
        
        /// <summary>
        /// U - Overall heat transfer coefficient - refers to how well heat is conducted over a series of mediums W/(m2*K).
        /// </summary>
        [Abbreviation("U")]
        public double OverallHeatTransferCoefficient { get; set; }

        /// <summary>
        /// Instance of snow load.
        /// </summary>
        public SnowLoad SnowLoad { get; private set; }
        
        #endregion // Properties

        #region Constructors

        /// <summary>
        /// Constructor for building.
        /// </summary>
        /// <param name="snowLoad">Instance of snow load.</param>
        public Building(SnowLoad snowLoad)
        {
            SnowLoad = snowLoad;
        }

        public Building(SnowLoad snowLoad, double internalTemperature, double overallHeatTransferCoefficient)
        {
            SnowLoad = snowLoad;
            InternalTemperature = internalTemperature;
            OverallHeatTransferCoefficient = overallHeatTransferCoefficient;
        }

        #endregion // Constructors

        #region Methods
        
        /// <summary>
        /// Calculate thermal coefficient (NB.1)
        /// </summary>
        public void CalculateThermalCoefficient()
        {
            CalculateTempreatureDifference();

            if (OverallHeatTransferCoefficient >= 1 && OverallHeatTransferCoefficient <= 4.5)
                ThermalCoefficient = 1 - 0.054 * Math.Pow(SnowLoad.SnowLoadForSpecificReturnPeriod / 3.5, 0.25) *
                    TempreatureDifference * Math.Pow(Math.Sin(Math.PI / 180 * 57.3 * (0.4 * OverallHeatTransferCoefficient - 0.1)), 0.25);
            else
                ThermalCoefficient = 1;
        }

        /// <summary>
        /// Calculate difference in temperature (NB.2)
        /// </summary>
        private void CalculateTempreatureDifference()
        {
            TempreatureDifference = InternalTemperature - 5;
        }

        #endregion

    }
}
