using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace BeamStatica.Materials.Intefaces
{
    public interface IMaterial
    {
        [Abbreviation("E")]
        [Unit("GPa")]
        double YoungModulus { get; }

        [Abbreviation("alpha")]
        [Unit("1/K")]
        double ThermalExpansionCoefficient { get; }
    }
}
