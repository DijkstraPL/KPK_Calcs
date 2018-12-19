using Build_IT_BeamStatica.Beams;
using Build_IT_BeamStatica.Beams.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;
using MathNet.Numerics.LinearAlgebra;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStaticaTests.UnitTests.Beams
{
    [TestFixture()]
    public class GlobalStiffnessMatrixTests
    {
        private short _size;
        private GlobalStiffnessMatrix _globalStiffnessMatrix;

        [SetUp]
        public void SetUpGlobalStiffnessMatrix()
        {
            _size = 4;
            var beam = new Mock<IBeam>();
            var span = new Mock<ISpan>();
            var spans = new List<ISpan>();
            var spanStiffnessMatrix = new Mock<IStiffnessMatrix>();
            var matrixOfPositions = new List<IStiffnessMatrixPosition>();
            for (short i = 0; i < _size; i++)
            {
                for (short j = 0; j < _size; j++)
                {
                    var matrixOfPosition = new Mock<IStiffnessMatrixPosition>();
                    matrixOfPosition.Setup(mop => mop.ColumnNumber).Returns(i);
                    matrixOfPosition.Setup(mop => mop.RowNumber).Returns(j);
                    matrixOfPosition.Setup(mop => mop.Value).Returns(i + j);


                    matrixOfPositions.Add(matrixOfPosition.Object);
                }
            }

            spanStiffnessMatrix.Setup(sm => sm.MatrixOfPositions).Returns(matrixOfPositions);

            span.Setup(s => s.StiffnessMatrix).Returns(spanStiffnessMatrix.Object);
            spans.Add(span.Object);

            beam.Setup(b => b.NumberOfDegreesOfFreedom).Returns(_size);
            beam.Setup(b => b.Spans).Returns(spans);

            _globalStiffnessMatrix = new GlobalStiffnessMatrix(beam.Object);

        }

        [Test()]
        public void CalculateGlobalStiffeness_Success_Test()
        {
            _globalStiffnessMatrix.Calculate();

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Assert.That(_globalStiffnessMatrix.Matrix[i, j], Is.EqualTo(i+j));
                }
            }
        }
    }
}