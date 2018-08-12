using ReinforcementAnchoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementAnchoringTests
{
    public static class AnchoringHelper
    {
        public static ReinforcementPosition CreateReinforcementPosition() =>
            new ReinforcementPosition(true, AnchorageTypeEnum.Loop, 35, 35, 50, TransverseBarPositionEnum.AtTheTop);
    }
}
