using BeamStatica.Nodes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Spans.Interfaces
{
    public interface INodesProvider
    {
        INode LeftNode { get; }
        INode RightNode { get; }
    }
}
