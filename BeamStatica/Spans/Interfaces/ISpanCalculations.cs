using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Spans.Interfaces
{
    public interface ISpanCalculations
    {
        void CalculateSpanLoadVector();
        void CalculateDisplacement(Vector<double> deflectionVector, int numberOfDegreesOfFreedom);
        void SetDisplacement();
        void CalculateForce();
    }
}
