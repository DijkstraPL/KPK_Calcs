using ReinforcementAnchoring.Interfaces;
using System;
using Tools;

namespace ReinforcementAnchoring.Coefficients
{
    public class TransversePressureCoefficient : ICoefficient
    {
        #region Properties

        [Abbreviation("alpha_5")]
        public double Coefficient { get; private set; } = 1;

        [Abbreviation("p")]
        public double TransversePressure { get; set; }

        public ReinforcementPosition ReinforcementPosition { get; private set; }

        #endregion // Properties
        
        #region Constructors

        public TransversePressureCoefficient(ReinforcementPosition reinforcementPosition, 
            double transversePressure)
        {
            ReinforcementPosition = reinforcementPosition;
            TransversePressure = transversePressure;
        }

        #endregion // Constructors

        #region Methods

        public void Calculate()
        {
            if (ReinforcementPosition.AreAnchoragesInTension)
            {
                Coefficient = 1 - 0.04 * TransversePressure;

                Coefficient = Math.Min(Coefficient, 1);
                Coefficient = Math.Max(0.7, Coefficient);
            }
        }

        #endregion // Methods
    }
}
