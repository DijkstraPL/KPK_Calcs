using Build_IT_Tools;

namespace Build_IT_BeamStatica.Sections.Interfaces
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
