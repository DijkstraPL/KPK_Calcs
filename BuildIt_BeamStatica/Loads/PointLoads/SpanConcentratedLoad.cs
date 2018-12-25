using Build_IT_BeamStatica.Loads.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;

namespace Build_IT_BeamStatica.Loads.PointLoads
{
    internal abstract class SpanConcentratedLoad : ConcentratedLoad, ISpanLoad
    {
        public double Position { get; }

        protected SpanConcentratedLoad(double value, double position = 0) : base(value)
        {
            Position = position;
        }

        public virtual double CalculateSpanLoadVectorNormalForceMember(ISpan span, bool leftNode) => 0;
        public virtual double CalculateSpanLoadVectorShearMember(ISpan span, bool leftNode) => 0;
        public virtual double CalculateSpanLoadBendingMomentMember(ISpan span, bool leftNode) => 0;
    }
}
