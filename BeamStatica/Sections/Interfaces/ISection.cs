using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Sections.Interfaces
{
    public interface ISection : IArea, IMomentOfInteria
    {
        double SolidHeight { get; }
    }
}
