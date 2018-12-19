using Build_IT_Tools;

namespace Build_IT_BeamStatica.Materials.Intefaces
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
