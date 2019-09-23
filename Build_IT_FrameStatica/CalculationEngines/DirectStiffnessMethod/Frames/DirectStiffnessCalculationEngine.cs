using Build_IT_FrameStatica.CalculationEngines.DirectStiffnessMethod.Spans;
using Build_IT_FrameStatica.CalculationEngines.DirectStiffnessMethod.Spans.Interfaces;
using Build_IT_FrameStatica.CalculationEngines.Interfaces;
using Build_IT_FrameStatica.Frames;
using Build_IT_FrameStatica.Spans.Interfaces;
using System.Collections.Generic;

namespace Build_IT_FrameStatica.CalculationEngines.DirectStiffnessMethod.Frames
{
    internal class DirectStiffnessCalculationEngine : IFrameCalculationEngine
    {
        private Frame _frame;
        private IList<(ISpan span, ISpanCalculationEngine calculationEngine)> _spanCalculationEngines
            = new List<(ISpan, ISpanCalculationEngine)>();

        public DirectStiffnessCalculationEngine(Frame frame)
        {
            _frame = frame;

            SetSpanCalculationEngines();
        }

        public void Calculate()
        {
            _frame.SetNumeration();
            CalculateStiffnessMatrixes();
        }

        private void SetSpanCalculationEngines()
        {
            foreach (var span in _frame.Spans)
                _spanCalculationEngines.Add((span, new SpanCalculationEngine(span)));
        }


        private void CalculateStiffnessMatrixes()
        {
            foreach (var spanEnginePair in _spanCalculationEngines)
                spanEnginePair.calculationEngine.StiffnessMatrix.Calculate();
        }
    }

}
