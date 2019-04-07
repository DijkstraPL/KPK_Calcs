namespace Build_IT_BeamStatica.Materials
{
    internal class Concrete : Material
    {
        #region Constructors

        public Concrete(double youngModulus, bool withReinforcement) : base(youngModulus, thermalExpansionCoefficient: 0.000010)
        {
            if (withReinforcement)
                Density = 2500;
            else
                Density = 2400;
        }

        #endregion // Constructors
    }
}
