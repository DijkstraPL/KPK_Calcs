using Build_IT_FrameStatica.Results.Interfaces;

namespace Build_IT_FrameStatica.Nodes.Interfaces
{
    public interface INormalForceProvider
    {
        #region Properties

        IResultValue HorizontalForce { get; }

        #endregion // Properties
    }
}
