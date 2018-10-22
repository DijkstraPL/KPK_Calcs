using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads.PointLoads
{
    public sealed class BendingMoment : ConcentratedLoad
    {
        public BendingMoment(double value) : base(value)
        {
        }
    }
}
