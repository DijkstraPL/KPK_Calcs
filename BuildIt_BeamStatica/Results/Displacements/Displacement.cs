using Build_IT_BeamStatica.Results.Interfaces;

namespace Build_IT_BeamStatica.Results.Displacements
{
    internal abstract class Displacement : IResultValue
    {
        public double Value { get; set; }
        public double? Position { get; }

        protected Displacement(double? position = null)
        {
            Position = position;
        }

        public override string ToString() => Value.ToString();
    }
}
