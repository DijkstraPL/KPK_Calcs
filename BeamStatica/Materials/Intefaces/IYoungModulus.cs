using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace BeamStatica.Materials.Intefaces
{
    public interface IYoungModulus
    {
        [Abbreviation("E")]
        [Unit("GPa")]
        double YoungModulus { get; }
    }
}
