namespace Build_IT_WindLoads
{
    public interface IWindLoadData
    {
        #region Public_Methods
        double GetTurbulenceIntensityAt(double height);
        double GetMeanWindVelocityAt(double height);
        double GetPeakVelocityPressureAt(double height);

        #endregion // Public_Methods
    }
}