using Build_IT_CommonTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_WindLoads
{
    public class Terrain : ITerrain
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>[PN-EN 1991-1-4 4.2.2.(1)]</remarks>
        [Abbreviation("z_max")]
        [Unit("m")]
        public const double MaxHeight = 200;

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
        /// <remarks>[PN-EN 1991-1-4 Eq.4.5]</remarks>
        [Abbreviation("k_r")]
        [Unit("")]
        public double TerrainFactor 
            => 0.19 * Math.Pow(RoughnessLength / RoughnessLengthInSecondTerrainType, 0.07);

        public static Terrain Create(TerrainType terrainType, ITerrainOrography terrainOrography)
        {
            switch (terrainType)
            {
                case TerrainType.Terrain_0:
                    return new Terrain(roughnessLength: 0.003, minimumHeight: 1);
                case TerrainType.Terrain_I:
                    return new Terrain(roughnessLength: 0.01, minimumHeight: 1);
                case TerrainType.Terrain_II:
                    return new Terrain(roughnessLength: 0.05, minimumHeight: 2);
                case TerrainType.Terrain_III:
                    return new Terrain(roughnessLength: 0.3, minimumHeight: 5);
                case TerrainType.Terrain_IV:
                    return new Terrain(roughnessLength: 1, minimumHeight: 10);
                default:
                    throw new ArgumentException("Wrong terrain type.");
            }
        }

        private Terrain(double roughnessLength, double minimumHeight)
        {
            RoughnessLength = roughnessLength;
            MinimumHeight = minimumHeight;
        }

        /// <summary>
        /// c_r(z)
        /// </summary>
        /// <remarks>[PN-EN 1991-1-4 Eq.4.4]</remarks>
        public double GetRoughnessFactorAt(double height)
        {
            if (height < MinimumHeight)
                height = MinimumHeight;

            return TerrainFactor * Math.Log(height / RoughnessLength);
        }

    }
}
