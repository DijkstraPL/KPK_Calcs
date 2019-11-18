using Build_IT_BeamStatica.Loads.Enums;
using Build_IT_BeamStatica.Nodes.Enums;
using Build_IT_Data.Sections.Additional.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Application.Statica.Calculations
{
    public class BeamDataResource
    {
        public IList<SpanResource> SpanResource { get; set; }
    }

    public class SpanResource
    {
        public double Length { get; set; }
        public MaterialResource MaterialResource { get; set; }
        public SectionPropertiesResource SectionPropertiesResource { get; set; }
        public NodeType LeftNode { get; set; }
        public NodeType RightNode { get; set; }
        public SpanResource NextSpan { get; set; }

        public IEnumerable<ContiniousLoad> ContinuousLoads { get; set; }
        public IEnumerable<PointLoad> PointLoads { get; set; }
    }

    public class PointLoad
    {
        public double Position { get; set; }
        public double Value { get; set; }
        public double Angle { get; set; }
        public PointLoadType PointLoadType { get; set; }
    }

    public class ContiniousLoad
    {
        public double StartPosition { get; set; }
        public double EndPosition { get; set; }
        public double StartValue { get; set; }
        public double EndValue { get; set; }
        public double Angle { get; set; }
        public ContinuousLoadType ContinuousLoadType { get; set; }
    }

  

    public class MaterialResource
    {
        public double YoungModulus { get; set; }
        public double Density { get; set; }
        public double ThermalExpansionCoefficient { get; set; }
    }

    public class SectionPropertiesResource
    {
        public IList<IPoint> Points { get; private set; }

        public SectionPropertiesResource()
        {
            Points = new List<IPoint>();
        }
    }
}
