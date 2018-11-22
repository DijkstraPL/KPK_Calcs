using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace BeamStatica.Sections
{
    public sealed class RectangleSection : Section
    {
        [Abbreviation("b")]
        [Unit("mm")]
        public double Width { get; set; }
        [Abbreviation("h")]
        [Unit("mm")]
        public double Height { get; set; }

        public RectangleSection(double width, double height)
        {
            Width = width;
            Height = height;

            //Points = new List<Point>();

            //Points.Add(new Point() { X = 0, Y = 0 });
            //Points.Add(new Point() { X = width, Y = 0 });
            //Points.Add(new Point() { X = width, Y = height });
            //Points.Add(new Point() { X = 0, Y = height });


            CalculateMomentOfInteria();
        }

        /// <summary>
        /// Divided by 10000 - mm4 to cm4
        /// </summary>
        private void CalculateMomentOfInteria()
        {
            MomentOfInteria = Width * Math.Pow(Height, 3) / 12 / 10000;
        }
    }
}
