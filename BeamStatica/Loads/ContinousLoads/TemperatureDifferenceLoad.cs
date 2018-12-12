using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeamStatica.Loads.Interfaces;
using BeamStatica.Spans.Interfaces;

namespace BeamStatica.Loads.ContinousLoads
{
    public class TemperatureDifferenceLoad : ContinousLoad
    {
        private double _temperatureDifference => EndPosition.Value - StartPosition.Value;
        private double _meanTemperature => (EndPosition.Value + StartPosition.Value) / 2;
        private readonly double _roomTemperature;

        public static IContinousLoad Create(ISpan span, 
            double upperTemperature, double lowerTemperature, double roomTemperature) 
            => new TemperatureDifferenceLoad(
                new Load(0, lowerTemperature),
                new Load(span.Length, upperTemperature),
                roomTemperature);

        private TemperatureDifferenceLoad(ILoadWithPosition startPosition, ILoadWithPosition endPosition, 
            double roomTemperature) : base(startPosition, endPosition)
        {
            _roomTemperature = roomTemperature;
        }

        public override double CalculateSpanLoadVectorNormalForceMember(ISpan span, bool leftNode) 
            => span.Material.ThermalExpansionCoefficient * (_meanTemperature - _roomTemperature)
                * span.Section.Area * span.Material.YoungModulus;

        public override double CalculateSpanLoadVectorBendingMomentMember(ISpan span, bool leftNode) 
            => span.Material.ThermalExpansionCoefficient * _temperatureDifference / span.Section.SolidHeight
                * span.Section.MomentOfInteria * span.Material.YoungModulus;
    }
}
