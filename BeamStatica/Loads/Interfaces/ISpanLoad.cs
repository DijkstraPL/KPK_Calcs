using BeamStatica.Spans.Interfaces;

namespace BeamStatica.Loads.Interfaces
{
    public interface ISpanLoad : ILoadWithPosition, INodeLoad
    {
        double CalculateSpanLoadVectorNormalForceMember(ISpan span, bool leftNode);
        double CalculateSpanLoadVectorShearMember(ISpan span, bool leftNode);
        double CalculateSpanLoadBendingMomentMember(ISpan span, bool leftNode);
    }
}
