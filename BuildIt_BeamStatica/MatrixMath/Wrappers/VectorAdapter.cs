using MathNet.Numerics.LinearAlgebra;
using System;
using System.Linq;

namespace Build_IT_BeamStatica.MatrixMath.Wrappers
{
    public class VectorAdapter
    {
        #region Properties
        
        public double this[int i]
        {
            get => _vector[i];
            set { _vector[i] = value; }
        }

        #endregion // Properties

        #region Fields

        private readonly Vector<double> _vector;

        #endregion // Fields

        #region Factories
        
        public static VectorAdapter Create(int size)
            => new VectorAdapter(Vector<double>.Build.Dense(size));
        public static VectorAdapter Create(double[] values)
            => new VectorAdapter(Vector<double>.Build.Dense(values));

        #endregion // Factories

        #region Constructors
        
        internal VectorAdapter(Vector<double> vector)
        {
            _vector = vector;
        }

        #endregion // Constructors

        #region Public_Methods

        internal Vector<double> GetOriginal() => _vector;

        public bool Any(Func<double, bool> function) 
            => _vector.Any(dv => function(dv));

        internal VectorAdapter Add(VectorAdapter vector) 
            => new VectorAdapter(_vector.Add(vector.GetOriginal()));

        #endregion // Public_Methods

        #region Operators

        public static VectorAdapter operator -(VectorAdapter vectorA, VectorAdapter vectorB)
            => new VectorAdapter(vectorA.GetOriginal() - vectorB.GetOriginal());

        public static VectorAdapter operator *(VectorAdapter vector, double value)
            => new VectorAdapter(vector.GetOriginal() * value);

        public static VectorAdapter operator *(MatrixAdapter matrix, VectorAdapter vector)
            => new VectorAdapter(matrix.GetOriginal() * vector.GetOriginal());

        #endregion // Operators
    }
}
