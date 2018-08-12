using ReinforcementAnchoring.Interfaces;
using System;
using Tools;

namespace ReinforcementAnchoring.Coefficients
{
    public class CoverCoefficient : ICoefficient
    {
        #region Properties

        [Abbreviation("alpha_2")]
        public double Coefficient { get; private set; } = 1;

        public ReinforcementPosition ReinforcementPosition { get; private set; }
        public Bar Bar { get; private set; }

        #endregion // Properties

        #region Fields

        private double cover;

        #endregion // Fields

        #region Constructors

        public CoverCoefficient(ReinforcementPosition reinforcementPosition, Bar bar)
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

            if (!ReinforcementPosition.AreAnchoragesInTension)
                Coefficient = 1;
            else if (ReinforcementPosition.AnchorageType == AnchorageTypeEnum.Straight)
                Coefficient = 1 - 0.15 * (cover - Bar.Diameter) / Bar.Diameter;
            else
                Coefficient = 1 - 0.15 * (cover - 3 * Bar.Diameter) / Bar.Diameter;

            Coefficient = Math.Min(Coefficient, 1);
            Coefficient = Math.Max(0.7, Coefficient);
        }

        #endregion // Methods
    }
}
