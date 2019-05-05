using BeamStatica.Loads.Interfaces;
using BeamStatica.Spans.Interfaces;

namespace BeamStatica.Loads.PointLoads
{
    public abstract class SpanConcentratedLoad : ConcentratedLoad, ISpanLoad
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
