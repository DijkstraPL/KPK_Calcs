using BeamStatica.Nodes;
using BeamStatica.Spans.Interfaces;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;

namespace BeamStatica.Spans
{
    public class StiffnessMatrix : IStiffnessMatrix
    {
        public ICollection<IStiffnessMatrixPosition> MatrixOfPositions { get; private set; } = new List<IStiffnessMatrixPosition>();
        public Matrix<double> Matrix { get; private set; }
        public int Size { get; private set; }

        private readonly Span _span;

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
            var horizontalValue = _span.Section.Area * _span.Material.YoungModulus / _span.Length * 100; // kN
            var verticalValue = _span.Material.YoungModulus * _span.Section.MomentOfInteria / Math.Pow(_span.Length, 3) / 100; // kN/m

            SetLeftNodeHorizontalMovementColumn(horizontalValue);
            SetLeftNodeVerticalMovementColumn(verticalValue);
            SetLeftNodeRightRotationColumn(verticalValue);
            SetRightNodeHorizontalMovementColumn(horizontalValue);
            SetRightNodeVerticalMovementColumn(verticalValue);
            SetRightNodeLeftRotationColumn(verticalValue);

            SetSize();
            SetMatrix();
        }

        private void SetLeftNodeHorizontalMovementColumn(double horizontalValue)
        {
            MatrixOfPositions.Add(new StiffnessMatrixPosition(horizontalValue, _span.LeftNode.HorizontalMovementNumber, _span.LeftNode.HorizontalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(0, _span.LeftNode.HorizontalMovementNumber, _span.LeftNode.VerticalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(0, _span.LeftNode.HorizontalMovementNumber, _span.LeftNode.RightRotationNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(-horizontalValue, _span.LeftNode.HorizontalMovementNumber, _span.RightNode.HorizontalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(0, _span.LeftNode.HorizontalMovementNumber, _span.RightNode.VerticalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(0, _span.LeftNode.HorizontalMovementNumber, _span.RightNode.LeftRotationNumber));
        }

        private void SetLeftNodeVerticalMovementColumn(double verticalValue)
        {
            MatrixOfPositions.Add(new StiffnessMatrixPosition(0, _span.LeftNode.VerticalMovementNumber, _span.LeftNode.HorizontalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(verticalValue * 12, _span.LeftNode.VerticalMovementNumber, _span.LeftNode.VerticalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(verticalValue * 6 * _span.Length, _span.LeftNode.VerticalMovementNumber, _span.LeftNode.RightRotationNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(0, _span.LeftNode.VerticalMovementNumber, _span.RightNode.HorizontalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(verticalValue * -12, _span.LeftNode.VerticalMovementNumber, _span.RightNode.VerticalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(verticalValue * 6 * _span.Length, _span.LeftNode.VerticalMovementNumber, _span.RightNode.LeftRotationNumber));
        }

        private void SetLeftNodeRightRotationColumn(double verticalValue)
        {
            MatrixOfPositions.Add(new StiffnessMatrixPosition(0, _span.LeftNode.RightRotationNumber, _span.LeftNode.HorizontalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(verticalValue * 6 * _span.Length, _span.LeftNode.RightRotationNumber, _span.LeftNode.VerticalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(verticalValue * 4 * Math.Pow(_span.Length, 2), _span.LeftNode.RightRotationNumber, _span.LeftNode.RightRotationNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(0, _span.LeftNode.RightRotationNumber, _span.RightNode.HorizontalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(verticalValue * -6 * _span.Length, _span.LeftNode.RightRotationNumber, _span.RightNode.VerticalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(verticalValue * 2 * Math.Pow(_span.Length, 2), _span.LeftNode.RightRotationNumber, _span.RightNode.LeftRotationNumber));
        }

        private void SetRightNodeHorizontalMovementColumn(double horizontalValue)
        {
            MatrixOfPositions.Add(new StiffnessMatrixPosition(-horizontalValue, _span.RightNode.HorizontalMovementNumber, _span.LeftNode.HorizontalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(0, _span.RightNode.HorizontalMovementNumber, _span.LeftNode.VerticalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(0, _span.RightNode.HorizontalMovementNumber, _span.LeftNode.RightRotationNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(horizontalValue, _span.RightNode.HorizontalMovementNumber, _span.RightNode.HorizontalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(0, _span.RightNode.HorizontalMovementNumber, _span.RightNode.VerticalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(0, _span.RightNode.HorizontalMovementNumber, _span.RightNode.LeftRotationNumber));
        }
        
        private void SetRightNodeVerticalMovementColumn(double verticalValue)
        {
            MatrixOfPositions.Add(new StiffnessMatrixPosition(0, _span.RightNode.VerticalMovementNumber, _span.LeftNode.HorizontalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(verticalValue * -12, _span.RightNode.VerticalMovementNumber, _span.LeftNode.VerticalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(verticalValue * -6 * _span.Length, _span.RightNode.VerticalMovementNumber, _span.LeftNode.RightRotationNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(0, _span.RightNode.VerticalMovementNumber, _span.RightNode.HorizontalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(verticalValue * 12, _span.RightNode.VerticalMovementNumber, _span.RightNode.VerticalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(verticalValue * -6 * _span.Length, _span.RightNode.VerticalMovementNumber, _span.RightNode.LeftRotationNumber));
        }
        
        private void SetRightNodeLeftRotationColumn(double verticalValue)
        {
            MatrixOfPositions.Add(new StiffnessMatrixPosition(0, _span.RightNode.LeftRotationNumber, _span.LeftNode.HorizontalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(verticalValue * 6 * _span.Length, _span.RightNode.LeftRotationNumber, _span.LeftNode.VerticalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(verticalValue * 2 * Math.Pow(_span.Length, 2), _span.RightNode.LeftRotationNumber, _span.LeftNode.RightRotationNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(0, _span.RightNode.LeftRotationNumber, _span.RightNode.HorizontalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(verticalValue * -6 * _span.Length, _span.RightNode.LeftRotationNumber, _span.RightNode.VerticalMovementNumber));
            MatrixOfPositions.Add(new StiffnessMatrixPosition(verticalValue * 4 * Math.Pow(_span.Length, 2), _span.RightNode.LeftRotationNumber, _span.RightNode.LeftRotationNumber));
        }

        private void SetSize()
        {
            Size = (int)Math.Sqrt(MatrixOfPositions.Count);
        }

        private void SetMatrix()
        {           
            Matrix = Matrix<double>.Build.Dense(Size, Size);

            int i = 0;
            int j = 0;
            foreach (var position in MatrixOfPositions)
            {
                Matrix[j, i] = position.Value;
                i++;
                if (i % Size == 0)
                {
                    j++;
                    i = 0;
                }
            }
        }
    }
}
