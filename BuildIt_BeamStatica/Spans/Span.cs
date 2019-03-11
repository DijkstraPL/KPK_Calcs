﻿using Build_IT_BeamStatica.CalculationEngines.DirectStiffnessMethod.Spans;
using Build_IT_BeamStatica.CalculationEngines.DirectStiffnessMethod.Spans.Interfaces;
using Build_IT_BeamStatica.CalculationEngines.Interfaces;
using Build_IT_BeamStatica.Loads.Interfaces;
using Build_IT_BeamStatica.Materials.Intefaces;
using Build_IT_BeamStatica.Nodes.Interfaces;
using Build_IT_BeamStatica.Sections.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;
using Build_IT_Tools;
using System;
using System.Collections.Generic;

namespace Build_IT_BeamStatica.Spans
{
    internal class Span : ISpan
    {
        #region Properties

        public short Number { get; set; }

        public INode LeftNode { get; }
        [Abbreviation("L")]
        [Unit("m")]
        public double Length { get; }
        public INode RightNode { get; }
        public IMaterial Material { get; }
        public ISection Section { get; }

        public ICollection<IContinousLoad> ContinousLoads { get; private set; }
        public ICollection<ISpanLoad> PointLoads { get; private set; }
        
        public bool IncludeSelfWeight { get; set; }

        #endregion // Properties

        #region Constructors

        public Span(INode leftNode, double length, INode rightNode,
            IMaterial material, ISection section, bool includeSelfWeight)
        {
            LeftNode = leftNode ?? throw new ArgumentNullException(nameof(leftNode));
            Length = length;
            RightNode = rightNode ?? throw new ArgumentNullException(nameof(rightNode));
            Material = material ?? throw new ArgumentNullException(nameof(material));
            Section = section ?? throw new ArgumentNullException(nameof(section));

            ContinousLoads = new List<IContinousLoad>();
            PointLoads = new List<ISpanLoad>();

            IncludeSelfWeight = includeSelfWeight;
        }

        public Span(ISpanData spanData, bool includeSelfWeight)
            : this(spanData.LeftNode, spanData.Length, spanData.RightNode,
                  spanData.Material, spanData.Section, includeSelfWeight)
        {
        }
        
        #endregion // Constructors
    }
}