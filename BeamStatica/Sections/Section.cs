using BeamStatica.Sections.Interfaces;
using System;
using System.Collections.Generic;
using Tools;

namespace BeamStatica.Sections
{
    public abstract class Section : IMomentOfInteria
    {
        [Abbreviation("I")]
        [Unit("cm4")]
        public double MomentOfInteria { get; set; }

        //public List<Point> Points { get; set; }

        //public void CalculateMomentOfInteria()
        //{
        //    double value = 0;
        //    for (int i = 0; i < Points.Count; i++)
        //    {
        //        int nextPointIndex = i + 1;
        //        if (nextPointIndex == Points.Count)
        //            nextPointIndex = 0;

        //        value += (Math.Pow(Points[i].Y, 2)
        //            + Points[i].Y * Points[nextPointIndex].Y
        //            + Math.Pow(Points[nextPointIndex].Y, 2))
        //            * (Points[i].X * Points[nextPointIndex].Y
        //            - Points[nextPointIndex].X * Points[i].Y);

        //    }
        //    MomentOfInteria = 1.0 / 12 * value / 10000;
        //}
    }

    //public class Point
    //{
    //    public double X { get; set; }
    //    public double Y { get; set; }
    //}
}
