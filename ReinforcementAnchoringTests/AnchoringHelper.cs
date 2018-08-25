using ReinforcementAnchoring;

namespace ReinforcementAnchoringTests
{
    public static class AnchoringHelper
    {
        public static ReinforcementPosition CreateReinforcementPosition() =>
            new ReinforcementPosition(true, AnchorageTypeEnum.Loop, 35, 35, 50, TransverseBarPositionEnum.AtTheTop);
    }
}
