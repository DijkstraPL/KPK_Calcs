using Build_IT_BeamStatica.Materials.Intefaces;
using Build_IT_Tools;

namespace Build_IT_BeamStatica.Materials
{
    internal class Material : IMaterial
    {
        #region Properties

        [Abbreviation("E")]
        [Unit("GPa")]
        public double YoungModulus { get; }

        [Abbreviation("gamma")]
        [Unit("kg/m3")]
        public double Density { get; protected set; }

        [Abbreviation("alpha")]
        [Unit("1/K")]
        public double ThermalExpansionCoefficient { get; }

        #endregion // Properties

        #region Public_Methods

        protected Material(double youngModulus, double thermalExpansionCoefficient)
        {
            YoungModulus = youngModulus;
            ThermalExpansionCoefficient = thermalExpansionCoefficient;
        }

        public Material(double youngModulus, double density, double thermalExpansionCoefficient)
            : this(youngModulus, thermalExpansionCoefficient)
        {
            Density = density;
        }

        #endregion // Public_Methods
    }
}
