using System;

namespace ReinforcementAnchoring.Coefficients
{
    internal class CoefficientHelper
    {
        #region Properties

        public ReinforcementPosition ReinforcementPosition { get; private set; }

        #endregion // Properties

        #region Constructors

        public CoefficientHelper(ReinforcementPosition reinforcementPosition)
        {
            ReinforcementPosition = reinforcementPosition;
        }

        #endregion

        #region Methods

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
