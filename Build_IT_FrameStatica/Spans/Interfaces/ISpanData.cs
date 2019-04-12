using Build_IT_FrameStatica.Nodes.Interfaces;
using Build_IT_CommonTools;
using Build_IT_Data.Materials.Intefaces;
using Build_IT_Data.Sections.Interfaces;

namespace Build_IT_FrameStatica.Spans.Interfaces
{
    public interface ISpanData
    {
        #region Properties

        INode LeftNode { get; }
        [Abbreviation("L")]
        [Unit("m")]
        double Length { get; }
        INode RightNode { get; }
        IMaterial Material { get; }
        ISection Section { get; }

        #endregion // Properties
    }
}
