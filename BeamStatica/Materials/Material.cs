using BeamStatica.Materials.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace BeamStatica.Materials
{
    public class Material : IYoungModulus
    {
        [Abbreviation("E")]
        [Unit("GPa")]
        public double YoungModulus { get; }

        public Material(double youngModulus)
        {
            YoungModulus = youngModulus;
        }
    }
}
