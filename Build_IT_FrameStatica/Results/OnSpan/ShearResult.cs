using Build_IT_FrameStatica.Frames.Interfaces;
using Build_IT_FrameStatica.Results.Interfaces;
using Build_IT_FrameStatica.Results.Reactions;
using Build_IT_FrameStatica.Spans.Interfaces;
using System.Linq;

namespace Build_IT_FrameStatica.Results.OnSpan
{
    internal class ShearResult : Result
    {
        #region Properties

        public IResultValue Result { get; private set; }

        #endregion // Properties

        #region Constructors

        public ShearResult(IFrame frame) : base(frame)
        {
        }

        #endregion // Constructors

        #region Protected_Methods

        protected override IResultValue CalculateAtPosition(ISpan span, double distanceFromLeftSide)
        {
            Result = new ShearForce(distanceFromLeftSide) { Value = 0 };

            CalculateShear(span, distanceFromLeftSide);

            return Result;
        }

        #endregion // Protected_Methods

        #region Private_Methods

        private void CalculateShear(ISpan span, double distanceFromLeftSide)
        {
            CalculateShearForceFromNodeForces(span);
            CalculateShearFromContinousLoads(distanceFromLeftSide, span);
            CalculateShearFromPointLoads(distanceFromLeftSide, span);
        }

        private void CalculateShearForceFromNodeForces(ISpan span)
        {
            Result.Value += span.LeftForces.ShearForce;
        }

        private void CalculateShearFromContinousLoads(double distanceFromLeftSide, ISpan span)
        {
            foreach (var load in span.ContinousLoads)
                if (distanceFromLeftSide > load.StartPosition.Position)
                    Result.Value += load.CalculateShear(distanceFromLeftSide - load.StartPosition.Position);
        }

        private void CalculateShearFromPointLoads(double distanceFromLeftSide, ISpan span)
        {
            foreach (var load in span.PointLoads)
                if (distanceFromLeftSide > load.Position)
                    Result.Value += load.CalculateShear();
        }

        #endregion // Private_Methods
    }
}
