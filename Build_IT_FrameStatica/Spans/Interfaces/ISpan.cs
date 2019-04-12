using Build_IT_Data.Materials.Intefaces;
using Build_IT_Data.Sections.Interfaces;

namespace Build_IT_FrameStatica.Spans.Interfaces
{
    public interface ISpan : ILengthProvider, INodesProvider, ILoadProvider
    {
        #region Properties

        short Number { get; set; }
        ISection Section { get; }
        IMaterial Material { get; }
        
        #endregion // Properties
    }
}
