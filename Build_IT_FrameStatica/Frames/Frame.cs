﻿using Build_IT_FrameStatica.CalculationEngines.DirectStiffnessMethod;
using Build_IT_FrameStatica.CalculationEngines.DirectStiffnessMethod.Frames;
using Build_IT_FrameStatica.CalculationEngines.Interfaces;
using Build_IT_FrameStatica.Frames.Interfaces;
using Build_IT_FrameStatica.Nodes.Interfaces;
using Build_IT_FrameStatica.Results.Interfaces;
using Build_IT_FrameStatica.Results.OnSpan;
using Build_IT_FrameStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Build_IT_FrameStaticaTests")]
[assembly: InternalsVisibleTo("Build_IT_FrameStaticaAcceptanceTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Build_IT_FrameStatica.Frames
{
    public class Frame : IFrame
    {
        #region Properties
        
        public short NumberOfDegreesOfFreedom { get; private set; }

        public IList<ISpan> Spans { get; }
        public ICollection<INode> Nodes { get; }

        public IFrameCalculationEngine CalculationEngine { get; private set; }

        public bool IncludeSelfWeight => throw new NotImplementedException();
        public IResultsContainer Results { get; }

        #endregion // Properties

        public Frame(IList<ISpan> spans, ICollection<INode> nodes)
        {
            Spans = spans ?? throw new ArgumentNullException(nameof(spans));
            Nodes = nodes ?? throw new ArgumentNullException(nameof(nodes));

            CalculationEngine = new DirectStiffnessCalculationEngine(this);
            Results = new ResultsContainer(this);
        }
        
        public void SetNumeration()
        {
            short spanCounter = 0;
            short nodeCounter = 0;

            spanCounter = SetSpanNumeration(spanCounter);
            nodeCounter = SetNodeNumeration(nodeCounter);

            SetNumberOfDegreesOfFreedom();
        }

        #region Private_Methods

        private void SetNumberOfDegreesOfFreedom()
        {
            foreach (var node in Nodes)
                NumberOfDegreesOfFreedom += node.DegreesOfFreedom;
        }

        private short SetSpanNumeration(short spanCounter)
        {
            foreach (var span in Spans)
                span.Number = spanCounter++;
            return spanCounter;
        }

        private short SetNodeNumeration(short nodeCounter)
        {
            foreach (var node in Nodes)
                node.SetDisplacementNumeration(ref nodeCounter);
            foreach (var node in Nodes)
                node.SetReactionNumeration(ref nodeCounter);
            return nodeCounter;
        }

        #endregion // Private_Methods
    }
}
