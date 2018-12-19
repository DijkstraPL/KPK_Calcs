using Build_IT_BeamStatica.Results.Interfaces;

namespace Build_IT_BeamStatica.Nodes.Interfaces
{
    public interface IRotationProvider
    {
        IResultValue LeftRotation { get; }
        IResultValue RightRotation { get; }
    }
}
