using Build_IT_FrameStatica.Frames.Interfaces;
using Build_IT_FrameStatica.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_FrameStatica.Results.OnSpan
{
    internal class ResultsContainer : IResultsContainer
    {
        #region Properties

        public IGetResult NormalForce { get; }
        public IGetResult Shear { get; }
        public IGetResult BendingMoment { get; }
        public IGetResult HorizontalDeflection { get; }
        public IGetResult VerticalDeflection { get; }
        public IGetResult Rotation { get; }

        #endregion // Properties

        #region Fields

        private IFrame _frame;

        #endregion // Fields

        #region Constructors

        public ResultsContainer(IFrame frame)
        {
            _frame = frame;

            NormalForce = new NormalForceResult(_frame);
            Shear = new ShearResult(_frame);
            BendingMoment = new BendingMomentResult(_frame);
            HorizontalDeflection = new HorizontalDeflectionResult(_frame);
            VerticalDeflection = new VerticalDeflectionResult(_frame);
            Rotation = new RotationResult(_frame);
        }

        #endregion // Constructors
    }
}
