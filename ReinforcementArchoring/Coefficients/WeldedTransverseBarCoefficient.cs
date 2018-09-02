using ReinforcementAnchoring.Interfaces;
using Tools;

namespace ReinforcementAnchoring.Coefficients
{
    /// <summary>
    /// Class containing information about the welded transverse bars coefficient.
    /// </summary>
    /// <example>
    /// <code>
    /// class TestClass
    /// {
    ///     static void Main()
    ///     {
    ///         WeldedTransverseBarCoefficient weldedTransverseBarCoefficient =
    ///               new WeldedTransverseBarCoefficient();
    ///         weldedTransverseBarCoefficient.Calculate();
    ///     }
    /// }
    /// </code>
    /// </example>
    public class WeldedTransverseBarCoefficient : ICoefficient
    {
        #region Properties

        /// <summary>
        /// Coefficient for include the effect of one or more welded transverse bars along the design anchorage length.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Table 8.2]</remarks>
        [Abbreviation("alpha_4")]
        [Unit("")]
        public double Coefficient { get; private set; } = 1;

        #endregion // Properties

        #region Methods

        /// <summary>
        /// Calculate the value of the <see cref="Coefficient"/>.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Table 8.2]</remarks>
        public void Calculate()
        {
            Coefficient = 0.7;
        }

        #endregion // Methods
    }
}
