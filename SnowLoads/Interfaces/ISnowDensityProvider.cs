using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace SnowLoads.Interfaces
{
    public interface ISnowDensityProvider
    {       
        /// <summary>
        /// Density of the snow.
        /// </summary>
        [Abbreviation("gamma")]
        [Unit("kN/m3")]
        double SnowDensity { get; set; }
    }
}
