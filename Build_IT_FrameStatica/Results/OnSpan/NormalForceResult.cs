using Build_IT_FrameStatica.Frames.Interfaces;
using Build_IT_FrameStatica.Results.Interfaces;
using Build_IT_FrameStatica.Results.Reactions;
using Build_IT_FrameStatica.Spans.Interfaces;
using System;
using System.Linq;

namespace Build_IT_FrameStatica.Results.OnSpan
{
    internal class NormalForceResult : Result
    {
        #region Properties

        public IResultValue Result { get; private set; }

        #endregion // Properties

        #region Constructors

        public NormalForceResult(IFrame frame) : base(frame)
        {
        }

        #endregion // Constructors

        #region Protected_Methods

        protected override IResultValue CalculateAtPosition(ISpan span, double distanceFromLeftSide)
        {
            Result = new NormalForce(distanceFromLeftSide) { Value = 0 };

            CalculateNormalForce(span, distanceFromLeftSide);

            return Result;
        }

        #endregion // Protected_Methods

        #region Private_Methods

        private void CalculateNormalForce(ISpan span, double distanceFromLeftSide)
        {
            CalculateNormalForceFromNodeForces(span);
            CalculateNormalForceFromContinousLoads(distanceFromLeftSide, span);
            CalculateNormalForceFromPointLoads(distanceFromLeftSide, span);
        }

        private void CalculateNormalForceFromNodeForces(ISpan span)
        {
            Result.Value += span.LeftForces.NormalForce;
        }

        private void CalculateNormalForceFromContinousLoads(double distanceFromLeftSide, ISpan span)
        {
            foreach (var load in span.ContinousLoads)
                if (distanceFromLeftSide > load.StartPosition.Position)
                    Result.Value += load.CalculateNormalForce(distanceFromLeftSide - load.StartPosition.Position);
        }

        private void CalculateNormalForceFromPointLoads(double distanceFromLeftSide, ISpan span)
        {
            foreach (var load in span.PointLoads)
                if (distanceFromLeftSide > load.Position)
                    Result.Value += load.CalculateNormalForce();
        }

        #endregion // Private_Methods
    }
}
