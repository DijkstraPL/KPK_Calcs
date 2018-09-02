using ReinforcementAnchoring.Interfaces;
using Tools;

namespace ReinforcementAnchoring.Coefficients
{
    /// <summary>
    /// Class containing informations about the bar form coefficient.
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
    ///         BarFormCoefficient barFormCoefficient = new BarFormCoefficient(reinforcementPosition, bar);
    ///         barFormCoefficient.Calculate();
    ///     }
    /// }
    /// </code>
    /// </example>
    public class BarFormCoefficient : ICoefficient
    {
        #region Properties

        /// <summary>
        /// Coefficient for include the effect of the form of the bars assuming adequate cover.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Table 8.2]</remarks>
        [Abbreviation("alpha_1")]
        [Unit("")]
        public double Coefficient { get; private set; } = 1;

        /// <summary>
        /// Informations about the position of the reinforcement.
        /// </summary>
        public ReinforcementPosition ReinforcementPosition { get; private set; }
        /// <summary>
        /// Informations about the bar.
        /// </summary>
        public Bar Bar { get; private set; }

        #endregion // Properties

        #region Fields

        private double cover;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BarFormCoefficient"/> class.
        /// </summary>
        /// <param name="reinforcementPosition">Set <see cref="ReinforcementPosition"/>.</param>
        /// <param name="bar">Set <see cref="Bar"/>.</param>
        public BarFormCoefficient(ReinforcementPosition reinforcementPosition, Bar bar)
        {
            ReinforcementPosition = reinforcementPosition;
            Bar = bar;
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Calculate the value of the <see cref="Coefficient"/>.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Table 8.2]</remarks>
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
