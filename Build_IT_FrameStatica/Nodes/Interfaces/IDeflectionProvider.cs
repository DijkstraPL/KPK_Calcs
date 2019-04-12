using Build_IT_FrameStatica.Results.Interfaces;

namespace Build_IT_FrameStatica.Nodes.Interfaces
{
    public interface IDeflectionProvider
    {
        #region Properties

        IResultValue HorizontalDeflection { get; }
        IResultValue VerticalDeflection { get; }

        #endregion // Properties
    }
}
