using BeamStatica.Loads.ContinousLoads.LoadResults;
using BeamStatica.Loads.Interfaces;
using BeamStatica.Materials.Intefaces;
using BeamStatica.Spans.Interfaces;

namespace BeamStatica.Loads.ContinousLoads.AlongTemperatureDifferenceResult
{
    public class HorizontalDeflectionResult : DisplacementResultBase
    {
        private readonly IMaterial _material;

        public HorizontalDeflectionResult(IContinousLoad continousLoad,
            IMaterial material)
            : base(continousLoad)
        {
            _material = material;
        }

        public override double GetValue(ISpan span, double distanceFromLeftSide, double currentLength)
            => _material.ThermalExpansionCoefficient
               * (ContinousLoad.StartPosition.Value - ContinousLoad.EndPosition.Value)
               * (distanceFromLeftSide - currentLength)*100;
    }
}
