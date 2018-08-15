using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace SnowLoads.Interfaces
{
    public interface IBuilding
    {
        [Abbreviation("C_t")]
        [Unit("")]
        double ThermalCoefficient { get; }

        [Abbreviation("t_i")]
        [Unit("C")]
        double InternalTemperature { get; set; }

        [Abbreviation("delta-t")]
        [Unit("C")]
        double TempreatureDifference { get; }

        [Abbreviation("U")]
        [Unit("W/(m2*K)")]
        double OverallHeatTransferCoefficient { get; set; }

        ISnowLoad SnowLoad { get; }

        void CalculateThermalCoefficient();
    }
}
