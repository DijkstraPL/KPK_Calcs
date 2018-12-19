using Build_IT_BeamStatica.Nodes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStatica.Spans.Interfaces
{
    public interface INodesProvider
    {
        INode LeftNode { get; }
        INode RightNode { get; }
    }
}
