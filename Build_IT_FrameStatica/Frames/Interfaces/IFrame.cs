﻿using Build_IT_FrameStatica.CalculationEngines.Interfaces;
using Build_IT_FrameStatica.Nodes.Interfaces;
using Build_IT_FrameStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_FrameStatica.Frames.Interfaces
{
    public  interface IFrame
    {
        #region Properties

        IList<ISpan> Spans { get; }
        ICollection<INode> Nodes { get; }
        short NumberOfDegreesOfFreedom { get; }
        bool IncludeSelfWeight { get; }

        IFrameCalculationEngine CalculationEngine { get; }

        #endregion // Properties

        #region Public_Methods

        void SetNumeration();

        #endregion // Public_Methods
    }
}
