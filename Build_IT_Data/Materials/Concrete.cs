using Build_IT_CommonTools;

namespace Build_IT_Data.Materials
{
    public class Concrete : Material
    {
        //[Abbreviation("f_ck")]
        //[Unit("MPa")]
        //public int CharacteristicCompressiveCylinderStrength { get; protected set; }

        //[Abbreviation("f_ck,cube")]
        //[Unit("MPa")]
        //public int CharacteristicCompressiveCubeStrength { get; protected set; }

        //[Abbreviation("f_cm")]
        //[Unit("MPa")]
        //public int MeanValueCylinderCompressiveStrength { get; protected set; }

        #region Constructors

        public Concrete(double youngModulus, bool withReinforcement) 
            : base(youngModulus, thermalExpansionCoefficient: 0.000010)
        {
            if (withReinforcement)
                Density = 2500;
            else
                Density = 2400;
        }
        

        #endregion // Constructors
    }
}
