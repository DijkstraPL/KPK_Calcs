using System.ComponentModel.DataAnnotations;
using Tools;

namespace ReinforcementAnchoring
{
    /// <summary>
    /// Class containing informations about the reinforcement.
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
    ///     }
    /// }
    /// </code>
    /// </example>
    public class ReinforcementPosition
    {
        #region Properties
        /// <summary>
        /// Side cover distance.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Figure 8.3]</remarks>
        [Abbreviation("c_1")]
        [Unit("mm")]
        public double SideCoverDistance { get; set; }
        /// <summary>
        /// Bottom cover distance.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Figure 8.3]</remarks>
        [Abbreviation("c")]
        [Unit("mm")]
        public double BottomCoverDistance { get; set; }
        /// <summary>
        /// Distance between bars.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Figure 8.3]</remarks>
        [Abbreviation("a")]
        [Unit("mm")]
        public double DistanceBetweenBars { get; set; }

        /// <summary>
        /// Is anchorage in tension.
        /// </summary>
        public bool AreAnchoragesInTension { get; set; }

        /// <summary>
        /// Type of the anchorage.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Fig.8.1]</remarks>
        public AnchorageTypeEnum AnchorageType { get; set; }

        /// <summary>
        /// Position of the transverse bars.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Fig.8.4]</remarks>
        public TransverseBarPositionEnum TransverseBarPosition { get; set; }

        #endregion // Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReinforcementPosition"/> class.
        /// </summary>
        /// <param name="areAnchoragesInTension">Set <see cref="AreAnchoragesInTension"/>.</param>
        /// <param name="anchorageType">Set <see cref="AnchorageType"/>.</param>
        /// <param name="sideCoverDistance">Set <see cref="SideCoverDistance"/>.</param>
        /// <param name="bottomCoverDistance">Set <see cref="BottomCoverDistance"/>.</param>
        /// <param name="distanceBetweenBars">Set <see cref="DistanceBetweenBars"/>.</param>
        /// <param name="transverseBarPosition">Set <see cref="TransverseBarPosition"/>.</param>
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
    /// <summary>
    /// Enumerator for position of transverse bar.
    /// </summary>
    /// <remarks>[PN-EN 1992-1-1 Fig.8.4]</remarks>
    public enum TransverseBarPositionEnum
    {
        None,
        [Display(Name = "Inside of the bar bend")]
        InsideBend,
        [Display(Name = "At the top")]
        AtTheTop,
        [Display(Name = "At the bottom")]
        AtTheBottom
    }
    /// <summary>
    /// Enumerator for type of the anchorage.
    /// </summary>
    /// <remarks>[PN-EN 1992-1-1 Fig.8.1]</remarks>
    public enum AnchorageTypeEnum
    {
        None,
        Straight,
        Bended_Hack,
        Loop
    }


}
