using BeamStatica.Loads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads.PointLoads
{
    public abstract class ConcentratedLoad : ILoadValue, IPosition
    {
        public double Value { get; set; }
        public double Position { get; set; }

        protected ConcentratedLoad(double value)
        {
            Value = value;
        }

        protected ConcentratedLoad(double value, double position) : this(value)
        {
            Position = position;
        }
    }
}
