using Build_IT_BeamStatica.CalculationEngines.DirectStiffnessMethod.Spans.Interfaces;
using Build_IT_BeamStatica.CalculationEngines.Interfaces;
using Build_IT_BeamStatica.Materials.Intefaces;
using Build_IT_BeamStatica.Sections.Interfaces;

namespace Build_IT_BeamStatica.Spans.Interfaces
{
    public interface ISpan : ILengthProvider, INodesProvider, ILoadProvider
    {
        #region Properties

        short Number { get; set; }
        ISection Section { get; }
        IMaterial Material { get; }

        bool IncludeSelfWeight { get; set; }

        #endregion // Properties
    }
}
