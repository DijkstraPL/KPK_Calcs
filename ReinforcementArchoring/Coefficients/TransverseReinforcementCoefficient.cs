using Tools;

namespace ReinforcementArchoring.Coefficients
{
    public class TransverseReinforcementCoefficient : ICoefficient
    {
        #region Properties

        [Abbreviation("alpha_3")]
        public double Coefficient { get; private set; } = 1;
        
        public ReinforcementPosition ReinforcementPosition { get; private set; }
        public Reinforcement Reinforcement { get; private set; }
        public TypeEnum Type { get; private set; }

        [Abbreviation("A_st,min")]
        public double MinReinforcementArea { get; private set; }
        [Abbreviation("A_st")]
        public double ReinforcementArea { get; set; }

        #endregion // Properties

        #region Fields

        private double coefficientK;
        private double lambdaCoefficient;

        #endregion // Fields

        #region Constructors

        public TransverseReinforcementCoefficient(ReinforcementPosition reinforcementPosition,
            Reinforcement reinforcement, TypeEnum elementType, double reinforcementArea)
        {
            ReinforcementPosition = reinforcementPosition;
            Reinforcement = reinforcement;
            Type = elementType;
            ReinforcementArea = reinforcementArea;
        }

        #endregion // Constructors

        #region Methods

        public void Calculate()
        {
            CalculateLambdaCoefficient();
            SetCoefficientK();
            SetMinReinforcementArea();

            Coefficient = 1 - coefficientK * lambdaCoefficient;
        }

        private void CalculateLambdaCoefficient()
        {
            SetMinReinforcementArea();
            double singleBarArea = Reinforcement.GetArea();
            lambdaCoefficient = (ReinforcementArea - MinReinforcementArea) / singleBarArea;
        }

        private void SetMinReinforcementArea()
        {
            if (Type == TypeEnum.Beam)
                MinReinforcementArea = 0.25 * ReinforcementArea;
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
