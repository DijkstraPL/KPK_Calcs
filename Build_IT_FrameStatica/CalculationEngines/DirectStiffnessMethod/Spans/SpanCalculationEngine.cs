using Build_IT_CommonTools.MatrixMath.Wrappers;
using Build_IT_FrameStatica.CalculationEngines.DirectStiffnessMethod.Spans.Interfaces;
using Build_IT_FrameStatica.Spans.Interfaces;
using System;
using System.Linq;

namespace Build_IT_FrameStatica.CalculationEngines.DirectStiffnessMethod.Spans
{
    internal class SpanCalculationEngine : ISpanCalculationEngine
    {
        public SpanCalculationEngine(ISpan span, IStiffnessMatrix stiffnessMatrix = null)
        {
            _span = span ?? throw new ArgumentNullException(nameof(span));
            StiffnessMatrix = stiffnessMatrix ?? new StiffnessMatrix(_span);
        }

        private ISpan _span;

        public IStiffnessMatrix StiffnessMatrix { get; }

        IStiffnessMatrix ISpanCalculationEngine.StiffnessMatrix => throw new NotImplementedException();

        public VectorAdapter LoadVector => throw new NotImplementedException();

        public VectorAdapter Displacements => throw new NotImplementedException();

        public VectorAdapter Forces => throw new NotImplementedException();

        public void CalculateSpanLoadVector()
        {
            throw new NotImplementedException();
        }

        public void CalculateDisplacement(VectorAdapter deflectionVector, int numberOfDegreesOfFreedom)
        {
            throw new NotImplementedException();
        }

        public void CalculateForce(VectorAdapter loadVector, VectorAdapter displacements)
        {
            throw new NotImplementedException();
        }
    }
}
