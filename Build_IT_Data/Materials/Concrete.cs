namespace Build_IT_Data.Materials
{
    public class Concrete : Material
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
