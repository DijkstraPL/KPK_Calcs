using SnowLoads.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads
{
    /// <summary>
    /// Class for calculation of snow load on the ground.
    /// </summary>
    public class SnowLoad : ICalculatable, ISnowLoad
    {
        #region Properties

        public DesignSituation CurrentDesignSituation { get; set; }

        private bool excepctionalSituation;
        /// <summary>
        /// Is situation for calculations exceptional.
        /// </summary>
        public bool ExcepctionalSituation
        {
            get { return excepctionalSituation; }
            set
            {
                if (CurrentDesignSituation != DesignSituation.A)
                    excepctionalSituation = value;
                else
                    excepctionalSituation = false;
            }
        }

        private double snowDensity = 2;
        /// <summary>
        /// Density of the snow [kN/m3].
        /// </summary>
        public double SnowDensity
        {
            get { return snowDensity; }
            set
            {
                switch (value)
                {
                    case 1:
                    case 2:
                    case 4:
                        snowDensity = value;
                        break;
                    default:
                        if (2.5 <= value && value <= 3.5)
                            snowDensity = value;
                        else
                            throw new ArgumentOutOfRangeException("Snow density can't be this value.");
                        break;
                }
            }
        }

        /// <summary>
        /// sk - Characteristic value of snow on the ground at the relevant site [kN/m2].
        /// </summary>
        [Abbreviation("s_k")]
        public double DefaultCharacteristicSnowLoad { get; private set; }

        /// <summary>
        /// sn - Characteristic ground snow load with a return period of n years [kN/m2].
        /// </summary>
        [Abbreviation("s_n")]
        public double SnowLoadForSpecificReturnPeriod { get; private set; }

        /// <summary>
        /// V - Coefficient of variation of annual maximum snow load.
        /// </summary>
        [Abbreviation("V")]
        public double VariationCoefficient { get; private set; }

        private int returnPeriod = 50;
        /// <summary>
        /// n - years of return period.
        /// </summary>
        [Abbreviation("n")]
        public int ReturnPeriod
        {
            get { return returnPeriod; }
            set
            {
                if (value < 5)
                    throw new ArgumentOutOfRangeException("Return period shouldn't be less than 5 years.");
                returnPeriod = value;
            }
        }

        /// <summary>
        /// C_esl - coefficient for exceptional snow loads (4.3 NOTE).
        /// </summary>
        [Abbreviation("C_esl")]
        public double ExceptionalSnowLoadCoefficient { get; private set; }

        /// <summary>
        /// S_Ad - the design value of exceptional snow load on the ground for the given location (4.1) [kN/m2]. 
        /// </summary>
        [Abbreviation("s_Ad")]
        public double DesignExceptionalSnowLoadForSpecificReturnPeriod { get; private set; }

        /// <summary>
        /// Building site.
        /// </summary>
        public IBuildingSite BuildingSite { get; private set; }

        #endregion // Properties

        #region Constructors

        /// <summary>
        /// Constructor for snow load.
        /// </summary>
        /// <param name="buildingSite">Instance of the building site.</param>
        public SnowLoad(IBuildingSite buildingSite,
            DesignSituation currentDesignSituation = DesignSituation.A,
            bool excepctionalSituation = false)
        {
            BuildingSite = buildingSite;
            CurrentDesignSituation = currentDesignSituation;
            ExcepctionalSituation = excepctionalSituation;
        }

        public SnowLoad(IBuildingSite buildingSite, int returnPeriod,
            DesignSituation currentDesignSituation = DesignSituation.A,
            bool excepctionalSituation = false) : this(buildingSite, currentDesignSituation, excepctionalSituation)
        {
            ReturnPeriod = returnPeriod;
        }

        public SnowLoad(IBuildingSite buildingSite, double snowDensity,
            DesignSituation currentDesignSituation = DesignSituation.A,
            bool excepctionalSituation = false) : this(buildingSite, currentDesignSituation, excepctionalSituation)
        {
            SnowDensity = snowDensity;
        }

        public SnowLoad(IBuildingSite buildingSite, double snowDensity, int returnPeriod,
        DesignSituation currentDesignSituation = DesignSituation.A,
        bool excepctionalSituation = false) : this(buildingSite, currentDesignSituation, excepctionalSituation)
        {
            SnowDensity = snowDensity;
            ReturnPeriod = returnPeriod;
        }

        #endregion // Constructors

        #region Methods

        public void CalculateSnowLoad()
        {
            SetCharacteristicSnowLoad();
            SetVariationCoefficient();
            SetCharacteristicSnowLoadForSpecificReturnPeriod();
            SetExceptionalSnowLoadCoefficient();
            SetDesignExceptionalSnowLoadForSpecificReturnPeriod();
        }

        /// <summary>
        /// Set snow load base on terrain zone (Tab.NB.1).
        /// </summary>
        /// <param name="ownValue"></param>
        private void SetCharacteristicSnowLoad(double ownValue = 0)
        {
            switch (BuildingSite.CurrentZone)
            {
                case Zone.None:
                    DefaultCharacteristicSnowLoad = ownValue;
                    break;
                case Zone.FirstZone:
                    DefaultCharacteristicSnowLoad = Math.Max(0.007 * BuildingSite.AltitudeAboveSea - 1.4, 0.7);
                    break;
                case Zone.BetweenFirst_Second:
                    DefaultCharacteristicSnowLoad = (Math.Max(0.007 * BuildingSite.AltitudeAboveSea - 1.4, 0.7) + 0.9) / 2;
                    break;
                case Zone.SecondZone:
                    DefaultCharacteristicSnowLoad = 0.9;
                    break;
                case Zone.BetweenSecond_Third:
                    DefaultCharacteristicSnowLoad = (Math.Max(0.006 * BuildingSite.AltitudeAboveSea - 0.6, 1.2) + 0.9) / 2;
                    break;
                case Zone.ThirdZone:
                    DefaultCharacteristicSnowLoad = Math.Max(0.006 * BuildingSite.AltitudeAboveSea - 0.6, 1.2);
                    break;
                case Zone.BetweenThird_Fourth:
                    DefaultCharacteristicSnowLoad = (Math.Max(0.006 * BuildingSite.AltitudeAboveSea - 0.6, 1.2) + 1.6) / 2;
                    break;
                case Zone.FourthZone:
                    DefaultCharacteristicSnowLoad = 1.6;
                    break;
                case Zone.BetweenFourth_Fifth:
                    DefaultCharacteristicSnowLoad = (Math.Max(0.93 * Math.Pow(Math.E, 0.00134 * BuildingSite.AltitudeAboveSea), 2) + 1.6) / 2;
                    break;
                case Zone.FifthZone:
                    DefaultCharacteristicSnowLoad = Math.Max(0.93 * Math.Pow(Math.E, 0.00134 * BuildingSite.AltitudeAboveSea), 2);
                    break;
                default:
                    throw new ArgumentException("There is no zone specified.");
            }
        }

        /// <summary>
        /// Calculate coefficient of variation of annual maximum snow load (NB.3).
        /// </summary>
        private void SetVariationCoefficient()
        {
            if (BuildingSite.AltitudeAboveSea < 300)
                VariationCoefficient = 0.7;
            else
                VariationCoefficient = 0.8 * Math.Pow(Math.E, -0.0006 * BuildingSite.AltitudeAboveSea);
        }

        /// <summary>
        /// Calculate characteristic snow load for specific return period (D.1)
        /// </summary>
        private void SetCharacteristicSnowLoadForSpecificReturnPeriod()
        {
            if (ReturnPeriod == 50)
                SnowLoadForSpecificReturnPeriod = DefaultCharacteristicSnowLoad;
            else
                SnowLoadForSpecificReturnPeriod = DefaultCharacteristicSnowLoad *
                    ((1 - VariationCoefficient * Math.Sqrt(6) / Math.PI * (Math.Log(-Math.Log(1 - 1.0 / ReturnPeriod)) + 0.57722)) /
                    (1 + 2.5923 * VariationCoefficient));
        }

        /// <summary>
        /// Calculate exceptional snow load coefficient.
        /// </summary>
        private void SetExceptionalSnowLoadCoefficient()
        {
            ExceptionalSnowLoadCoefficient = 2;
        }

        /// <summary>
        /// Calculate exceptional snow load value (4.1).
        /// </summary>
        private void SetDesignExceptionalSnowLoadForSpecificReturnPeriod()
        {
            DesignExceptionalSnowLoadForSpecificReturnPeriod = ExceptionalSnowLoadCoefficient * SnowLoadForSpecificReturnPeriod;
        }

        #endregion // Methods
    }

    public enum DesignSituation
    {
        A,
        B1,
        B2,
        B3,
    }
}
