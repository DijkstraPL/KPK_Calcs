using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads.Interfaces
{
    public interface ISnowLoad
    {
         DesignSituation CurrentDesignSituation { get; set; }

        bool ExcepctionalSituation { get; set; }
        
        double SnowDensity { get; set; }
       
        [Abbreviation("s_k")]
        double DefaultCharacteristicSnowLoad { get; }
        
        [Abbreviation("s_n")]
        double SnowLoadForSpecificReturnPeriod { get; }

        [Abbreviation("V")]
        double VariationCoefficient { get; }

        [Abbreviation("n")]
        int ReturnPeriod { get; set; }
        
        [Abbreviation("C_esl")]
        double ExceptionalSnowLoadCoefficient { get; }

        [Abbreviation("s_Ad")]
        double DesignExceptionalSnowLoadForSpecificReturnPeriod { get;  }

         IBuildingSite BuildingSite { get; }

        void CalculateSnowLoad();
    }
}
