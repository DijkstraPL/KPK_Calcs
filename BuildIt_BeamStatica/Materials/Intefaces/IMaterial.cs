using Build_IT_Tools;

namespace Build_IT_BeamStatica.Materials.Intefaces
{
    public interface IMaterial
    {
        #region Properties

        [Abbreviation("E")]
        [Unit("GPa")]
        double YoungModulus { get; }

        [Abbreviation("gamma")]
        [Unit("kg/m3")]
        double Density { get; }

        [Abbreviation("alpha")]
        [Unit("1/K")]
        double ThermalExpansionCoefficient { get; }

        #endregion // Properties
    }
}
