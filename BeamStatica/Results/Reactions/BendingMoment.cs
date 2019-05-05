using BeamStatica.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Results.Reactions
{
    public class BendingMoment : Reaction
    {
        public BendingMoment(double? position = null) : base(position)
        {
        }
    }
}
