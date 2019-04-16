namespace Build_IT_WindLoads.TerrainOrographies.Interfaces
{
    // NOTE: In PN-EN there is plenty of errors, use EN
    public interface ITerrainOrography
    {
        double GetOrographicFactorAt(double verticalDistanceFromCrestTop);
    }
}