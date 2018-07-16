using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads.Interfaces
{
    public interface IMonopitchRoof : ICalculatable
    {
        [Abbreviation("alpha")]
        double Slope { get; set; }

        bool SnowFences { get; set; }

        [Abbreviation("mi_1")]
        double ShapeCoefficient { get; }
        
        [Abbreviation("s")]
        double SnowLoadOnRoofValue { get; }
    }
}
