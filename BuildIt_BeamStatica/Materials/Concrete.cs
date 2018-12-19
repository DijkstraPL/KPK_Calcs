namespace Build_IT_BeamStatica.Materials
{
    public class Concrete : Material
    {
        public Concrete(double youngModulus) : base(youngModulus, thermalExpansionCoefficient: 0.000010)
        {
        }
    }
}
