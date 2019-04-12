using Build_IT_Data.Sections.Additional.Interfaces;

namespace Build_IT_Data.Sections.Additional
{
    internal class Point : IPoint
    {
        #region Properties

        public double X { get; }
        public double Y { get; }

        #endregion // Properties

        #region Constructors
        
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        #endregion // Constructors

        #region Operators

        public static IPoint operator + (Point a, Point b) 
            => new Point(a.X + b.X, a.Y + b.Y);

        public static IPoint operator - (Point a, Point b)
            => new Point(a.X - b.X, a.Y - b.Y);

        #endregion // Operators
    }
}
