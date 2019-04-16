using Build_IT_WindLoads.TerrainOrographies.Interfaces;

namespace Build_IT_WindLoads.TerrainOrographies
{
    internal class NoTerrainorography : ITerrainOrography
    {
        public double GetOrographicFactorAt(double verticalDistanceFromCrestTop)
            => 1;
    }
}