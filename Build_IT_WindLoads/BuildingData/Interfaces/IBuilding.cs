using Build_IT_CommonTools;

namespace Build_IT_WindLoads.BuildingData.Interfaces
{
    public interface IBuilding
    {
        [Abbreviation("d")]
        [Unit("m")]
        double Length { get; }
        [Abbreviation("b")]
        [Unit("m")]
        double Width { get; }
        [Abbreviation("h")]
        [Unit("m")]
        double Height { get; }
    }
}