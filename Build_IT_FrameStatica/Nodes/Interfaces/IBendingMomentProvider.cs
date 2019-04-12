using Build_IT_FrameStatica.Results.Interfaces;

namespace Build_IT_FrameStatica.Nodes.Interfaces
{
    public interface IBendingMomentProvider
    {
        #region Properties

        IResultValue BendingMoment { get; }

        #endregion // Properties
    }
}
