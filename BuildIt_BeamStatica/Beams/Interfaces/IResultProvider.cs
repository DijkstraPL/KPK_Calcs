using Build_IT_BeamStatica.Results.Interfaces;

namespace Build_IT_BeamStatica.Beams.Interfaces
{
    public interface IResultProvider
    {
        #region Properties

        IGetResult NormalForceResult { get; }
        IGetResult ShearResult { get; }
        IGetResult BendingMomentResult { get; }
        IGetResult HorizontalDeflectionResult { get; }
        IGetResult VerticalDeflectionResult { get; }
        IGetResult RotationResult { get; }

        #endregion // Properties
    }
}
