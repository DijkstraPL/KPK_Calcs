using System;
using Tools;

namespace ReinforcementAnchoring
{
    /// <summary>
    /// Class containing information about the single rebar.
    /// </summary>
    /// <example>
    /// <code>
    /// class TestClass
    /// {
    ///     static void Main()
    ///     {
    ///         Bar bar = new Bar(12);
    ///     }
    /// }
    /// </code>
    /// </example>
    public class Bar
    {
        /// <summary>
        /// Diameter of the rebar.
        /// </summary>
        [Abbreviation("fi")]
        [Unit("mm")]
        public double Diameter { get; set; }

        /// <summary>
        /// Area of the rebar.
        /// </summary>
        [Abbreviation("A_s")]
        [Unit("cm2")]
        public double Area => Diameter * Diameter / 4 * Math.PI / 100;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bar"/> class.
        /// </summary>
        /// <param name="diameter">Set <see cref="Diameter"/>.</param>
        public Bar(double diameter)
        {
            Diameter = diameter;
        }
    }
}