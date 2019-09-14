using Build_IT_BeamStatica.Nodes.Interfaces;
using Build_IT_BeamStatica.Spans;
using Build_IT_BeamStatica.Spans.Interfaces;
using Build_IT_Data.Materials.Intefaces;
using Build_IT_Data.Sections.Interfaces;

namespace Build_IT_BeamStatica.Factories
{
    internal static class SpanFactory
    {
        #region Public_Methods

        public static ISpan Create(INode leftNode, double length, INode rightNode,
            IMaterial material, ISection section)
        {
            return new Span(leftNode, length, rightNode, material, section, includeSelfWeight: true);
        }

        #endregion // Public_Methods
    }
}
