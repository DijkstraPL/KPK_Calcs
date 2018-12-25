using Build_IT_BeamStatica.Loads.Interfaces;
using System;

namespace Build_IT_BeamStatica.Loads.ContinousLoads.LoadResults
{
    internal abstract class ResultBase
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
