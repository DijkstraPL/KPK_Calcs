using Build_IT_FrameStatica.Nodes.Interfaces;
using Build_IT_CommonTools;
using System;
using System.Collections.Generic;
using Build_IT_Data.Materials.Intefaces;
using Build_IT_Data.Sections.Interfaces;
using Build_IT_FrameStatica.Spans.Interfaces;
using Build_IT_FrameStatica.Loads.Interfaces;

namespace Build_IT_FrameStatica.Spans
{
    internal class Span : ISpan
    {
        #region Properties

        public short Number { get; set; }

        public INode LeftNode { get; }
        [Abbreviation("L")]
        [Unit("m")]
        public double Length => LeftNode.Position.DistanceTo(RightNode.Position);
        public INode RightNode { get; }

        public IMaterial Material { get; }
        public ISection Section { get; }

        public ICollection<IContinousLoad> ContinousLoads => throw new NotImplementedException();

        public ICollection<ISpanLoad> PointLoads => throw new NotImplementedException();

        #endregion // Properties

        #region Constructors

        public Span(INode leftNode, INode rightNode, IMaterial material, ISection section)
        {
            LeftNode = leftNode ?? throw new ArgumentNullException(nameof(leftNode));
            RightNode = rightNode ?? throw new ArgumentNullException(nameof(rightNode));

            Material = material ?? throw new ArgumentNullException(nameof(material));
            Section = section ?? throw new ArgumentNullException(nameof(section));
        }
        
        #endregion // Constructors
    }
}