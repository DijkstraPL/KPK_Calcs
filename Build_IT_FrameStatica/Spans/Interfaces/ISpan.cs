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
        internal Forces LeftForces { get; }
        internal Forces RightForces { get; }
        internal Displacements LeftDisplacements { get; }
        internal Displacements RightDisplacements { get; } 

        #endregion // Properties

        #region Public_Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Angle in degrees.</returns>
        double GetAngle();
        internal double GetLambdaX();
        internal double GetLambdaY();

        #endregion // Public_Methods
    }
}
