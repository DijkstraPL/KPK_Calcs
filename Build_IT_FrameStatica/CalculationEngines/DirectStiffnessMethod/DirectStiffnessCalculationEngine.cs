using Build_IT_FrameStatica.CalculationEngines.Interfaces;
using Build_IT_FrameStatica.Frames;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_FrameStatica.CalculationEngines.DirectStiffnessMethod
{
    internal class DirectStiffnessCalculationEngine : IFrameCalculationEngine
    {
        private Frame _frame;

        public DirectStiffnessCalculationEngine(Frame frame)
        {
            _frame = frame;
        }
    }

}
