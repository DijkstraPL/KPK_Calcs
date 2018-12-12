using BeamStatica.Sections.Additional;
using System;
using System.Collections.Generic;
using Tools;

namespace BeamStatica.Sections
{
    public sealed class RectangleSection : Section
    {
        [Abbreviation("b")]
        [Unit("mm")]
        public double Width { get; }
        [Abbreviation("h")]
        [Unit("mm")]
        public double Height { get; }

        public override double SolidHeight => Height;

        public RectangleSection(double width, double height) 
        {
            Width = width;
            Height = height;

            SetPoints();

            SetSectionProperties();
        }

        private void SetPoints()
        {
            Points.Add(new Point(0, 0));
            Points.Add(new Point(Width, 0));
            Points.Add(new Point(Width, Height));
            Points.Add(new Point(0, Height));
        }

        protected override void CalculateCimcuference()
        {
            Circumference = 2 * Width + 2 * Height;
        }

        protected override void CalculateArea()
        {
            Area = Width * Height;
        }

        protected override void CalculateCentroid()
        {
            Centroid = new Point(Width / 2, Height / 2);
        }

        /// <summary>
        /// Divided by 10000 - mm4 to cm4
        /// </summary>
        protected override void CalculateMomentOfInteria()
        {
            MomentOfInteria = Width * Math.Pow(Height, 3) / 12 / 10000;
        }
    }
}
