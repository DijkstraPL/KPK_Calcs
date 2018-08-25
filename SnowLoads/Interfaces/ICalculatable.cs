﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads.Interfaces
{
    public interface ICalculatable
    {
        /// <summary>
        /// Calculate snow load on roof.
        /// </summary>
        void CalculateSnowLoad();
    }
}
