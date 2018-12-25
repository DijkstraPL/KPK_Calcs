using Build_IT_BeamStatica.Loads.ContinousLoads.LoadResults;
using Build_IT_BeamStatica.Loads.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;

namespace Build_IT_BeamStatica.Loads.ContinousLoads.UpDownTemperatureDifferenceResults
{
    internal class VerticalDeflectionResult : DisplacementResultBase
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
