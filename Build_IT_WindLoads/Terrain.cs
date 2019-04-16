using Build_IT_CommonTools;
using Build_IT_WindLoads.TerrainOrographies;
using Build_IT_WindLoads.TerrainOrographies.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_WindLoads
{

    public abstract class Terrain : ITerrain
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>[PN-EN 1991-1-4 4.2.2.(1)]</remarks>
        [Abbreviation("z_0,II")]
        [Unit("m")]
        public const double RoughnessLengthInSecondTerrainType = 0.05;

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>[PN-EN 1991-1-4 Tab.4.1]</remarks>
        [Abbreviation("z_0")]
        [Unit("m")]
        public double RoughnessLength { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>[PN-EN 1991-1-4 Tab.4.1]</remarks>
        [Abbreviation("z_min")]
        [Unit("m")]
        public double MinimumHeight { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>[PN-EN 1991-1-4 4.2.2.(1)]</remarks>
        [Abbreviation("z_max")]
        [Unit("m")]
        public double MaximumHeight { get; }

        public ITerrainOrography TerrainOrography { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>[PN-EN 1991-1-4 Eq.4.5]</remarks>
        [Abbreviation("k_r")]
        [Unit("")]
        public double TerrainFactor 
            => 0.19 * Math.Pow(RoughnessLength / RoughnessLengthInSecondTerrainType, 0.07);
        
        protected Terrain(
            double roughnessLength,
            double minimumHeight, 
            double maximumHeight, 
            ITerrainOrography terrainOrography)
        {
            TerrainOrography = terrainOrography ?? new NoTerrainorography();
            RoughnessLength = roughnessLength;
            MinimumHeight = minimumHeight;
            MaximumHeight = maximumHeight;
        }

        /// <summary>
        /// c_r(z)
        /// </summary>
        /// <remarks>[PN-EN 1991-1-4 Eq.4.4]</remarks>
        public virtual double GetRoughnessFactorAt(double height)
        {
            height = CheckMinimumHeight(height);

            return TerrainFactor * Math.Log(height / RoughnessLength);
        }

        protected double CheckMinimumHeight(double height)
        {
            if (height > MaximumHeight)
                throw new ArgumentOutOfRangeException("Height is too large.");
            if (height < MinimumHeight)
                height = MinimumHeight;
            return height;
        }
    }
}
