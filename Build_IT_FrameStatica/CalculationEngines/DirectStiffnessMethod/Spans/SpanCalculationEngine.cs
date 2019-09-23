using Build_IT_CommonTools.MatrixMath.Wrappers;
using Build_IT_FrameStatica.Spans.Interfaces;
using System;
using System.Linq;

namespace Build_IT_FrameStatica.CalculationEngines.DirectStiffnessMethod.Spans
{
    internal class SpanCalculationEngine 
    {
        public SpanCalculationEngine(ISpan span, IStiffnessMatrix stiffnessMatrix = null)
        {
            _span = span ?? throw new ArgumentNullException(nameof(span));
            StiffnessMatrix = stiffnessMatrix ?? new StiffnessMatrix(_span);
        }
    }
}
