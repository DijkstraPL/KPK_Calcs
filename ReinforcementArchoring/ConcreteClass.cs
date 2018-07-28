using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace ReinforcementArchoring
{
    public class ConcreteClass
    {
        #region Properties

        [Abbreviation("alpha_ct")]
        public static double LongTermEffectTensileStrengthCoefficient { get; } = 1;

        [Abbreviation("gamma_c")]
        public static double PartialSafetyFactor { get; } = 1.4;

        public static Dictionary<ConcreteClassEnum, ConcreteClass> ConcretClasses { get; set; }

        [Abbreviation("f_ctk,0,05")]
        public double CharacteristicAxialTensileStrength { get; }

        [Abbreviation("f_ctd")]
        public double DesignValueConcreteTensileStrength
        {
            get
            {
                return LongTermEffectTensileStrengthCoefficient * CharacteristicAxialTensileStrength / PartialSafetyFactor;
            }
        }
        #endregion // Properties

        #region Constructors

        private ConcreteClass(double characteristicAxialTensileStrength)
        {
            CharacteristicAxialTensileStrength = characteristicAxialTensileStrength;
        }

        static ConcreteClass()
        {
            ConcretClasses = new Dictionary<ConcreteClassEnum, ConcreteClass>();
            ConcretClasses.Add(ConcreteClassEnum.C12_15, new ConcreteClass(1100));
            ConcretClasses.Add(ConcreteClassEnum.C16_20, new ConcreteClass(1300));
            ConcretClasses.Add(ConcreteClassEnum.C20_25, new ConcreteClass(1500));
            ConcretClasses.Add(ConcreteClassEnum.C25_30, new ConcreteClass(1800));
            ConcretClasses.Add(ConcreteClassEnum.C30_37, new ConcreteClass(2000));
            ConcretClasses.Add(ConcreteClassEnum.C35_45, new ConcreteClass(2200));
            ConcretClasses.Add(ConcreteClassEnum.C40_50, new ConcreteClass(2500));
            ConcretClasses.Add(ConcreteClassEnum.C45_55, new ConcreteClass(2700));
            ConcretClasses.Add(ConcreteClassEnum.C50_60, new ConcreteClass(2900));
            ConcretClasses.Add(ConcreteClassEnum.C55_67, new ConcreteClass(3000));
            ConcretClasses.Add(ConcreteClassEnum.C60_75, new ConcreteClass(3100));
            ConcretClasses.Add(ConcreteClassEnum.C70_85, new ConcreteClass(3200));
            ConcretClasses.Add(ConcreteClassEnum.C80_95, new ConcreteClass(3400));
            ConcretClasses.Add(ConcreteClassEnum.C90_105, new ConcreteClass(3500));
        } 
        #endregion // Constructors
    }

    public enum ConcreteClassEnum
    {
        C12_15,
        C16_20,
        C20_25,
        C25_30,
        C30_37,
        C35_45,
        C40_50,
        C45_55,
        C50_60,
        C55_67,
        C60_75,
        C70_85,
        C80_95,
        C90_105
    }
}
