﻿using Tools;

namespace SnowLoads.Interfaces
{
    public interface ILengthProvider
    {
        /// <summary>
        /// Length of the drift.
        /// </summary>
        [Abbreviation("l_s")]
        [Unit("m")]
        double DriftLength { get; }

        /// <summary>
        /// Calculate <see cref="DriftLength"/>.
        /// </summary>
        void CalculateDriftLength();
    }
}
