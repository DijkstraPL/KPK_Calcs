using BeamStatica.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Results.Reactions
{
    public abstract class Reaction : IResultValue
    {
        public double Value { get; set; }

        public override string ToString() => Value.ToString();
    }
}
