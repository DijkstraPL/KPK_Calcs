using ReinforcementAnchoring.Interfaces;
using System;
using Tools;

namespace ReinforcementAnchoring.Coefficients
{
    /// <summary>
    /// Class containing information about the transverse reinforcement coefficient.
    /// </summary>
    /// <example>
    /// <code>
    /// class TestClass
    /// {
    ///     static void Main()
    ///     {
    ///         Bar bar = new Bar(12);
    ///         ReinforcementPosition reinforcementPosition =
    ///             new ReinforcementPosition(true, AnchorageTypeEnum.Loop, 25, 25, 50,
    ///             TransverseBarPositionEnum.InsideBend);
    ///         TransverseReinforcementCoefficient transverseReinforcementCoefficient = 
    ///             new TransverseReinforcementCoefficient(reinforcementPosition, bar, 
    ///             TypeEnum.Beam, 10);
    ///         transverseReinforcementCoefficient.Calculate();
    ///     }
    /// }
    /// </code>
    /// </example>
    public class TransverseReinforcementCoefficient : ICoefficient
    {
        #region Properties

        /// <summary>
        /// Coefficient for include the effect of confinement by transverse reinforcement.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Table 8.2]</remarks>
        [Abbreviation("alpha_3")]
        [Unit("")]
        public double Coefficient { get; private set; } = 1;

        /// <summary>
        /// Information about the position of the reinforcement.
        /// </summary>
        public ReinforcementPosition ReinforcementPosition { get; private set; }
        /// <summary>
        /// Information about the bar.
        /// </summary>
        public Bar Bar { get; private set; }
        /// <summary>
        /// Type of the element.
        /// </summary>
        public TypeEnum Type { get; private set; }

        /// <summary>
        /// Minimum reinforcement area.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Table 8.2]</remarks>
        [Abbreviation("A_st,min")]
        [Unit("cm2")]
        public double MinReinforcementArea { get; private set; }
        /// <summary>
        /// Area of the transverse reinforcement.
        /// </summary>
        [Abbreviation("A_st")]
        [Unit("cm2")]
        public double TransverseReinforcementArea { get; set; }

        #endregion // Properties

        #region Fields

        private double coefficientK;
        private double lambdaCoefficient;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TransverseReinforcementCoefficient"/> class.
        /// </summary>
        /// <param name="reinforcementPosition">Set <see cref="ReinforcementPosition"/>.</param>
        /// <param name="bar">Set <see cref="Bar"/>.</param>
        /// <param name="elementType">Set <see cref="Type"/>.</param>
        /// <param name="transverseReinforcementArea">Set <see cref="TransverseReinforcementArea"/>.</param>
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

        /// <summary>
        /// Calculate the value of the <see cref="Coefficient"/>.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Table 8.2]</remarks>
        public void Calculate()
        {
            SetMinReinforcementArea();
            CalculateLambdaCoefficient();
            SetCoefficientK();

            if (!ReinforcementPosition.AreAnchoragesInTension)
                Coefficient = 1;
            else
            {
                Coefficient = 1 - coefficientK * lambdaCoefficient;
                Coefficient = Math.Min(Coefficient, 1);
                Coefficient = Math.Max(0.7, Coefficient);
            }
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
