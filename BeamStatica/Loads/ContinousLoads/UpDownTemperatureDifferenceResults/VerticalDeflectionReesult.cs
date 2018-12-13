using BeamStatica.Loads.ContinousLoads.LoadResults;
using BeamStatica.Loads.Interfaces;
using BeamStatica.Spans.Interfaces;

namespace BeamStatica.Loads.ContinousLoads.UpDownTemperatureDifferenceResults
{
    public class VerticalDeflectionResult : DisplacementResultBase
    {
        public VerticalDeflectionResult(IContinousLoad continousLoad) : base(continousLoad)
        {
        }

        public override double GetValue(ISpan span, double distanceFromLeftSide, double currentLength) 
            => (ContinousLoad.StartPosition.Value - ContinousLoad.EndPosition.Value)
               / span.Section.SolidHeight
               * (distanceFromLeftSide - currentLength) / 10000
               * (distanceFromLeftSide - currentLength) / 2;
    }
}
