using Build_IT_BeamStatica.Loads.ContinousLoads.LoadResults;
using Build_IT_BeamStatica.Loads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStatica.Loads.ContinousLoads.BendingMomentLoadResults
{
    public class BendingMomentResult : ForceResultBase
    {
        public BendingMomentResult(IContinousLoad continousLoad) : base(continousLoad)
        {
        }

        public override double GetValue(double distanceFromLoadStartPosition) 
            => ContinousLoad.StartPosition.Value * distanceFromLoadStartPosition;
    }
}
