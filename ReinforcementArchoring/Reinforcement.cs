using System;
using Tools;

namespace ReinforcementAnchoring
{

    public class Reinforcement : Bar
    {
        #region Properties

        [Abbreviation("Sigma_sk")]
        public double PressInReinforcement { get; set; }

        [Abbreviation("gamma_c")]
        public static double PartialSafetyFactor { get; } = 1.15;

        [Abbreviation("Sigma_sd")]
        public double DesignPressInReinforcement => PressInReinforcement / PartialSafetyFactor;
        
        public bool IsPairOfBars { get; set; }
                
        #endregion // Properties

        #region Constructors

        public Reinforcement(double diameter, double pressInReinforcement, bool isPairOfBars = false) : base (diameter)
        {
            PressInReinforcement = pressInReinforcement;
            IsPairOfBars = isPairOfBars;
        }

        #endregion // Constructors

        #region Methods

        #endregion // Methods
    }


}
