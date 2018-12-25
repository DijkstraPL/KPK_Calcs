using Build_IT_BeamStatica.Sections.Additional.Interfaces;

namespace Build_IT_BeamStatica.Sections.Additional
{
    internal class Point : IPoint
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static IPoint operator + (Point a, Point b) 
            => new Point(a.X + b.X, a.Y + b.Y);

        public static IPoint operator - (Point a, Point b)
            => new Point(a.X - b.X, a.Y - b.Y);
    }
}
