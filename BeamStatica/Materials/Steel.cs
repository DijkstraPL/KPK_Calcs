namespace BeamStatica.Materials
{
    public class Steel : Material
    {
        public Steel() : base(youngModulus: 210, thermalExpansionCoefficient: 0.000012)
        {
        }
    }
}
