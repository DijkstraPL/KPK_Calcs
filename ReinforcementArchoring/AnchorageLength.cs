using ReinforcementArchoring.Coefficients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace ReinforcementArchoring
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
                return ConcreteClass.ConcretClasses[ConcreteClassName];
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

        public IEnumerable<ICoefficient> Coefficients { get; private set; }

        #endregion // Properties
        #region Constructors

        public AnchorageLength(Reinforcement reinforcement, ReinforcementPosition reinforcementPosition,
            ConcreteClassEnum concreteClassName, TypeEnum type, BondConditionEnum bondCondition,
             IEnumerable<ICoefficient> coefficients, double transversePressure = 0)
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
        
        public void CalculateDesighAnchorageLength()
        {
            List<Type> types = new List<Type>();
            double coefficient = 1;
            foreach (var anchoringCoefficient in Coefficients)
            {
                types.Add(anchoringCoefficient.GetType());
                anchoringCoefficient.Calculate();
                coefficient *= anchoringCoefficient.Coefficient;
            }
            if (types.Distinct().Count() != Coefficients.Count())
                throw new ArgumentException("There are wrong coefficients!");

            if (Coefficients.FirstOrDefault(p => p is CoverCoefficient).Coefficient *
                Coefficients.FirstOrDefault(p => p is TransverseReinforcementCoefficient).Coefficient *
                Coefficients.FirstOrDefault(p => p is TransversePressureCoefficient).Coefficient
                < 0.7)
                throw new ArgumentOutOfRangeException("alpha2 * alpha3 * alpha5 should be greater than 0.7.");

            DesignAnchorageLength = coefficient * BasicRequiredAnchorageLength;
        }

        private void CalculateMinimumAnchorageLength()
        {
            CalculateBasicRequiredAnchorageLength();

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
            BasicRequiredAnchorageLength = diameter / 4 *
                Reinforcement.DesignPressInReinforcement / DesignValueUltimateBondStress;
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
                Reinforcement.Diameter :
                (132 - Reinforcement.Diameter) / 100;
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
