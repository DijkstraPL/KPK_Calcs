﻿namespace Build_IT_BeamStatica.Loads.ContinousLoads.Interfaces
{
    public interface IForceResult
    {
        #region Public_Methods

        double GetValue(double distanceFromLoadStartPosition);

        #endregion // Public_Methods
    }
}