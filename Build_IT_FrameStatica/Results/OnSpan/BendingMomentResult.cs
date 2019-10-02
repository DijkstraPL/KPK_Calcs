using Build_IT_FrameStatica.Frames.Interfaces;
using Build_IT_FrameStatica.Results.Interfaces;
using Build_IT_FrameStatica.Spans.Interfaces;
using System.Linq;

namespace Build_IT_FrameStatica.Results.OnSpan
{
    internal class BendingMomentResult : Result
    {
        #region Properties

        public IResultValue Result { get; private set; }

        #endregion // Properties

        #region Constructors

        public BendingMomentResult(IFrame frame) : base(frame)
        {
        }

        #endregion //Constructors

        #region Protected_Methods

        protected override IResultValue CalculateAtPosition(ISpan span, double distanceFromLeftSide)
        {
            Result = new Reactions.BendingMoment(distanceFromLeftSide) { Value = 0 };
            CalculateBendingMoment(span, distanceFromLeftSide);

            return Result;
        }

        #endregion // Protected_Methods

        #region Private_Methods

        private void CalculateBendingMoment(ISpan span, double distanceFromLeftSide)
        {
            CalculateBendingMomentFromNodeForces(distanceFromLeftSide, span);
            CalculateBendingMomentFromContinousLoads(distanceFromLeftSide, span);
            CalculateBendingMomentFromPointLoads(distanceFromLeftSide, span);
        }

        private void CalculateBendingMomentFromNodeForces(double distanceFromLeftSide, ISpan span)
        {
            Result.Value += span.LeftForces.BendingMoment;
            Result.Value += span.LeftForces.ShearForce * distanceFromLeftSide;
        }

        private void CalculateBendingMomentFromContinousLoads(double distanceFromLeftSide, ISpan span)
        {
            foreach (var load in span.ContinousLoads)
                if (distanceFromLeftSide > load.StartPosition.Position)
                    Result.Value += load.CalculateBendingMoment(distanceFromLeftSide - load.StartPosition.Position);
        }

        private void CalculateBendingMomentFromPointLoads(double distanceFromLeftSide, ISpan span)
        {
            foreach (var load in span.PointLoads)
                if (distanceFromLeftSide > load.Position)
                    Result.Value += load.CalculateBendingMoment(distanceFromLeftSide - load.Position);
        }

        #endregion // Private_Methods
    }
}
