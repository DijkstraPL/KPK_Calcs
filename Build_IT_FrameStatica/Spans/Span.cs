using Build_IT_FrameStatica.Nodes.Interfaces;
using Build_IT_CommonTools;
using System;
using System.Collections.Generic;

namespace Build_IT_FrameStatica.Spans
{
    internal class Span
    {
        #region Properties

        public short Number { get; set; }

        public INode LeftNode { get; }
        [Abbreviation("L")]
        [Unit("m")]
        public double Length => LeftNode.Position.DistanceTo(RightNode.Position);
        public INode RightNode { get; }
                
        #endregion // Properties

        #region Constructors

        public Span(INode leftNode, INode rightNode)
        {
            LeftNode = leftNode ?? throw new ArgumentNullException(nameof(leftNode));
            RightNode = rightNode ?? throw new ArgumentNullException(nameof(rightNode));
           
        }
        
        #endregion // Constructors
    }
}