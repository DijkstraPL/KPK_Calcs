using BeamStatica.Loads.ContinousLoads.LoadResults;
using BeamStatica.Loads.Interfaces;
using BeamStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads.ContinousLoads.SpanExtendLoadResult
{
    public class HorizontalDeflectionResult : DisplacementResultBase
    {
        public HorizontalDeflectionResult(IContinousLoad continousLoad)
            : base(continousLoad)
        {
        }

        public override double GetValue(ISpan span, double distanceFromLeftSide, double currentLength)
            => -ContinousLoad.EndPosition.Value * (distanceFromLeftSide - currentLength) /100 ; // TODO: Check it!
    }
}
