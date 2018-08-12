using System.ComponentModel.DataAnnotations;
using Tools;

namespace ReinforcementAnchoring
{
    public class ReinforcementPosition
    {
        #region Properties

        [Abbreviation("c_1")]
        public double SideCoverDistance { get; set; }
        [Abbreviation("c")]
        public double BottomCoverDistance { get; set; }
        [Abbreviation("a")]
        public double DistanceBetweenBars { get; set; }

        public bool AreAnchoragesInTension { get; set; }

        public AnchorageTypeEnum AnchorageType { get; set; }

        public TransverseBarPositionEnum TransverseBarPosition { get; set; }

        #endregion // Properties

        #region Constructors
        
        public ReinforcementPosition(
            bool areAnchoragesInTension,
            AnchorageTypeEnum anchorageType,
            double sideCoverDistance,
            double bottomCoverDistance,
            double distanceBetweenBars,
            TransverseBarPositionEnum transverseBarPosition)
        {
            AreAnchoragesInTension = areAnchoragesInTension;
            SideCoverDistance = sideCoverDistance;
            BottomCoverDistance = bottomCoverDistance;
            DistanceBetweenBars = distanceBetweenBars;
            AnchorageType = anchorageType;
            TransverseBarPosition = transverseBarPosition;
        } 
        #endregion // Constructors
    }
    public enum TransverseBarPositionEnum
    {
        None,
        [Display(Name ="Inside of the bar bend")]
        InsideBend,
        [Display(Name = "At the top")]
        AtTheTop,
        [Display(Name = "At the bottom")]
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
