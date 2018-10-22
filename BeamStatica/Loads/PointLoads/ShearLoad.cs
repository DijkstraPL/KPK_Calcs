using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads.PointLoads
{
    public sealed class ShearLoad : ConcentratedLoad
    {
        public ShearLoad(double value) : base(value)
        {
        }

        public ShearLoad(double value, double position) : base(value, position)
        {
        }
    }
}
