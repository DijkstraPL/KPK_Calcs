using BeamStatica.Loads.ContinousLoads.Interfaces;
using BeamStatica.Loads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads.ContinousLoads.LoadResults
{
    public abstract class ForceResultBase : ResultBase, IForceResult
    {
        protected ForceResultBase(IContinousLoad continousLoad) : base(continousLoad)
        {
        }

        public abstract double GetValue(double distanceFromLoadStartPosition);
    }
}
