using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads.Interfaces
{
    public interface IBuilding
    {
        [Abbreviation("C_t")]
        double ThermalCoefficient { get; }
        
        [Abbreviation("t_i")]
        double InternalTemperature { get; set; }
        
        [Abbreviation("delta-t")]
        double TempreatureDifference { get; }
        
        [Abbreviation("U")]
        double OverallHeatTransferCoefficient { get; set; }

         ISnowLoad SnowLoad { get; }

        void CalculateThermalCoefficient();
    }
}
