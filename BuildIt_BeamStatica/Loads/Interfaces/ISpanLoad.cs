using Build_IT_BeamStatica.Spans.Interfaces;

namespace Build_IT_BeamStatica.Loads.Interfaces
{
    public interface ISpanLoad : ILoadWithPosition, INodeLoad
    {
        double CalculateSpanLoadVectorNormalForceMember(ISpan span, bool leftNode);
        double CalculateSpanLoadVectorShearMember(ISpan span, bool leftNode);
        double CalculateSpanLoadBendingMomentMember(ISpan span, bool leftNode);
    }
}
