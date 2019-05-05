using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Materials
{
    public class Concrete : Material
    {
        public Concrete(double youngModulus) : base(youngModulus, thermalExpansionCoefficient: 0.000010)
        {
        }
    }
}
