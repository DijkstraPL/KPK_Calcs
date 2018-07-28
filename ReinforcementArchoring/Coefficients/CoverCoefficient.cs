using System;
using Tools;

namespace ReinforcementArchoring.Coefficients
{
    public class CoverCoefficient : ICoefficient
    {
        #region Properties

        [Abbreviation("alpha_2")]
        public double Coefficient { get; private set; } = 1;

        public ReinforcementPosition ReinforcementPosition { get; private set; }
        public Reinforcement Reinforcement { get; private set; }

        #endregion // Properties

        #region Fields

        private double cover;

        #endregion // Fields

        #region Constructors

        public CoverCoefficient(ReinforcementPosition reinforcementPosition, Reinforcement reinforcement)
        {
            ReinforcementPosition = reinforcementPosition;
            Reinforcement = reinforcement;
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
                Coefficient = 1 - 0.15 * (cover - Reinforcement.Diameter) / Reinforcement.Diameter;
            else
                Coefficient = 1 - 0.15 * (cover - 3 * Reinforcement.Diameter) / Reinforcement.Diameter;

            Coefficient = Math.Min(Coefficient, 1);
            Coefficient = Math.Max(0.7, Coefficient);
        }

        #endregion // Methods
    }
}
