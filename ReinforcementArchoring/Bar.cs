using System;
using Tools;

namespace ReinforcementAnchoring
{
    public class Bar
    {
        [Abbreviation("fi")]
        public double Diameter { get; set; }

        public double Area => Diameter * Diameter / 4 * Math.PI / 100;

        public Bar(double diameter)
        {
            Diameter = diameter;
        }
    }
}