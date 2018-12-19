using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Build_IT_Tools;

namespace Build_IT_BeamStatica.Sections.Interfaces
{
    public interface IArea
    {
        [Abbreviation("A")]
        [Unit("cm2")]
        double Area { get; }
    }
}
