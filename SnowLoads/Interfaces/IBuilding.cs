using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace SnowLoads.Interfaces
{
    public interface IBuilding : ITemperatureProvider
    {      
        /// <summary>
        /// Thermal coefficient - 
        /// coefficient defining the reduction of snow load on roofs
        /// as a function of the heat flux through the roof, causing snow melting.
        /// </summary>
        [Abbreviation("C_t")]
        [Unit("")]
        double ThermalCoefficient { get; }
        
        /// <summary>
        /// Overall heat transfer coefficient - refers to how well heat is conducted over a series of mediums.
        /// </summary>
        [Abbreviation("U")]
        [Unit("W/(m2*K)")]
        double OverallHeatTransferCoefficient { get; set; }

        /// <summary>
        /// Instance of class implementing <see cref="ISnowLoad"/>.
        /// </summary>
        ISnowLoad SnowLoad { get; }

        /// <summary>
        /// Calculate <see cref="ThermalCoefficient"/>.
        /// </summary>
        void CalculateThermalCoefficient();
    }
}
