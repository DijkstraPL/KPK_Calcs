﻿using Build_IT_BeamStatica.Loads.ContinousLoads.LoadResults;
using Build_IT_BeamStatica.Loads.Interfaces;

namespace Build_IT_BeamStatica.Loads.ContinousLoads.BendingMomentLoadResults
{
    internal class BendingMomentResult : ForceResultBase
    {
        #region Constructors

        public BendingMomentResult(IContinousLoad continousLoad) : base(continousLoad)
        {
        }

        #endregion // Constructors

        #region Public_Methods
        
        public override double GetValue(double distanceFromLoadStartPosition) 
            => ContinousLoad.StartPosition.Value * distanceFromLoadStartPosition;

        #endregion // Public_Methods
    }
}
