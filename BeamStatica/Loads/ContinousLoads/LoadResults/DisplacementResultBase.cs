using BeamStatica.Loads.ContinousLoads.Interfaces;
using BeamStatica.Loads.Interfaces;
using BeamStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads.ContinousLoads.LoadResults
{
    public abstract class DisplacementResultBase : ResultBase, IDisplacementResult
    {
        protected DisplacementResultBase(IContinousLoad continousLoad) : base(continousLoad)
        {
        }

        public abstract double GetValue(ISpan span, double distanceFromLeftSide, double currentLength);
    }
}
