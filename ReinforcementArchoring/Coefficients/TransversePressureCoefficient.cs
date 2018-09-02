using ReinforcementAnchoring.Interfaces;
using System;
using Tools;

namespace ReinforcementAnchoring.Coefficients
{
    /// <summary>
    /// Class containing information about the transverse pressure coefficient.
    /// </summary>
    /// <example>
    /// <code>
    /// class TestClass
    /// {
    ///     static void Main()
    ///     {
    ///         ReinforcementPosition reinforcementPosition =
    ///             new ReinforcementPosition(true, AnchorageTypeEnum.Loop, 25, 25, 50,
    ///             TransverseBarPositionEnum.InsideBend);
    ///         TransversePressureCoefficient transversePressureCoefficient =
    ///               new TransversePressureCoefficient(reinforcementPosition, 10);
    ///         transversePressureCoefficient.Calculate();
    ///     }
    /// }
    /// </code>
    /// </example>
    public class TransversePressureCoefficient : ICoefficient
    {
        #region Properties

        /// <summary>
        /// Coefficient for include the effect of the pressure transverse 
        /// to the plane of splitting along the design anchorage length.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Table 8.2]</remarks>
        [Abbreviation("alpha_5")]
        [Unit("")]
        public double Coefficient { get; private set; } = 1;

        /// <summary>
        /// Transverse pressure at ultimate limit state along desing anchorage length.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Table 8.2]</remarks>
        [Abbreviation("p")]
        [Unit("MPa")]
        public double TransversePressure { get; set; }

        /// <summary>
        /// Informations about the position of the reinforcement.
        /// </summary>
        public ReinforcementPosition ReinforcementPosition { get; private set; }

        #endregion // Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TransversePressureCoefficient"/> class.
        /// </summary>
        /// <param name="reinforcementPosition">Set <see cref="ReinforcementPosition"/>.</param>
        /// <param name="transversePressure">Set <see cref="TransversePressure"/>.</param>
        public TransversePressureCoefficient(ReinforcementPosition reinforcementPosition,
            double transversePressure)
        {
            ReinforcementPosition = reinforcementPosition;
            TransversePressure = transversePressure;
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Calculate the value of the <see cref="Coefficient"/>.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Table 8.2]</remarks>
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
