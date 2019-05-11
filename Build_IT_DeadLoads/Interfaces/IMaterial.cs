using Build_IT_Data.Units.Enums;

namespace Build_IT_DeadLoads.Interfaces
{
    public interface IMaterial
    {
        string Name { get; }
        double MaximumDensity { get; }
        double MinimumDensity { get;}
        LoadUnit Unit { get; }
    }
}