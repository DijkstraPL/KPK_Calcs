using System;
using Tools;

namespace ReinforcementAnchoring
{
    /// <summary>
    /// Class containing informations about the reinforcement.
    /// </summary>
    /// <example>
    /// <code>
    /// class TestClass
    /// {
    ///     static void Main()
    ///     {
    ///         Reinforcement reinforcement = new Reinforcement(12, 500, false);
    ///     }
    /// }
    /// </code>
    /// </example>
    /// <seealso cref="Bar"/>
    public class Reinforcement : Bar
    {
        #region Properties

        /// <summary>
        /// Press in reinforcement.
        /// Can be set as a characteristic yield strength of reinforcement.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 3.2.1 3.2.2]</remarks>
        [Abbreviation("Sigma_sk")]
        [Unit("MPa")]
        public double PressInReinforcement { get; set; }

        /// <summary>
        /// Partial safety factor for steel.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Table NA.2]</remarks>
        [Abbreviation("gamma_s")]
        [Unit("")]
        public static double PartialSafetyFactor { get; } = 1.15;

        /// <summary>
        /// Design press in reinforcement.
        /// Can be set as a design yield strength of reinforcement.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Fig.3.7]</remarks>
        [Abbreviation("Sigma_sd")]
        [Unit("MPa")]
        public double DesignPressInReinforcement => PressInReinforcement / PartialSafetyFactor;

        /// <summary>
        /// Should rebars be treated as a pair.
        /// </summary>
        public bool IsPairOfBars { get; set; }

        #endregion // Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Reinforcement"/> class.
        /// </summary>
        /// <param name="diameter">Set <see cref="Bar.Diameter"/>.</param>
        /// <param name="pressInReinforcement">Set <see cref="PressInReinforcement"/>.</param>
        /// <param name="isPairOfBars">Set <see cref="IsPairOfBars"/>.</param>
        public Reinforcement(double diameter, double pressInReinforcement, bool isPairOfBars = false) : base(diameter)
        {
            PressInReinforcement = pressInReinforcement;
            IsPairOfBars = isPairOfBars;
        }

        #endregion // Constructors

        #region Methods

        #endregion // Methods
    }


}
