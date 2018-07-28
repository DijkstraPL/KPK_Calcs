using Tools;

namespace ReinforcementArchoring
{
    public class ReinforcementPosition
    {
        #region Properties

        [Abbreviation("c_1")]
        internal double SideCoverDistance { get; set; }
        [Abbreviation("c")]
        internal double BottomCoverDistance { get; set; }
        [Abbreviation("a")]
        internal double DistanceBetweenBars { get; set; }

        public bool AreAnchoragesInTension { get; set; }

        public AnchorageTypeEnum AnchorageType { get; set; }

        public TransverseBarPositionEnum TransverseBarPosition { get; set; }

        #endregion // Properties

        #region Constructors

        public ReinforcementPosition(
            AnchorageTypeEnum anchorageType,
            double sideCoverDistance,
            double bottomCoverDistance,
            double distanceBetweenBars)
        {
            SideCoverDistance = sideCoverDistance;
            BottomCoverDistance = bottomCoverDistance;
            DistanceBetweenBars = distanceBetweenBars;
            AnchorageType = anchorageType;
        } 
        #endregion // Constructors
    }
    public enum TransverseBarPositionEnum
    {
        None,
        InsideBend,
        AtTheTop,
        AtTheBottom
    }
    public enum AnchorageTypeEnum
    {
        None,
        Straight,
        Bended_Hack,
        Loop
    }


}
