using BeamStatica.Nodes;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;

namespace BeamStatica.Spans
{
    public class StiffnessMatrix
    {
        private readonly Span _span;

        public ICollection<StiffnessMatrixPosition> MatrixOfPositions { get; private set; } = new List<StiffnessMatrixPosition>();
        public Matrix<double> Matrix { get; private set; }

        public StiffnessMatrix(Span span)
        {
            _span = span;
        }

        public void Calculate()
        {
            CalculateStiffnessMatrixForGeneralBeam();
        }
              
        private void CalculateStiffnessMatrixForGeneralBeam()
        {
            var value = _span.Material.YoungModulus * _span.Section.MomentOfInteria / Math.Pow(_span.Length, 3) / 100; // kN/m

            MatrixOfPositions.Add(new StiffnessMatrixPosition(value * 12, _span.LeftNode.MovementNumber, _span.LeftNode.MovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(value * 6 * _span.Length, _span.LeftNode.MovementNumber, _span.LeftNode.RightRotationNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(value * -12, _span.LeftNode.MovementNumber, _span.RightNode.MovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(value * 6 * _span.Length, _span.LeftNode.MovementNumber, _span.RightNode.LeftRotationNumber));

            MatrixOfPositions.Add(new StiffnessMatrixPosition(value * 6 * _span.Length, _span.LeftNode.RightRotationNumber, _span.LeftNode.MovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(value * 4 * Math.Pow(_span.Length, 2), _span.LeftNode.RightRotationNumber, _span.LeftNode.RightRotationNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(value * -6 * _span.Length, _span.LeftNode.RightRotationNumber, _span.RightNode.MovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(value * 2 * Math.Pow(_span.Length, 2), _span.LeftNode.RightRotationNumber, _span.RightNode.LeftRotationNumber));

            MatrixOfPositions.Add(new StiffnessMatrixPosition(value * -12, _span.RightNode.MovementNumber, _span.LeftNode.MovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(value * -6 * _span.Length, _span.RightNode.MovementNumber, _span.LeftNode.RightRotationNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(value * 12, _span.RightNode.MovementNumber, _span.RightNode.MovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(value * -6 * _span.Length, _span.RightNode.MovementNumber, _span.RightNode.LeftRotationNumber));

            MatrixOfPositions.Add(new StiffnessMatrixPosition(value * 6 * _span.Length, _span.RightNode.LeftRotationNumber, _span.LeftNode.MovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(value * 2 * Math.Pow(_span.Length, 2), _span.RightNode.LeftRotationNumber, _span.LeftNode.RightRotationNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(value * -6 * _span.Length, _span.RightNode.LeftRotationNumber, _span.RightNode.MovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(value * 4 * Math.Pow(_span.Length, 2), _span.RightNode.LeftRotationNumber, _span.RightNode.LeftRotationNumber));

            SetMatrix();
        }

        private void SetMatrix()
        {
            Matrix = Matrix<double>.Build.Dense(4, 4);

            int i = 0;
            int j = 0;
            foreach (var position in MatrixOfPositions)
            {
                Matrix[j, i] = position.Value;
                i++;
                if (i % 4 == 0)
                {
                    j++;
                    i = 0;
                }
            }
        }
    }
}
