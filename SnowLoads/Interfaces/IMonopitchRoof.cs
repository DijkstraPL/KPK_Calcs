using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace SnowLoads.Interfaces
{
    public interface IMonopitchRoof : ICalculatable
    {
        [Abbreviation("alpha")]
        [Unit("degree")]
        double Slope { get; set; }

        bool SnowFences { get; set; }

        [Abbreviation("mi_1")]
        [Unit("")]
        double ShapeCoefficient { get; }
        
        [Abbreviation("s")]
        [Unit("kN/m2")]
        double SnowLoadOnRoofValue { get; }
    }
}
