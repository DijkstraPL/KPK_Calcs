using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Beams.Interfaces
{
    public interface IGlobalStiffnessMatrix
    {
        Matrix<double> Matrix { get; }
        Matrix<double> InversedMatrix { get; }

        void Calculate();
    }
}
