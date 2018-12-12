using BeamStatica.Loads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads
{
    public class Load : ILoadWithPosition
    {
        public double Position { get; }
        public double Value { get; }

        public Load(double position, double value)
        {
            Position = position;
            Value = value;
        }
    }
}
