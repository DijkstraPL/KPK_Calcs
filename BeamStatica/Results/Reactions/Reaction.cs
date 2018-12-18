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
        public double? Position { get; }

        protected Reaction(double? position = null)
        {
            Position = position;
        }

        public override string ToString() => Value.ToString();
    }
}
