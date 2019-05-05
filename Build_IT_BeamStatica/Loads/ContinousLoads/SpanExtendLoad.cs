using Build_IT_BeamStatica.Loads.ContinousLoads.SpanExtendLoadResult;
using Build_IT_BeamStatica.Loads.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;
using Build_IT_Data.Materials.Intefaces;

namespace Build_IT_BeamStatica.Loads.ContinousLoads
{
    internal class SpanExtendLoad : ContinousLoad
    {
        #region Factories

        public static IContinousLoad Create(ISpan span, double lengthIncrease)
        {
            return new SpanExtendLoad(
                           new LoadData(0, 0),
                           new LoadData(span.Length, lengthIncrease),
                           span.Material);
        }

        #endregion // Factories

        #region Constructors

        private SpanExtendLoad(
            ILoadWithPosition startPosition, ILoadWithPosition endPosition,
            IMaterial material)
            : base(startPosition, endPosition)
        {
            HorizontalDeflectionResult = new HorizontalDeflectionResult(this);
        }

        #endregion // Constructors

        #region Public_Methods

        public override double CalculateSpanLoadVectorNormalForceMember(ISpan span, bool leftNode)
        {
            double sign = leftNode ? 1.0 : -1.0;
            return sign * (this.EndPosition.Value - this.StartPosition.Value) / span.Length
               * span.Section.Area * span.Material.YoungModulus / 10;
        }

        #endregion // Public_Methods
    }
}
