using Build_IT_CommonTools;

namespace Build_IT_BeamStatica.Sections.Interfaces
{
    public interface IMomentOfInteria
    {
        #region Properties

        [Abbreviation("I")]
        [Unit("cm4")]
        double MomentOfInteria { get; }

        #endregion // Properties
    }
}
