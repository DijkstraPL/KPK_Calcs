using BeamStatica.Sections.Additional;
using BeamStatica.Sections.Additional.Interfaces;
using BeamStatica.Sections.Interfaces;
using System;
using System.Collections.Generic;
using Tools;

namespace BeamStatica.Sections
{
    public class Section : IMomentOfInteria
    {
        [Abbreviation("I")]
        [Unit("cm4")]
        public double MomentOfInteria { get; protected set; }

        [Abbreviation("A")]
        [Unit("cm2")]
        public double Area { get; protected set; }

        public IList<IPoint> Points { get; protected set; }
        public IList<IPoint> AdjustedPoints { get; protected set; }

        public IPoint Centroid { get; protected set; }

        protected Section()
        {
            Points = new List<IPoint>();
            AdjustedPoints = new List<IPoint>();
        }

        public Section(IList<IPoint> points)
        {
            Points = points ?? throw new ArgumentNullException(nameof(points));
            AdjustedPoints = new List<IPoint>();

            SetSectionProperties();
        }

        public void SetSectionProperties()
        {
            CalculateArea();
            CalculateCentroid();
            AdjustPoints();
            CalculateMomentOfInteria();
        }

        protected virtual void CalculateArea()
        {
            double value = 0;
            for (int i = 0; i < Points.Count; i++)
            {
                int nextPointIndex = i + 1;
                if (nextPointIndex == Points.Count)
                    nextPointIndex = 0;

                value += Points[i].X * Points[nextPointIndex].Y
                    - Points[nextPointIndex].X * Points[i].Y;
            }
            Area = 0.5 * Math.Abs(value) / 100;
        }

        protected virtual void CalculateCentroid()
        {
            double x = 0;
            double y = 0;
            for (int i = 0; i < Points.Count; i++)
            {
                int nextPointIndex = i + 1;
                if (nextPointIndex == Points.Count)
                    nextPointIndex = 0;

                x += (Points[i].X + Points[nextPointIndex].X)
                    * (Points[i].X * Points[nextPointIndex].Y
                    - Points[nextPointIndex].X * Points[i].Y);
                y += (Points[i].Y + Points[nextPointIndex].Y)
                    * (Points[i].X * Points[nextPointIndex].Y
                    - Points[nextPointIndex].X * Points[i].Y);
            }
            double value = 1.0 / (6 * Area * 100);

            Centroid = new Point(value * x, value * y);
        }

        protected virtual void AdjustPoints()
        {
            foreach (var point in Points)
                AdjustedPoints.Add(SubstractPoints(point,Centroid));
        }
        
        protected virtual void CalculateMomentOfInteria()
        {
            double value = 0;
            for (int i = 0; i < AdjustedPoints.Count; i++)
            {
                int nextPointIndex = i + 1;
                if (nextPointIndex == AdjustedPoints.Count)
                    nextPointIndex = 0;

                value += (Math.Pow(AdjustedPoints[i].Y, 2)
                    + AdjustedPoints[i].Y * AdjustedPoints[nextPointIndex].Y
                    + Math.Pow(AdjustedPoints[nextPointIndex].Y, 2))
                    * (AdjustedPoints[i].X * AdjustedPoints[nextPointIndex].Y
                    - AdjustedPoints[nextPointIndex].X * AdjustedPoints[i].Y);
            }
            MomentOfInteria = 1.0 / 12 * value / 10000;
        }

        private static IPoint SubstractPoints(IPoint a, IPoint b) 
            => new Point(a.X - b.X, a.Y - b.Y);
    }
}
