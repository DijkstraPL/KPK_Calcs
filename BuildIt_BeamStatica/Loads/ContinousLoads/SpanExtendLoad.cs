using Build_IT_BeamStatica.Loads.ContinousLoads.SpanExtendLoadResult;
using Build_IT_BeamStatica.Loads.Interfaces;
using Build_IT_BeamStatica.Materials.Intefaces;
using Build_IT_BeamStatica.Sections.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStatica.Loads.ContinousLoads
{
    public class SpanExtendLoad : ContinousLoad
    {
        public static IContinousLoad Create(ISpan span, double lengthIncrease)
        {
            return new SpanExtendLoad(
                           new LoadData(0, 0),
                           new LoadData(span.Length, lengthIncrease),
                           span.Material);
        }

        private SpanExtendLoad(
            ILoadWithPosition startPosition, ILoadWithPosition endPosition,
            IMaterial material)
            : base(startPosition, endPosition)
        {
            HorizontalDeflectionResult = new HorizontalDeflectionResult(this);
        }

        public override double CalculateSpanLoadVectorNormalForceMember(ISpan span, bool leftNode)
        {
            double sign = leftNode ? 1.0 : -1.0;
            return sign * (this.EndPosition.Value - this.StartPosition.Value) / span.Length
               * span.Section.Area * span.Material.YoungModulus / 10;
        }
    }
}
