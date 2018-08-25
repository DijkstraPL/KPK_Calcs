using KPK_CalcSite.Models.ReinforcementAnchoring;
using ReinforcementAnchoring;

namespace KPK_CalcSite.ViewModels
{
    public class ReinforcementAnchoringViewModel
    {
        public AnchoringAnchorageLength AnchoringAnchorageLength { get; set; }
        //public AnchoringConcreteClass AnchoringConcreteClass { get; set; }
        //public AnchoringReinforcement AnchoringReinforcement { get; set; }
        //public AnchoringReinforcementPosition AnchoringReinforcementPosition { get; set; }

        //public AnchoringBarFormCoefficient AnchoringBarFormCoefficient { get; set; }
        //public AnchoringCoverCoefficient AnchoringCoverCoefficient { get; set; }
        //public AnchoringTransverseReinforcementCoefficient AnchoringTransverseReinforcementCoefficient { get; set; }
        //public AnchoringWeldedTransverseBarCoefficient AnchoringWeldedTransverseBarCoefficient { get; set; }
        //public AnchoringTransversePressureCoefficient AnchoringTransversePressureCoefficient { get; set; }

        public bool CalculateBarFormCoefficient { get; set; }
        public bool CalculateCoverCoefficient { get; set; }
        public bool CalculateTransverseReinforcementCoefficient { get; set; }
        public bool CalculateWeldedTransverseBarCoefficient { get; set; }
        public bool CalculateTransversePressureCoefficient { get; set; }

        public ConcreteClassEnum ConcreteClassName { get; set; }
        public BondConditionEnum BondCondition { get; set; }
        public TypeEnum Type { get; set; }
        public double? TransverseReinforcementArea { get; set; }
        public TransverseBarPositionEnum TransverseBarPosition { get; set; }
        public double? TransversePressure { get; set; }
        public double? ReinforcementDiameter { get; set; } = null;
        public double? PressInReinforcement { get; set; } = null;
        public bool IsPairOfBars { get; set; }
        public bool AreAnchoragesInTension { get; set; }
        public AnchorageTypeEnum AnchorageType { get; set; }
        public double? BottomCoverDistance { get; set; }
        public double? SideCoverDistance { get; set; }
        public double? DistanceBetweenBars { get; set; }

        public bool ShowResults { get; set; } = false;
    }
}