using Build_IT_BeamStatica.Sections.Additional;
using Build_IT_CommonTools;
using System;

namespace Build_IT_BeamStatica.Sections
{
    internal class RectangleSection : Section
    {
        #region Properties

        [Abbreviation("b")]
        [Unit("mm")]
        public double Width { get; }
        [Abbreviation("h")]
        [Unit("mm")]
        public double Height { get; }

        public override double SolidHeight => Height;

        #endregion // Properties

        #region Constructors

        public RectangleSection(double width, double height)
        {
            Width = width;
            Height = height;

            SetPoints();

            SetSectionProperties();
        }

        #endregion // Constructors

        #region Protected_Methods

        protected override void CalculateCimcuference()
        {
            Circumference = (2 * Width + 2 * Height) / 10;
        }

        protected override void CalculateArea()
        {
            Area = Width * Height / 100;
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

        #endregion // Protected_Methods

        #region Private_Methods

        private void SetPoints()
        {
            Points.Add(new Point(0, 0));
            Points.Add(new Point(Width, 0));
            Points.Add(new Point(Width, Height));
            Points.Add(new Point(0, Height));
        }

        #endregion // Private_Methods
    }
}
