using BeamStatica.Materials.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace BeamStatica.Materials
{
    public class Material : IMaterial
    {
        [Abbreviation("E")]
        [Unit("GPa")]
        public double YoungModulus { get; }

        [Abbreviation("alpha")]
        [Unit("1/K")]
        public double ThermalExpansionCoefficient { get; }

        public Material(double youngModulus, double thermalExpansionCoefficient)
        {
            YoungModulus = youngModulus;
            ThermalExpansionCoefficient = thermalExpansionCoefficient;
        }
    }
}
