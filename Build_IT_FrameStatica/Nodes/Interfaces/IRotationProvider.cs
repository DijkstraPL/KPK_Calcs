using Build_IT_FrameStatica.Results.Interfaces;

namespace Build_IT_FrameStatica.Nodes.Interfaces
{
    public interface IRotationProvider
    {
        #region Properties

        IResultValue LeftRotation { get; }
        IResultValue RightRotation { get; }

        #endregion // Properties
    }
}
