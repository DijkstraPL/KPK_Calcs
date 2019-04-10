using Build_IT_FrameStatica.Coords;
using Build_IT_FrameStatica.Nodes.Interfaces;
using System;

namespace Build_IT_FrameStatica.Nodes
{
    internal abstract class Node : INode
    {
        #region Properties

        public Point Position { get; private set; }

        #endregion // Properties

        #region Public_Methods

        #endregion // Public_Methods
    }
}
