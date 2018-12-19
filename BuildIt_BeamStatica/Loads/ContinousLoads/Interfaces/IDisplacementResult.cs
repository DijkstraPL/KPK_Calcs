using Build_IT_BeamStatica.Spans.Interfaces;

namespace Build_IT_BeamStatica.Loads.ContinousLoads.Interfaces
{
    public interface IDisplacementResult
    {
        double GetValue(ISpan span, double distanceFromLeftSide, double currentLength);
    }
}
