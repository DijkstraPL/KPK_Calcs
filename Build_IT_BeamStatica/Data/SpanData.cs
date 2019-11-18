using Build_IT_BeamStatica.Nodes.Enums;
using System.Collections.Generic;

namespace Build_IT_BeamStatica.Data
{
    public class SpanData
    {
        public double Length { get; set; }
        public MaterialData MaterialData { get; set; }
        public SectionPropertiesData SectionPropertiesData { get; set; }
        public NodeType LeftNode { get; set; }
        public NodeType RightNode { get; set; }

        public IEnumerable<ContiniousLoadData> ContinuousLoads { get; set; }
        public IEnumerable<PointLoadData> PointLoads { get; set; }
    }
}
