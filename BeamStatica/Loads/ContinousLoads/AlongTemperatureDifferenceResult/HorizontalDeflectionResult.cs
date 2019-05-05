using BeamStatica.Loads.ContinousLoads.LoadResults;
using BeamStatica.Loads.Interfaces;
using BeamStatica.Materials.Intefaces;
using BeamStatica.Spans.Interfaces;

namespace BeamStatica.Loads.ContinousLoads.AlongTemperatureDifferenceResult
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
