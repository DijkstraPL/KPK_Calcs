using BeamStatica.Loads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads
{
    public class LoadData : ILoadWithPosition
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
