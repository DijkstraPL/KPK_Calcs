using Build_IT_BeamStatica.Loads.ContinousLoads.Interfaces;
using Build_IT_BeamStatica.Loads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStatica.Loads.ContinousLoads.LoadResults
{
    public abstract class ForceResultBase : ResultBase, IForceResult
    {
        protected ForceResultBase(IContinousLoad continousLoad) : base(continousLoad)
        {
        }

        public abstract double GetValue(double distanceFromLoadStartPosition);
    }
}
