using Build_IT_BeamStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStatica.Loads.ContinousLoads.Interfaces
{
    public interface IDisplacementResult
    {
        double GetValue(ISpan span, double distanceFromLeftSide, double currentLength);
    }
}
