using ReinforcementAnchoring.Coefficients;
using ReinforcementAnchoring.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace ReinforcementAnchoring
{
    /// <summary>
    /// Class containing information about the reinfocement anchoring.
    /// </summary>
    /// <example>
    /// <code>
    /// class TestClass
    /// {
    ///     static void Main()
    ///     {
    ///        Reinforcement reinforcement = new Reinforcement(12, 500);
    ///        ReinforcementPosition reinforcementPosition = new ReinforcementPosition(
    ///            true, AnchorageTypeEnum.Loop, 25, 25, 50, TransverseBarPositionEnum.InsideBend);
    ///
    ///        var listOfCoefficients = new List<ICoefficient>();
    ///        BarFormCoefficient barFormCoefficient = new BarFormCoefficient(
    ///            reinforcementPosition, reinforcement);
    ///        CoverCoefficient coverCoefficient = new CoverCoefficient(
    ///            reinforcementPosition, reinforcement);
    ///        TransversePressureCoefficient transversePressureCoefficient = 
    ///            new TransversePressureCoefficient(reinforcementPosition, 2);
    ///        TransverseReinforcementCoefficient transverseReinforcementCoefficient =
    ///            new TransverseReinforcementCoefficient(
    ///                reinforcementPosition, reinforcement, TypeEnum.Beam, 5);
    ///        WeldedTransverseBarCoefficient weldedTransverseBarCoefficient = 
    ///            new WeldedTransverseBarCoefficient();
    ///        listOfCoefficients.Add(barFormCoefficient);
    ///        listOfCoefficients.Add(coverCoefficient);
    ///        listOfCoefficients.Add(transversePressureCoefficient);
    ///        listOfCoefficients.Add(transverseReinforcementCoefficient);
    ///        listOfCoefficients.Add(weldedTransverseBarCoefficient);
    ///
    ///        AnchorageLength anchorageLength = new AnchorageLength(
    ///             reinforcement, reinforcementPosition, ConcreteClassEnum.C20_25,
    ///             TypeEnum.Beam, BondConditionEnum.Good, listOfCoefficients);
    ///        anchorageLength.CalculateAnchorageLengths();
    ///     }
    /// }
    /// </code>
    /// </example>
    public class AnchorageLength
    {
        #region Properties

        /// <summary>
        /// Information about the reinforcement.
        /// </summary>
        public Reinforcement Reinforcement { get; private set; }

        /// <summary>
        /// Information about the reinforcement position during concreting.
        /// </summary>
        public ReinforcementPosition ReinforcementPosition { get; private set; }

        /// <summary>
        /// Name of the concrete class.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Table 3.1]</remarks>
        public ConcreteClassEnum ConcreteClassName { get; private set; }

        /// <summary>
        /// Information about the concrete class.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Table 3.1]</remarks>
        public ConcreteClass ConcreteClass
        {
            get
            {
                return ConcreteClass.ConcreteClasses[ConcreteClassName];
            }
        }

        /// <summary>
        /// Type of the element.
        /// </summary>
        public TypeEnum Type { get; private set; }

        /// <summary>
        /// Minimum anchorage length if no other limitation is applied.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 (8.6) (8.7)]</remarks>
        [Abbreviation("l_b,min")]
        [Unit("mm")]
        public double MinimumAnchorageLength { get; private set; }

        /// <summary>
        /// The basic required anchorage length for anchoring the force A_s * f_yd 
        /// in a bar assuming constant bond stress equal to f_bd.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 (8.3)]</remarks>
        [Abbreviation("l_b,rqd")]
        [Unit("mm")]
        public double BasicRequiredAnchorageLength { get; private set; }

        /// <summary>
        /// Coefficient related to the quality of the bond condition 
        /// and the position of the bar during concreting.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 8.4.2.(2)]</remarks>
        [Abbreviation("eta_1")]
        [Unit("")]
        public double CoefficientBondQuality { get; private set; }

        /// <summary>
        /// Coefficient related to the bar diameter.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 8.4.2.(2)]</remarks>
        [Abbreviation("eta_2")]
        [Unit("")]
        public double CoefficientBarDiameter { get; private set; }

        /// <summary>
        /// Bond conditions.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 8.4.2.(2) (Fig. 8.2)]</remarks>
        public BondConditionEnum BondCondition { get; private set; }

        /// <summary>
        /// The design value of the ultimate bond stress for ribbed bars.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 (8.2)]</remarks>
        [Abbreviation("f_bd")]
        [Unit("MPa")]
        public double DesignValueUltimateBondStress { get; private set; }

        /// <summary>
        /// The design anchorage length.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 (8.4)]</remarks>
        [Abbreviation("l_bd")]
        [Unit("mm")]
        public double DesignAnchorageLength { get; private set; }

        [Abbreviation("p")]
        [Unit("MPa")]
        public double TransversePressure { get; set; }

        /// <summary>
        /// List of coefficients to be calculated.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Table 8.2]</remarks>
        public IList<ICoefficient> Coefficients { get; set; }

        #endregion // Properties
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AnchorageLength"/> class.
        /// </summary>
        /// <param name="reinforcement">Set <see cref="Reinforcement"/>.</param>
        /// <param name="reinforcementPosition">Set <see cref="ReinforcementPosition"/>.</param>
        /// <param name="concreteClassName">Set <see cref="ConcreteClassName"/>.</param>
        /// <param name="type">Set <see cref="Type"/>.</param>
        /// <param name="bondCondition">Set <see cref="BondCondition"/>.</param>
        /// <param name="coefficients">Set <see cref="Coefficients"/>.</param>
        public AnchorageLength(Reinforcement reinforcement, ReinforcementPosition reinforcementPosition,
            ConcreteClassEnum concreteClassName, TypeEnum type, BondConditionEnum bondCondition,
             IList<ICoefficient> coefficients, double transversePressure = 0)
        {
            Reinforcement = reinforcement;
            ReinforcementPosition = reinforcementPosition;
            ConcreteClassName = concreteClassName;
            Type = type;
            BondCondition = bondCondition;
            TransversePressure = transversePressure;
            Coefficients = coefficients;
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Calculate all anchorage lengths.
        /// </summary>
        /// <seealso cref="BasicRequiredAnchorageLength"/>
        /// <seealso cref="MinimumAnchorageLength"/>
        /// <seealso cref="DesignAnchorageLength"/>
        public void CalculateAnchorageLengths()
        {
            CalculateBasicRequiredAnchorageLength();
            CalculateMinimumAnchorageLength();
            CalculateDesignAnchorageLength();
        }

        private void CalculateDesignAnchorageLength()
        {
            List<Type> types = new List<Type>();
            double coefficient = 1;

            if (Coefficients != null)
            {
                coefficient = CalculateCoefficientsMultipler(types, coefficient);

                if ((Coefficients.FirstOrDefault(p => p is CoverCoefficient)?.Coefficient ?? 1) *
                   (Coefficients.FirstOrDefault(p => p is TransverseReinforcementCoefficient)?.Coefficient ?? 1) *
                   (Coefficients.FirstOrDefault(p => p is TransversePressureCoefficient)?.Coefficient ?? 1)
                   < 0.7)
                    coefficient = (Coefficients.FirstOrDefault(p => p is BarFormCoefficient)?.Coefficient ?? 1) *
                    (Coefficients.FirstOrDefault(p => p is WeldedTransverseBarCoefficient)?.Coefficient ?? 1) *
                    0.7;
            }

            DesignAnchorageLength = coefficient * BasicRequiredAnchorageLength;
            if (DesignAnchorageLength < MinimumAnchorageLength)
                DesignAnchorageLength = MinimumAnchorageLength;
        }

        private double CalculateCoefficientsMultipler(List<Type> types, double coefficient)
        {
            foreach (var anchoringCoefficient in Coefficients)
            {
                types.Add(anchoringCoefficient.GetType());
                anchoringCoefficient.Calculate();
                coefficient *= anchoringCoefficient.Coefficient;
            }
            if (types.Distinct().Count() != Coefficients.Count())
                throw new ArgumentException("There are wrong coefficients!");
            return coefficient;
        }

        private void CalculateMinimumAnchorageLength()
        {
            double minimum = Math.Max(10 * Reinforcement.Diameter, 100);
            if (ReinforcementPosition.AreAnchoragesInTension)
                MinimumAnchorageLength = Math.Max(0.3 * BasicRequiredAnchorageLength, minimum);
            else
                MinimumAnchorageLength = Math.Max(0.6 * BasicRequiredAnchorageLength, minimum);
        }

        private void CalculateBasicRequiredAnchorageLength()
        {
            double diameter = Reinforcement.Diameter;
            if (Reinforcement.IsPairOfBars)
                diameter = Reinforcement.Diameter * Math.Sqrt(2);

            CalculateDesignValueUltimateBondStress();
            BasicRequiredAnchorageLength = (diameter / 4 *
                Reinforcement.DesignPressInReinforcement / DesignValueUltimateBondStress);
        }

        private void CalculateDesignValueUltimateBondStress()
        {
            SetCoefficientBondQuality();
            SetCoefficientBarDiameter();
            DesignValueUltimateBondStress = 2.25 * CoefficientBondQuality *
                CoefficientBarDiameter * ConcreteClass.DesignValueConcreteTensileStrength;
        }

        private void SetCoefficientBondQuality()
        {
            switch (BondCondition)
            {
                case BondConditionEnum.Good:
                    CoefficientBondQuality = 1;
                    break;
                case BondConditionEnum.Bad:
                    CoefficientBondQuality = 0.7;
                    break;
                default:
                    break;
            }
        }

        private void SetCoefficientBarDiameter()
        {
            CoefficientBarDiameter = Reinforcement.Diameter <= 32 ?
                1 : (132 - Reinforcement.Diameter) / 100;
        }
        #endregion // Methods
    }

    /// <summary>
    /// Bond condition enumerator.
    /// </summary>
    /// <remarks>[PN-EN 1992-1-1 Fig.8.2]</remarks>
    public enum BondConditionEnum
    {
        /// <summary>
        /// Good bond conditions.
        /// </summary>
        Good,
        /// <summary>
        /// Bad bond conditions.
        /// </summary>
        Bad
    }
    /// <summary>
    /// Element type enum.
    /// </summary>
    public enum TypeEnum
    {
        /// <summary>
        /// Beam type.
        /// </summary>
        Beam,
        /// <summary>
        /// Slab type.
        /// </summary>
        Slab
    }
}
