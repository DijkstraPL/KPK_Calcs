namespace Build_IT_BeamStatica.Loads.ContinousLoads.Interfaces
{
    public interface IForceResult
    {
        double GetValue(double distanceFromLoadStartPosition);
    }
}
