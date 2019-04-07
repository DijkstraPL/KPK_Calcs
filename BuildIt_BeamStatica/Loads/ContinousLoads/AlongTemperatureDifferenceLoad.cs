using Build_IT_BeamStatica.Loads.ContinousLoads.AlongTemperatureDifferenceResult;
using Build_IT_BeamStatica.Loads.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;

namespace Build_IT_BeamStatica.Loads.ContinousLoads
{
    internal class AlongTemperatureDifferenceLoad : ContinousLoad
    {
        #region Factories

        public static IContinousLoad Create(ISpan span, double temperatureDifference)
        {
            return new AlongTemperatureDifferenceLoad(
                           new LoadData(0, 0),
                           new LoadData(span.Length, temperatureDifference));
        }

        #endregion // Factories

        #region Constructors

        private AlongTemperatureDifferenceLoad(
            ILoadWithPosition startPosition, ILoadWithPosition endPosition)
            : base(startPosition, endPosition)
        {
            HorizontalDeflectionResult = new HorizontalDeflectionResult(this);
        }

        #endregion // Constructors

        #region Public_Methods

        public override double CalculateSpanLoadVectorNormalForceMember(ISpan span, bool leftNode)
        {
            double sign = leftNode ? 1.0 : -1.0;
             return sign * span.Material.ThermalExpansionCoefficient 
                * (EndPosition.Value - StartPosition.Value)
                * span.Section.Area * span.Material.YoungModulus * 100;
        }

        #endregion // Public_Methods
    }
}
