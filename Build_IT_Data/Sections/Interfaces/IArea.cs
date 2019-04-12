using Build_IT_CommonTools;

namespace Build_IT_Data.Sections.Interfaces
{
    public interface IArea
    {
        #region Properties

        [Abbreviation("A")]
        [Unit("cm2")]
        double Area { get; }

        #endregion // Properties
    }
}
