using BeamStatica.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Results.Displacements
{
   public  abstract class Displacement : IResultValue
    {
        public double Value { get; set; }

        public override string ToString() => Value.ToString();
    }
}
