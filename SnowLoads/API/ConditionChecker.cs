using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads.API
{
    public static class ConditionChecker
    {
        public static bool ForDesignSituation(bool exceptionalSituation, DesignSituation designSituation, bool annexB)
        {
            if (exceptionalSituation)
                switch (designSituation)
                {
                    case DesignSituation.A:
                        return false;
                    case DesignSituation.B1:
                        return !annexB;
                    case DesignSituation.B2:
                        return annexB;
                    case DesignSituation.B3:
                        return true;
                    default:
                        return false;
                }

            if (!annexB)
                return true;
            return false;
        }
    }
}
