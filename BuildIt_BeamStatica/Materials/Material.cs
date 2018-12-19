using Build_IT_BeamStatica.Materials.Intefaces;
using Build_IT_Tools;

namespace Build_IT_BeamStatica.Materials
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
