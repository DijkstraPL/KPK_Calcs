using Build_IT_CommonTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_WindLoads
{
    public class BuildingSite : IBuildingSite
    {
        [Abbreviation("a")]
        [Unit("m")]
        public double HeightAboveSeaLevel { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>[PN-EN 1991-1-4 Fig.NB.1]</remarks>
        public WindZone WindZone { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>[PN-EN 1991-1-4 Tab.4.1]</remarks>
        public ITerrain Terrain { get; }

        [Abbreviation("v_b,0")]
        [Unit("m/s")]
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>[PN-EN 1991-1-4 Tab.NB.1]</remarks>
        public double FundamentalValueBasicWindVelocity { get; }
        [Abbreviation("c_season")]
        [Unit("-")]
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>[PN-EN 1991-1-4 NB.1.5]</remarks>
        public double SeasonalFactor => _seasonalFactor?.GetFactor() ?? 1;
        [Abbreviation("c_dir")]
        [Unit("-")]
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>[PN-EN 1991-1-4 NB.1.5]</remarks>
        public double DirectionalFactor => _directionalFactor?.GetFactor() ?? 1;

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>[PN-EN 1991-1-4 Eq.4.1]</remarks>
        public double BasicWindVelocity => SeasonalFactor * DirectionalFactor * FundamentalValueBasicWindVelocity;

        private readonly IFactor _seasonalFactor;
        private readonly IFactor _directionalFactor;

        public BuildingSite(double heightAboveSeaLevel, WindZone windZone, ITerrain terrain,
            IFactor seasonalFactor = null, IFactor directionalFactor = null)
        {
            HeightAboveSeaLevel = heightAboveSeaLevel;
            WindZone = windZone;
            Terrain = terrain;
            _seasonalFactor = seasonalFactor;
            _directionalFactor = directionalFactor;

            FundamentalValueBasicWindVelocity = GetFundamentalValueBasicWindVelocity();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>[PN-EN 1991-1-4 Tab.NB.1]</remarks>
        private double GetFundamentalValueBasicWindVelocity()
        {
            switch (WindZone)
            {
                case WindZone.I:
                case WindZone.III:
                    if (HeightAboveSeaLevel <= 300)
                        return 22;
                    else
                        return 22 * (1 + 0.0006 * (HeightAboveSeaLevel - 300));
                case WindZone.II:
                    return 26;
                default:
                    throw new ArgumentException("Wrong wind zone");
            }
        }
    }
}
