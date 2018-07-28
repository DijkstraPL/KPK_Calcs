using System;
using Tools;

namespace ReinforcementArchoring
{

    public class Reinforcement
    {
        #region Properties

        [Abbreviation("Sigma_sk")]
        public double PressInReinforcement { get; set; }

        [Abbreviation("gamma_c")]
        public static double PartialSafetyFactor { get; } = 1.15;

        [Abbreviation("Sigma_sd")]
        public double DesignPressInReinforcement
        {
            get
            {
                return PressInReinforcement / PartialSafetyFactor;
            }
        }

        [Abbreviation("fi")]
        public double Diameter { get; set; }

        public bool IsPairOfBars { get; set; }

        #endregion // Properties

        #region Constructors

        public Reinforcement(double diameter)
        {
            Diameter = diameter;
        }

        #endregion // Constructors

        #region Methods
        
        public double GetArea()
        {
            return Diameter * Diameter / 4 * Math.PI;
        } 

        #endregion // Methods
    }


}
