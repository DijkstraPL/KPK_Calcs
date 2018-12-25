namespace Build_IT_BeamStatica.Materials
{
    internal class Steel : Material
    {
        public Steel() : base(youngModulus: 210, thermalExpansionCoefficient: 0.000012)
        {
            Density = 7850;
        }
    }
}
