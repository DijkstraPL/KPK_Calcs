using Build_IT_CommonTools.Attributes;
using Build_IT_Data.Materials.Intefaces;
using Build_IT_Data.Sections.Interfaces;
using Build_IT_FrameStatica.Loads.Interfaces;
using Build_IT_FrameStatica.Nodes.Interfaces;
using Build_IT_FrameStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;

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

        public ICollection<IContinousLoad> ContinousLoads { get; private set; }
        public ICollection<ISpanLoad> PointLoads { get; private set; }

        public bool IncludeSelfWeight { get; set; }

        #endregion // Properties

        #region Constructors

        public Span(INode leftNode, INode rightNode, IMaterial material, ISection section, bool includeSelfWeight)
        {
            LeftNode = leftNode ?? throw new ArgumentNullException(nameof(leftNode));
            RightNode = rightNode ?? throw new ArgumentNullException(nameof(rightNode));

            Material = material ?? throw new ArgumentNullException(nameof(material));
            Section = section ?? throw new ArgumentNullException(nameof(section));

            ContinousLoads = new List<IContinousLoad>();
            PointLoads = new List<ISpanLoad>();

            IncludeSelfWeight = includeSelfWeight;
        }

        #endregion // Constructors

        #region Public_Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Angle in degrees.</returns>
        public double GetAngle() =>
            Math.Atan((RightNode.Position.Y - LeftNode.Position.Y) /
            (RightNode.Position.X - LeftNode.Position.X)) * 180 / Math.PI;
            
        #endregion // Public_Methods
    }
}