using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace BeamStatica.Sections.Interfaces
{
    public interface IArea
    {
        [Abbreviation("A")]
        [Unit("cm2")]
        double Area { get; }
    }
}
