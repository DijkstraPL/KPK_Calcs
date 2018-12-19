using Build_IT_BeamStatica.Loads.ContinousLoads.LoadResults;
using Build_IT_BeamStatica.Loads.Interfaces;
using Build_IT_BeamStatica.Materials.Intefaces;
using Build_IT_BeamStatica.Spans.Interfaces;

namespace Build_IT_BeamStatica.Loads.ContinousLoads.AlongTemperatureDifferenceResult
{
    public class HorizontalDeflectionResult : DisplacementResultBase
    {
        public HorizontalDeflectionResult(IContinousLoad continousLoad)
            : base(continousLoad)
        {
        }

        public override double GetValue(ISpan span, double distanceFromLeftSide, double currentLength)
            => span.Material.ThermalExpansionCoefficient
               * (ContinousLoad.StartPosition.Value - ContinousLoad.EndPosition.Value)
               * (distanceFromLeftSide - currentLength)*100;
    }
}
