using Build_IT_BeamStatica.Results.Interfaces;

namespace Build_IT_BeamStatica.Results.Reactions
{
    internal abstract class Reaction : IResultValue
    {
        public double Value { get; set; }
        public double? Position { get; }

        protected Reaction(double? position = null)
        {
            Position = position;
        }

        public override string ToString() => Value.ToString();
    }
}
