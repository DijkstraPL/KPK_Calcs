using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace SnowLoads.Interfaces
{
    public interface ISnowLoad
    {
         DesignSituation CurrentDesignSituation { get; set; }

        bool ExcepctionalSituation { get; set; }
        
        double SnowDensity { get; set; }
       
        [Abbreviation("s_k")]
        [Unit("kN/m2")]
        double DefaultCharacteristicSnowLoad { get; }
        
        [Abbreviation("s_n")]
        [Unit("kN/m2")]
        double SnowLoadForSpecificReturnPeriod { get; }

        [Abbreviation("V")]
        [Unit("")]
        double VariationCoefficient { get; }

        [Abbreviation("n")]
        [Unit("year")]
        int ReturnPeriod { get; set; }
        
        [Abbreviation("C_esl")]
        [Unit("")]
        double ExceptionalSnowLoadCoefficient { get; }

        [Abbreviation("s_Ad")]
        [Unit("kN/m2")]
        double DesignExceptionalSnowLoadForSpecificReturnPeriod { get;  }

         IBuildingSite BuildingSite { get; }

        void CalculateSnowLoad();
    }
}
