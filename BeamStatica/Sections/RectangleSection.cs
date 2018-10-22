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
