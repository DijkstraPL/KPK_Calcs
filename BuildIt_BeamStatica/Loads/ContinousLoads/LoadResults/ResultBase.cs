using Build_IT_BeamStatica.Loads.ContinousLoads.Interfaces;
using Build_IT_BeamStatica.Loads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStatica.Loads.ContinousLoads.LoadResults
{
    public abstract class ResultBase
    {
        protected IContinousLoad ContinousLoad { get; }

        protected ResultBase(IContinousLoad continousLoad)
        {
            ContinousLoad = continousLoad ?? throw new ArgumentNullException(nameof(continousLoad));
        }

        protected double GetForceAtTheCalculatedPoint(double distanceFromLoadStartPosition)
            => (ContinousLoad.EndPosition.Value - ContinousLoad.StartPosition.Value) /
               ContinousLoad.Length *
               distanceFromLoadStartPosition +
               ContinousLoad.StartPosition.Value;
    }
}
