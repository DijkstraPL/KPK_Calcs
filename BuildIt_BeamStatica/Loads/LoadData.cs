using Build_IT_BeamStatica.Loads.Interfaces;

namespace Build_IT_BeamStatica.Loads
{
    internal class LoadData : ILoadWithPosition
    {
        public double Position { get; }
        public double Value { get; }

        public LoadData(double position, double value)
        {
            Position = position;
            Value = value;
        }
    }
}
