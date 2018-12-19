using Build_IT_BeamStatica.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStatica.Results.Displacements
{
   public  abstract class Displacement : IResultValue
    {
        public double Value { get; set; }
        public double? Position { get; }

        protected Displacement(double? position = null)
        {
            Position = position;
        }

        public override string ToString() => Value.ToString();
    }
}
