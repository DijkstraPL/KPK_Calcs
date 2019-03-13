﻿using Build_IT_BeamStatica.Materials.Intefaces;
using Build_IT_BeamStatica.Nodes.Interfaces;
using Build_IT_BeamStatica.Sections.Interfaces;
using Build_IT_Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_BeamStatica.Spans.Interfaces
{
    public interface ISpanData
    {
        INode LeftNode { get; }
        [Abbreviation("L")]
        [Unit("m")]
        double Length { get; }
        INode RightNode { get; }
        IMaterial Material { get; }
        ISection Section { get; }
    }
}