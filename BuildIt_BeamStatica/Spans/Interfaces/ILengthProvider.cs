using Build_IT_Tools;

namespace Build_IT_BeamStatica.Spans.Interfaces
{
    public interface ILengthProvider
    {
        #region Properties

        [Abbreviation("L")]
        [Unit("m")]
        double Length { get; }

        #endregion // Properties
    }
}
