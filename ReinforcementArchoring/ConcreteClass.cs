using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tools;

namespace ReinforcementAnchoring
{
    /// <summary>
    /// Class containing information about the concrete.
    /// </summary>
    /// <example>
    /// <code>
    /// class TestClass
    /// {
    ///     static void Main()
    ///     {
    ///         ConcreteClass concreteClass = ConcreteClass.ConcreteClasses[ConcreteClassEnum.C20_25];
    ///     }
    /// }
    /// </code>
    /// </example>
    public class ConcreteClass
    {
        #region Properties

        /// <summary>
        /// Coefficient taking account of long term effects on the compressive strength
        /// and of unfavourable effects resulting from the way the load is applied.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 3.1.6.(1) Note]</remarks>
        [Abbreviation("alpha_ct")]
        [Unit("")]
        public static double LongTermEffectTensileStrengthCoefficient { get; } = 1;

        /// <summary>
        /// Partial safety factor for concrete.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 NA.2]</remarks>
        [Abbreviation("gamma_c")]
        [Unit("")]
        public static double PartialSafetyFactor { get; } = 1.4;

        /// <summary>
        /// Name - object dictionary for concrete classes.
        /// </summary>
        public static Dictionary<ConcreteClassEnum, ConcreteClass> ConcreteClasses { get; set; }

        /// <summary>
        /// Name of the concrete class.
        /// </summary>
        public ConcreteClassEnum ClassOfConcrete { get; private set; }

        /// <summary>
        /// Characteristic axial tensile strength of concrete. 
        /// Quantile 5% according to Gauss distribution.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Table 3.1]</remarks>
        [Abbreviation("f_ctk,0,05")]
        [Unit("MPa")]
        public double CharacteristicAxialTensileStrength { get; }

        /// <summary>
        /// Design tensile strength.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 (3.16)]</remarks>
        [Abbreviation("f_ctd")]
        [Unit("MPa")]
        public double DesignValueConcreteTensileStrength =>
            LongTermEffectTensileStrengthCoefficient * CharacteristicAxialTensileStrength / PartialSafetyFactor;
        #endregion // Properties

        #region Constructors

        private ConcreteClass(ConcreteClassEnum classOfConcrete, double characteristicAxialTensileStrength)
        {
            ClassOfConcrete = classOfConcrete;
            CharacteristicAxialTensileStrength = characteristicAxialTensileStrength;
        }

        static ConcreteClass()
        {
            ConcreteClasses = new Dictionary<ConcreteClassEnum, ConcreteClass>();
            ConcreteClasses.Add(ConcreteClassEnum.C12_15, new ConcreteClass(ConcreteClassEnum.C12_15, 1.1));
            ConcreteClasses.Add(ConcreteClassEnum.C16_20, new ConcreteClass(ConcreteClassEnum.C16_20, 1.3));
            ConcreteClasses.Add(ConcreteClassEnum.C20_25, new ConcreteClass(ConcreteClassEnum.C20_25, 1.5));
            ConcreteClasses.Add(ConcreteClassEnum.C25_30, new ConcreteClass(ConcreteClassEnum.C25_30, 1.8));
            ConcreteClasses.Add(ConcreteClassEnum.C30_37, new ConcreteClass(ConcreteClassEnum.C30_37, 2.0));
            ConcreteClasses.Add(ConcreteClassEnum.C35_45, new ConcreteClass(ConcreteClassEnum.C35_45, 2.2));
            ConcreteClasses.Add(ConcreteClassEnum.C40_50, new ConcreteClass(ConcreteClassEnum.C40_50, 2.5));
            ConcreteClasses.Add(ConcreteClassEnum.C45_55, new ConcreteClass(ConcreteClassEnum.C45_55, 2.7));
            ConcreteClasses.Add(ConcreteClassEnum.C50_60, new ConcreteClass(ConcreteClassEnum.C50_60, 2.9));
            ConcreteClasses.Add(ConcreteClassEnum.C55_67, new ConcreteClass(ConcreteClassEnum.C55_67, 3.0));
            ConcreteClasses.Add(ConcreteClassEnum.C60_75, new ConcreteClass(ConcreteClassEnum.C60_75, 3.1));
            ConcreteClasses.Add(ConcreteClassEnum.C70_85, new ConcreteClass(ConcreteClassEnum.C70_85, 3.2));
            ConcreteClasses.Add(ConcreteClassEnum.C80_95, new ConcreteClass(ConcreteClassEnum.C80_95, 3.4));
            ConcreteClasses.Add(ConcreteClassEnum.C90_105, new ConcreteClass(ConcreteClassEnum.C90_105, 3.5));
        }
        #endregion // Constructors
    }

    /// <summary>
    /// List of possible concrete classes.
    /// </summary>
    /// <remarks>[PN-EN 1992-1-1 Table 3.1]</remarks>
    public enum ConcreteClassEnum
    {
        [Display(Name = "C12/15")]
        C12_15,
        [Display(Name = "C16/20")]
        C16_20,
        [Display(Name = "C20/25")]
        C20_25,
        [Display(Name = "C25/30")]
        C25_30,
        [Display(Name = "C30/37")]
        C30_37,
        [Display(Name = "C35/45")]
        C35_45,
        [Display(Name = "C40/50")]
        C40_50,
        [Display(Name = "C45/55")]
        C45_55,
        [Display(Name = "C50/60")]
        C50_60,
        [Display(Name = "C55/67")]
        C55_67,
        [Display(Name = "C60/75")]
        C60_75,
        [Display(Name = "C70/85")]
        C70_85,
        [Display(Name = "C80/95")]
        C80_95,
        [Display(Name = "C90/105")]
        C90_105
    }
}
