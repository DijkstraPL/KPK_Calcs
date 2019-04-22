namespace Build_IT_WindLoads
{
    public interface IWindLoadData
    {
        #region Public_Methods
        double GetTurbulenceIntensityAt(double height, bool adjustHeight = true);
        double GetMeanWindVelocityAt(double height, bool adjustHeight = true);
        double GetPeakVelocityPressureAt(double height);

        #endregion // Public_Methods
    }
}