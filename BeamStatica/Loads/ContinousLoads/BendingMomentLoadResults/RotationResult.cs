using BeamStatica.Loads.ContinousLoads.LoadResults;
using BeamStatica.Loads.Interfaces;
using BeamStatica.Spans.Interfaces;

namespace BeamStatica.Loads.ContinousLoads.BendingMomentLoadResults
{
    public class RotationResult : DisplacementResultBase
    {
        public RotationResult(IContinousLoad continousLoad) : base(continousLoad)
        {
        }

        public override double GetValue(ISpan span, double distanceFromLeftSide, double currentLength)
        {
            double distanceFromTheClosestLeftNode = distanceFromLeftSide - currentLength;

            return ContinousLoad.StartPosition.Value 
                * distanceFromTheClosestLeftNode / 2 
                * distanceFromTheClosestLeftNode
               / (span.Material.YoungModulus * span.Section.MomentOfInteria);
        }
    }
}
