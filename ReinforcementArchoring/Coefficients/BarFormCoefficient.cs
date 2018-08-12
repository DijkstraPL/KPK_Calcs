using ReinforcementAnchoring.Interfaces;
using Tools;

namespace ReinforcementAnchoring.Coefficients
{
    public class BarFormCoefficient : ICoefficient
    {
        #region Properties

        [Abbreviation("alpha_1")]
        public double Coefficient { get; private set; } = 1;

        public ReinforcementPosition ReinforcementPosition { get; private set; }
        public Bar Bar { get; private set; }

        #endregion // Properties

        #region Fields

        private double cover;

        #endregion // Fields

        #region Constructors

        public BarFormCoefficient(ReinforcementPosition reinforcementPosition, Bar bar)
        {
            ReinforcementPosition = reinforcementPosition;
            Bar = bar;
        }
        
        #endregion // Constructors

        #region Methods

        public void Calculate()
        {
            var coefficientHelper = new CoefficientHelper(ReinforcementPosition);
            cover = coefficientHelper.CalculateCover();

            if (ReinforcementPosition.AnchorageType != AnchorageTypeEnum.Straight &&
                ReinforcementPosition.AreAnchoragesInTension && cover > 3 * Bar.Diameter)
                Coefficient = 0.7;
            else
                Coefficient = 1;
        }

        #endregion // Methods
    }
}
