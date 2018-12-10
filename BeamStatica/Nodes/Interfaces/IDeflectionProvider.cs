using BeamStatica.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Nodes.Interfaces
{
    public interface IDeflectionProvider
    {
        IResultValue HorizontalDeflection { get; }
        IResultValue VerticalDeflection { get; }
    }
}
