using ReinforcementAnchoring.Coefficients;
using ReinforcementAnchoring.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace ReinforcementAnchoring
{
    public class AnchorageLength
    {
        #region Properties

        public Reinforcement Reinforcement { get; private set; }
        public ReinforcementPosition ReinforcementPosition { get; private set; }

        public ConcreteClassEnum ConcreteClassName { get; private set; }

        public ConcreteClass ConcreteClass
        {
            get
            {
                return ConcreteClass.ConcreteClasses[ConcreteClassName];
            }
        }

        public TypeEnum Type { get; private set; }

        [Abbreviation("l_b,min")]
        public double MinimumAnchorageLength { get; private set; }

        [Abbreviation("l_b,rqd")]
        public double BasicRequiredAnchorageLength { get; private set; }

        [Abbreviation("eta_1")]
        public double CoefficientBondQuality { get; private set; }

        [Abbreviation("eta_1")]
        public double CoefficientBarDiameter { get; private set; }

        public BondConditionEnum BondCondition { get; private set; }

        [Abbreviation("f_bd")]
        public double DesignValueUltimateBondStress { get; private set; }

        [Abbreviation("l_bd")]
        public double DesignAnchorageLength { get; private set; }

        [Abbreviation("p")]
        public double TransversePressure { get; set; }

        public IList<ICoefficient> Coefficients { get; set; }

        #endregion // Properties
        #region Constructors

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

            if(Coefficients != null)
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

    public enum BondConditionEnum
    {
        Good,
        Bad
    }
    public enum TypeEnum
    {
        Beam,
        Slab
    }
}
