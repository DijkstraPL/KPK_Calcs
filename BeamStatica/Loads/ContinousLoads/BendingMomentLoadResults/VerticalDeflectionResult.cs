using BeamStatica.Loads.ContinousLoads.LoadResults;
using BeamStatica.Loads.Interfaces;
using BeamStatica.Spans.Interfaces;

namespace BeamStatica.Loads.ContinousLoads.BendingMomentLoadResults
{
    public class VerticalDeflectionResult : DisplacementResultBase
    {
        public VerticalDeflectionResult(IContinousLoad continousLoad) : base(continousLoad)
        {
        }

        public override double GetValue(ISpan span, double distanceFromLeftSide, double currentLength)
        {
            double distanceFromTheClosestLeftNode = distanceFromLeftSide - currentLength;

            return ContinousLoad.StartPosition.Value
                * distanceFromTheClosestLeftNode
                * distanceFromTheClosestLeftNode / 2
                * distanceFromTheClosestLeftNode / 3
               / (span.Material.YoungModulus * span.Section.MomentOfInteria);
        }
    }
}
