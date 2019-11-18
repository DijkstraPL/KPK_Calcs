using Build_IT_BeamStatica.Beams;
using Build_IT_BeamStatica.Beams.Interfaces;
using Build_IT_BeamStatica.Nodes.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;
using System.Collections.Generic;

namespace Build_IT_BeamStatica.Factories
{
    internal static class BeamFactory
    {
        #region Public_Methods
        
        public static IBeam Create(IList<ISpan> spans, ICollection<INode> nodes)
        {
            return new Beam(spans, nodes, includeSelfWeight: true);
        }

        #endregion // Public_Methods
    }
}
