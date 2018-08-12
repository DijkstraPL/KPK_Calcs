using ReinforcementAnchoring.Interfaces;
using System;
using Tools;

namespace ReinforcementAnchoring.Coefficients
{
    public class TransverseReinforcementCoefficient : ICoefficient
    {
        #region Properties

        [Abbreviation("alpha_3")]
        public double Coefficient { get; private set; } = 1;
        
        public ReinforcementPosition ReinforcementPosition { get; private set; }
        public Bar Bar { get; private set; }
        public TypeEnum Type { get; private set; }

        [Abbreviation("A_st,min")]
        public double MinReinforcementArea { get; private set; }
        [Abbreviation("A_st")]
        public double TransverseReinforcementArea { get; set; }

        #endregion // Properties

        #region Fields

        private double coefficientK;
        private double lambdaCoefficient;

        #endregion // Fields

        #region Constructors

        public TransverseReinforcementCoefficient(ReinforcementPosition reinforcementPosition,
            Bar bar, TypeEnum elementType, double transverseReinforcementArea)
        {
            ReinforcementPosition = reinforcementPosition;
            Bar = bar;
            Type = elementType;
            TransverseReinforcementArea = transverseReinforcementArea;
        }

        #endregion // Constructors

        #region Methods

        public void Calculate()
        {
            SetMinReinforcementArea();
            CalculateLambdaCoefficient();
            SetCoefficientK();
            //SetMinReinforcementArea();

            Coefficient = 1 - coefficientK * lambdaCoefficient;
            Coefficient = Math.Min(Coefficient, 1);
            Coefficient = Math.Max(0.7, Coefficient);
        }

        private void CalculateLambdaCoefficient()
        {
            lambdaCoefficient = (TransverseReinforcementArea - MinReinforcementArea) / Bar.Area;
        }

        private void SetMinReinforcementArea()
        {
            if (Type == TypeEnum.Beam)
                MinReinforcementArea = 0.25 * Bar.Area;
            else
                MinReinforcementArea = 0;
        }

        private void SetCoefficientK()
        {
            switch (ReinforcementPosition.TransverseBarPosition)
            {
                case TransverseBarPositionEnum.InsideBend:
                    coefficientK = 0.1;
                    break;
                case TransverseBarPositionEnum.AtTheTop:
                    coefficientK = 0.05;
                    break;
                default:
                    coefficientK = 0;
                    break;
            }
        }

        #endregion // Methods
    }
}
