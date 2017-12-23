using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindLoads
{
    public class WindLoad
    {
        #region Properties
        public WindLoadEnum WindLoadZone { get; set; } = WindLoadEnum.NONE;

        /// <value>Height above sea level also known as <c>A</c>.</value>
        public double HeightAboveSeaLevel { get; set; }

        /// <value>Fundamental value of the basic wind velocity also known as <c>v_b,0</c>.</value>
        public double FundamentalValueOFTheBasicWindVelocity { get; private set; }

        /// <value>Value of the basic wind velocity also known as <c>v_b</c>.</value>
        public double BasicWindVelocity { get; private set; }

        /// <value>Value of the basic velocity pressure also known as <c>q_b,0</c>.</value>
        public double BasicVelocityPressure { get; private set; }

        public WindDirectionEnum WindDirection { get; set; } = WindDirectionEnum.NONE;

        /// <value>Seasonal factor also known as <c>c_season</c>.</value>
        public double SeasonalFactor { get; set; } = 1.0;

        /// <value>Turbulence factor also known as <c>k_l</c>.</value>
        public double TurbulenceFactor { get; set; } = 1.0;

        /// <value>Turbulence intensity also known as <c>I_v(z)</c>.</value>
        public double TurbulenceIntensity { get; private set; }

        /// <value>Turbulence factor also known as <c>c_o</c>.</value>
        public double OrographyFactor { get; set; } = 1.0;

        public TerrainCategoryEnum TerrainCategory { get; set; }

        /// <value>Height above ground also known as <c>z</c>.</value>
        public double HeightAboveGround { get; set; }

        /// <value>Directional factors from <c>PN-EN 1991-1-4:2008 Tab. NA.2</c>.</value>
        public static readonly double[,] DirectionalFactors = new double[3, 12] {
            { 0.8, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7, 0.8, 0.9, 1.0, 1.0, 0.9 },
            { 1.0, 0.9, 0.8, 0.7, 0.7, 0.7, 0.7, 0.8, 0.9, 1.0, 1.0, 1.0 },
            { 0.8, 0.7, 0.7, 0.7, 0.7, 0.9, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 } };

        /// <value>Directional factor also known as <c>c_dir</c>.</value>
        public double DirectionalFactor { get; set; }

        /// <value>Roughness lengths from <c>PN-EN 1991-1-4:2005 Tab. 4.1</c>.</value>
        public static readonly double[] RoughnessLengths = new double[5] { 0.003, 0.01, 0.05, 0.3, 1.0 };

        /// <value>Rooughness length also known as <c>z_0</c>.</value>
        public double RoughnessLength { get; private set; }

        /// <value>Minimum heights from <c>PN-EN 1991-1-4:2008 Tab. NA.3</c>.</value>
        public static readonly int[] MinimumHeights = new int[5] { 1, 1, 2, 5, 10 };

        /// <value>Minimum height also known as <c>z_min</c>.</value>
        public int MinimumHeight { get; private set; }

        /// <value>Maximum heights from <c>PN-EN 1991-1-4:2008 Tab. NA.3</c>.</value>
        public static readonly int[] MaximumHeights = new int[5] { 200, 200, 300, 400, 500 };

        /// <value>Maximum height also known as <c>z_max</c>.</value>
        public int MaximumHeight { get; private set; }

        /// <value>Rooughness factor also known as <c>c_r(z)</c>.</value>
        public double RoughnessFactor { get; private set; }

        /// <value>Exposure factor also known as <c>c_e(z)</c>.</value>
        public double ExposureFactor { get; private set; }
        
        /// <value>Mean wind velocity also known as <c>v_m(z)</c>.</value>
        public double MeanWindVelocity { get; private set; }

        /// <value>Air density also known as <c>ρ(z)</c>.</value>
        public double AirDensity { get; set; } = 1.25;

        /// <value>Air density also known as <c>ρ(z)</c>.</value>
        public double PeakVelocityPressure { get; private set; } = 1.25;

        #endregion

        #region Constructors

        public WindLoad(WindLoadEnum zone, float heightAboveSeaLevel, TerrainCategoryEnum terrainCategory, double heightAboveGround)
        {
            WindLoadZone = zone;
            HeightAboveSeaLevel = heightAboveSeaLevel;
            TerrainCategory = terrainCategory;
            HeightAboveGround = heightAboveGround;
        }

        public WindLoad(WindLoadEnum zone, float heightAboveSeaLevel, TerrainCategoryEnum terrainCategory, double constructionHeight, WindDirectionEnum windDirection) :
            this(zone, heightAboveSeaLevel, terrainCategory, constructionHeight)
        {
            WindDirection = windDirection;
        }

        public void CalculateWindLoad()
        {
            SetVelocityValuesAndDirectionalFactorForCurrentWindZone();
            CalculateBasicWindVelocity();
            SetTheRoughnessLengthAndExtremeHeights((int)TerrainCategory - 1);
            CalculateRoughnessAndExposureFactor();
            // CalculateOrographyFactor(); not implemented
            CalculateTurbulenceIntensity();
            CalculateMeanWindVelocity();
            CalculatePeakVelocityPressure();
        }

        #endregion

        #region CalculationMethods

        /// <summary>
        /// Sets the values which depends on wind zone.
        /// </summary>
        /// <exception cref="System.ArgumentException">Thrown when wind zone is not selected.</exception>
        /// <remarks>
        /// <para>Method base on <c>PN-EN 1991-1-4:2008 Tab. NA.1</c></para>
        /// <para>and on <c>PN-EN 1991-1-4:2008 Tab. NA.2</c></para>
        /// </remarks>
        /// <seealso cref="WindLoad.CalculateBasicWindVelocityForFirstZone()"/>
        /// <seealso cref="WindLoad.CalculateBasicWindVelocityForSecondZone()"/>
        /// <seealso cref="WindLoad.CalculateBasicWindVelocityForThirdZone()"/>
        /// <seealso cref="WindLoad.CalculateBasicVelocityPressureForFirstZone()"/>
        /// <seealso cref="WindLoad.CalculateBasicVelocityPressureForSecondZone()"/>
        /// <seealso cref="WindLoad.CalculateBasicVelocityPressureForThirdZone()"/>
        /// <seealso cref="WindLoad.GetDirectionalFactor(int)"/>
        private void SetVelocityValuesAndDirectionalFactorForCurrentWindZone()
        {
            switch (WindLoadZone)
            {
                case WindLoadEnum.FIRST_WIND_ZONE:
                    FundamentalValueOFTheBasicWindVelocity = CalculateBasicWindVelocityForFirstZone();
                    BasicVelocityPressure = CalculateBasicVelocityPressureForFirstZone();
                    DirectionalFactor = GetDirectionalFactor((int)WindLoadZone);
                    break;
                case WindLoadEnum.SECOND_WIND_ZONE:
                    FundamentalValueOFTheBasicWindVelocity = CalculateBasicWindVelocityForSecondZone();
                    BasicVelocityPressure = CalculateBasicVelocityPressureForSecondZone();
                    DirectionalFactor = GetDirectionalFactor((int)WindLoadZone);
                    break;
                case WindLoadEnum.THIRD_WIND_ZONE:
                    FundamentalValueOFTheBasicWindVelocity = CalculateBasicWindVelocityForThirdZone();
                    BasicVelocityPressure = CalculateBasicVelocityPressureForThirdZone();
                    DirectionalFactor = GetDirectionalFactor((int)WindLoadZone);
                    break;
                case WindLoadEnum.BETWEEN_FIRST_AND_SECOND_WIND_ZONE:
                    FundamentalValueOFTheBasicWindVelocity = (CalculateBasicWindVelocityForFirstZone() + CalculateBasicWindVelocityForSecondZone()) / 2;
                    BasicVelocityPressure = (CalculateBasicVelocityPressureForFirstZone() + CalculateBasicVelocityPressureForSecondZone()) / 2;
                    DirectionalFactor = GetDirectionalFactor((int)WindLoadZone);
                    break;
                default:
                    throw new ArgumentException("Current wind zone is not supported!");
            }
        }

        /// <summary>
        /// Calculate value of basic wind velocity
        /// </summary>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4:2005 Eq.4.1</c>
        /// </remarks>
        private void CalculateBasicWindVelocity()
        {
            BasicWindVelocity = DirectionalFactor * SeasonalFactor * FundamentalValueOFTheBasicWindVelocity;
        }

        /// <summary>
        /// Sets the values which depends on terrain zone.
        /// </summary>
        /// <exception cref="System.ArgumentException">Thrown when terrain zone is not selected.</exception>
        /// <remarks>
        /// <para>Method base on <c>PN-EN 1991-1-4:2008 Tab. NA.3</c></para>
        /// <para>and on <c>PN-EN 1991-1-4:2005 Tab. 4.1</c>.</para>
        /// </remarks>
        /// <param name="currentTerrainCategory">Current terrain category, should be one lower than enum.</param>
        private void SetTheRoughnessLengthAndExtremeHeights(int currentTerrainCategory)
        {
            if (TerrainCategory == TerrainCategoryEnum.NONE)
                throw new ArgumentException("There is none terrain category selected.");

            RoughnessLength = RoughnessLengths[currentTerrainCategory];
            MinimumHeight = MinimumHeights[currentTerrainCategory];
            MaximumHeight = MaximumHeights[currentTerrainCategory];
        }

        /// <summary>
        /// Calculate value of roughness and exposure factor
        /// </summary>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4:2008 Tab. NA.3</c>
        /// </remarks>
        private void CalculateRoughnessAndExposureFactor()
        {
            double z = (HeightAboveGround <= MaximumHeight) ? HeightAboveGround : MaximumHeight;
            z = (z >= MinimumHeight) ? z : MinimumHeight;

            switch (TerrainCategory)
            {
                case TerrainCategoryEnum.TERRAIN_CATEGORY_0:
                    RoughnessFactor = 1.3 * Math.Pow(z / 10, 0.11);
                    ExposureFactor = 3.0 * Math.Pow(z / 10, 0.17);
                    break;
                case TerrainCategoryEnum.TERRAIN_CATEGORY_1:
                    RoughnessFactor = 1.2 * Math.Pow(z / 10, 0.13);
                    ExposureFactor = 2.8 * Math.Pow(z / 10, 0.19);
                    break;
                case TerrainCategoryEnum.TERRAIN_CATEGORY_2:
                    RoughnessFactor = 1.0 * Math.Pow(z / 10, 0.17);
                    ExposureFactor = 2.3 * Math.Pow(z / 10, 0.24);
                    break;
                case TerrainCategoryEnum.TERRAIN_CATEGORY_3:
                    RoughnessFactor = 0.8 * Math.Pow(z / 10, 0.19);
                    ExposureFactor = 1.9 * Math.Pow(z / 10, 0.26);
                    break;
                case TerrainCategoryEnum.TERRAIN_CATEGORY_4:
                    RoughnessFactor = 0.6 * Math.Pow(z / 10, 0.24);
                    ExposureFactor = 1.5 * Math.Pow(z / 10, 0.29);
                    break;
            }
        }

        /// <summary>
        /// Calculate value of orography factor
        /// </summary>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4:2005 A.3</c>
        /// </remarks>
        private void CalculateOrographyFactor()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the value for turbulence intensity.
        /// </summary>
        /// <exception cref="System.ArgumentException">Thrown when building is too height for this algorithms.</exception>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4:2005 Eq. 4.7</c>
        /// </remarks>
        private void CalculateTurbulenceIntensity()
        {
            double z = (HeightAboveGround >= MinimumHeight) ? HeightAboveGround : MinimumHeight;

            if (z > MaximumHeight)
                throw new ArgumentException("Construction is too height to calculate it using thsi algorithms.");

            TurbulenceIntensity = TurbulenceFactor / (OrographyFactor * Math.Log(z / RoughnessLength));
        }

        /// <summary>
        /// Sets the value for mean wind velocity.
        /// </summary>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4:2005 Eq. 4.3</c>
        /// </remarks>
        private void CalculateMeanWindVelocity()
        {
            MeanWindVelocity = RoughnessFactor * OrographyFactor * BasicWindVelocity;
        }
        
        /// <summary>
        /// Sets the value for mean wind velocity.
        /// </summary>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4:2005 Eq. 4.7</c>
        /// </remarks>
        private void CalculatePeakVelocityPressure()
        {
            PeakVelocityPressure = (1 + 7 * TurbulenceIntensity) * 1 / 2 * AirDensity * Math.Pow(MeanWindVelocity, 2);
        }

        #endregion

        #region Direcional Factor

        /// <summary>
        /// Calculate directional factor for current wind zone and wind direction.
        /// </summary>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4:2008 Tab. NA.2</c>
        /// </remarks>
        /// <param name="currentWindZone">Represents wind zone as a number. Fourth one is for terrain between first and second one.</param>
        /// <returns>Value of directional factor.</returns>
        private double GetDirectionalFactor(int currentWindZone)
        {
            if (WindDirection == WindDirectionEnum.NONE)
                return 1;

            if (currentWindZone == 4)
                return (DirectionalFactors[1, (int)WindDirection] + DirectionalFactors[2, (int)WindDirection]) / 2;

            return DirectionalFactors[currentWindZone - 1, (int)WindDirection];
        }

        #endregion

        #region Basic Velocity Pressure

        /// <summary>
        /// Calculate value of the velocity pressure.
        /// </summary>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4:2008 Tab. NA.1</c>
        /// </remarks>
        /// <returns>Value of the velocity pressure for first zone.</returns>
        /// <seealso cref="WindLoad.CalculateBasicVelocityPressureForSecondZone()"/>
        /// <seealso cref="WindLoad.CalculateBasicVelocityPressureForThirdZone()"/>
        private double CalculateBasicVelocityPressureForThirdZone()
        {
            if (HeightAboveSeaLevel <= 300)
                return 0.3;
            return 0.3 * Math.Pow(1 + 0.0006 * (HeightAboveSeaLevel - 300), 2) * (20000 - HeightAboveSeaLevel) / (20000 + HeightAboveSeaLevel);
        }

        /// <summary>
        /// Calculate value of the velocity pressure.
        /// </summary>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4:2008 Tab. NA.1</c>
        /// </remarks>
        /// <returns>Value of the velocity pressure for second zone.</returns>
        /// <seealso cref="WindLoad.CalculateBasicVelocityPressureForFirstZone()"/>
        /// <seealso cref="WindLoad.CalculateBasicVelocityPressureForThirdZone()"/>
        private double CalculateBasicVelocityPressureForSecondZone()
        {
            return 0.42;
        }

        /// <summary>
        /// Calculate value of the velocity pressure.
        /// </summary>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4:2008 Tab. NA.1</c>
        /// </remarks>
        /// <returns>Value of the velocity pressure for third zone.</returns>
        /// <seealso cref="WindLoad.CalculateBasicVelocityPressureForFirstZone()"/>
        /// <seealso cref="WindLoad.CalculateBasicVelocityPressureForSecondZone()"/>
        private double CalculateBasicVelocityPressureForFirstZone()
        {
            if (HeightAboveSeaLevel <= 300)
                return 0.3;
            return 0.3 * Math.Pow(1 + 0.0006 * (HeightAboveSeaLevel - 300), 2);
        }

        #endregion

        #region Basic Wind Velocity

        /// <summary>
        /// Calculate fundamental value of the basic wind velocity.
        /// </summary>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4:2008 Tab. NA.1</c>
        /// </remarks>
        /// <returns>Value of the fundamental basic wind velocity for first zone.</returns>
        /// <seealso cref="WindLoad.CalculateBasicWindVelocityForSecondZone()"/>
        /// <seealso cref="WindLoad.CalculateBasicWindVelocityForThirdZone()"/>
        private double CalculateBasicWindVelocityForThirdZone()
        {
            if (HeightAboveSeaLevel <= 300)
                return 22;

            return 22 * (1 + 0.0006 * (HeightAboveSeaLevel - 300));
        }

        /// <summary>
        /// Calculate fundamental value of the basic wind velocity.
        /// </summary>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4:2008 Tab. NA.1</c>
        /// </remarks>
        /// <returns>Value of the fundamental basic wind velocity for second zone.</returns>
        /// <seealso cref="WindLoad.CalculateBasicWindVelocityForFirstZone()"/>
        /// <seealso cref="WindLoad.CalculateBasicWindVelocityForThirdZone()"/>
        private double CalculateBasicWindVelocityForSecondZone()
        {
            return 26;
        }

        /// <summary>
        /// Calculate fundamental value of the basic wind velocity.
        /// </summary>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4:2008 Tab. NA.1</c>
        /// </remarks>
        /// <returns>Value of the fundamental basic wind velocity for third zone.</returns>
        /// <seealso cref="WindLoad.CalculateBasicWindVelocityForFirstZone()"/>
        /// <seealso cref="WindLoad.CalculateBasicWindVelocityForSecondZone()"/>
        private double CalculateBasicWindVelocityForFirstZone()
        {
            if (HeightAboveSeaLevel <= 300)
                return 22;

            return 22 * (1 + 0.0006 * (HeightAboveSeaLevel - 300));
        }

        #endregion

        public enum CultureNationalAnexEnum
        {
            NONE,
            PL_EC,
        }

        public enum WindLoadEnum
        {
            NONE,
            FIRST_WIND_ZONE,
            SECOND_WIND_ZONE,
            THIRD_WIND_ZONE,
            BETWEEN_FIRST_AND_SECOND_WIND_ZONE,

        };

        public enum WindDirectionEnum
        {
            NONE,
            DEGREE_0,
            DEGREE_30,
            DEGREE_60,
            DEGREE_90,
            DEGREE_120,
            DEGREE_150,
            DEGREE_180,
            DEGREE_210,
            DEGREE_240,
            DEGREE_270,
            DEGREE_300,
            DEGREE_330,

        }

        public enum TerrainCategoryEnum
        {
            NONE,
            TERRAIN_CATEGORY_0,
            TERRAIN_CATEGORY_1,
            TERRAIN_CATEGORY_2,
            TERRAIN_CATEGORY_3,
            TERRAIN_CATEGORY_4,
        }

    }
}
