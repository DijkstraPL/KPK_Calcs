using Build_IT_FrameStatica.Nodes.Interfaces;
using Build_IT_FrameStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Build_IT_FrameStaticaTests")]
namespace Build_IT_FrameStatica.Frames
{
    public class Frame
    {
        public short NumberOfDegreesOfFreedom { get; private set; }

        public IList<ISpan> Spans { get; }
        public ICollection<INode> Nodes { get; }

        public IFrameCalculationEngine CalculationEngine { get; private set; }

        public Frame(IList<ISpan> spans, ICollection<INode> nodes)
        {
            Spans = spans ?? throw new ArgumentNullException(nameof(spans));
            Nodes = nodes ?? throw new ArgumentNullException(nameof(nodes));

            CalculationEngine = new DirectStiffnessCalculationEngine(this);
        }
    }
}
