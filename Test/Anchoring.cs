using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Anchoring
    {
    }

    public enum ClassOfConcrete
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
    }

    public class Concrete
    {
        public ClassOfConcrete Class { get; set; }

        public int CompressiveStrength { get; set; }
    }

    public enum ClassOfSteel
    {
        fy400, fy500, fy600
    }

    public class Steel
    {
        public ClassOfSteel Class { get; set; }
    }
}
