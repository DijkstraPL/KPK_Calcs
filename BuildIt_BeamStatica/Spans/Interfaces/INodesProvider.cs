using Build_IT_BeamStatica.Nodes.Interfaces;

namespace Build_IT_BeamStatica.Spans.Interfaces
{
    public interface INodesProvider
    {
        INode LeftNode { get; }
        INode RightNode { get; }
    }
}
