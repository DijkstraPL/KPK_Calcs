using System;

namespace ReinforcementAnchoring.Coefficients
{
    /// <summary>
    /// Class containing helping methods for coefficients calculations.
    /// </summary>
    /// <example>
    /// <code>
    /// class TestClass
    /// {
    ///     static void Main()
    ///     {
    ///         ReinforcementPosition reinforcementPosition = new ReinforcementPosition(
    ///             false, AnchorageTypeEnum.Loop, 25, 25, 50, TransverseBarPositionEnum.AtTheTop);
    ///         CoefficientHelper coefficientHelper =
    ///                 new CoefficientHelper(reinforcementPosition);
    ///         coefficientHelper.CalculateCover();
    ///     }
    /// }
    /// </code>
    /// </example>
    internal class CoefficientHelper
    {
        #region Properties

        /// <summary>
        /// Information about the position of the reinforcement.
        /// </summary>
        public ReinforcementPosition ReinforcementPosition { get; private set; }

        #endregion // Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CoefficientHelper"/> class.
        /// </summary>
        /// <param name="reinforcementPosition">Set <see cref="ReinforcementPosition"/>.</param>
        public CoefficientHelper(ReinforcementPosition reinforcementPosition)
        {
            ReinforcementPosition = reinforcementPosition;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calculate cover for the element base on the anchorage type.
        /// </summary>
        /// <returns>Cover.</returns>
        internal double CalculateCover()
        {
            switch (ReinforcementPosition.AnchorageType)
            {
                case AnchorageTypeEnum.Straight:
                    return Math.Min(Math.Min(ReinforcementPosition.SideCoverDistance,
                        ReinforcementPosition.BottomCoverDistance),
                        ReinforcementPosition.DistanceBetweenBars / 2);
                case AnchorageTypeEnum.Bended_Hack:
                    return Math.Min(ReinforcementPosition.SideCoverDistance,
                        ReinforcementPosition.DistanceBetweenBars / 2);
                case AnchorageTypeEnum.Loop:
                    return ReinforcementPosition.BottomCoverDistance;
                default:
                    throw new ArgumentException("Anchorage type should be specified.");
            }
        }

        #endregion // Methods
    }
}
