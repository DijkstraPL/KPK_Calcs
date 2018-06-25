using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindLoads
{
    public class WindLoad : IWindLoad
    {
        #region Properties
        public WindLoadEnum WindLoadZone { get; private set; } = WindLoadEnum.NONE;

        /// <summary>Height above sea level also known as <c>A</c>.</summary>
        public double HeightAboveSeaLevel { get; private set; }

        /// <summary>Fundamental value of the basic wind velocity also known as <c>v_b,0</c>.</summary>
        public double FundamentalValueOFTheBasicWindVelocity { get; private set; }

        /// <summary>Value of the basic wind velocity also known as <c>v_b</c>.</summary>
        public double BasicWindVelocity { get; private set; }

        /// <summary>Value of the basic velocity pressure also known as <c>q_b,0</c>.</summary>
        public double BasicVelocityPressure { get; private set; }

        public WindDirectionEnum WindDirection { get; private set; } = WindDirectionEnum.NONE;

        /// <summary>Seasonal factor also known as <c>c_season</c>.</summary>
        public double SeasonalFactor { get; private set; } = 1.0;

        /// <summary>Turbulence factor also known as <c>k_l</c>.</summary>
        public double TurbulenceFactor { get; private set; } = 1.0;

        /// <summary>Turbulence intensity also known as <c>I_v(z)</c>.</summary>
        public double TurbulenceIntensity { get; private set; }

        /// <summary>Turbulence factor also known as <c>c_o</c>.</summary>
        public double OrographyFactor { get; private set; } = 1.0;

        public TerrainCategoryEnum TerrainCategory { get; private set; }

        /// <summary>Height above ground also known as <c>z</c>.</summary>
        public double HeightAboveGround { get; private set; }

        /// <summary>Directional factors from <c>PN-EN 1991-1-4:2008 Tab. NA.2</c>.</summary>
        public static readonly double[,] DirectionalFactors = new double[3, 12] {
            { 0.8, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7, 0.8, 0.9, 1.0, 1.0, 0.9 },
            { 1.0, 0.9, 0.8, 0.7, 0.7, 0.7, 0.7, 0.8, 0.9, 1.0, 1.0, 1.0 },
            { 0.8, 0.7, 0.7, 0.7, 0.7, 0.9, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 } };

        /// <summary>Directional factor also known as <c>c_dir</c>.</summary>
        public double DirectionalFactor { get; private set; }

        /// <summary>Roughness lengths from <c>PN-EN 1991-1-4:2005 Tab. 4.1</c>.</summary>
        public static readonly double[] RoughnessLengths = new double[5] { 0.003, 0.01, 0.05, 0.3, 1.0 };

        /// <summary>Rooughness length also known as <c>z_0</c>.</summary>
        public double RoughnessLength { get; private set; }

        /// <summary>Minimum heights from <c>PN-EN 1991-1-4:2008 Tab. NA.3</c>.</summary>
        public static readonly int[] MinimumHeights = new int[5] { 1, 1, 2, 5, 10 };

        /// <summary>Minimum height also known as <c>z_min</c>.</summary>
        public int MinimumHeight { get; private set; }

        /// <summary>Maximum heights from <c>PN-EN 1991-1-4:2008 Tab. NA.3</c>.</summary>
        public static readonly int[] MaximumHeights = new int[5] { 200, 200, 300, 400, 500 };

        /// <summary>Maximum height also known as <c>z_max</c>.</summary>
        public int MaximumHeight { get; private set; }

        /// <summary>Rooughness factor also known as <c>c_r(z)</c>.</summary>
        public double RoughnessFactor { get; private set; }

        /// <summary>Exposure factor also known as <c>c_e(z)</c>.</summary>
        public double ExposureFactor { get; private set; }

        /// <summary>Mean wind velocity also known as <c>v_m(z)</c>.</summary>
        public double MeanWindVelocity { get; private set; }

        /// <summary>Air density also known as <c>ρ</c>.</summary>
        public double AirDensity { get; private set; } = 1.25;

        /// <summary>Air density also known as <c>q_p(z)</c>.</summary>
        public double PeakVelocityPressure { get; private set; } = 1.25;

        /// <summary>Width of the building also known as <c>d</c>.</summary>
        public double BuildingWidth { get; private set; }

        /// <summary>Length of the building also known as <c>b</c>.</summary>
        public double BuildingLength { get; private set; }

        /// <summary>Width of the building face also known as <c>b</c>.</summary>
        public double BuildingFaceWidth { get; private set; }

        /// <summary>Height for horizontal strips also known as <c>h_strip</c>.</summary>
        public double HorizontalStrip { get; private set; } = 1.0;

        #endregion

        #region Constructors

        public WindLoad(WindLoadEnum zone, double heightAboveSeaLevel, TerrainCategoryEnum terrainCategory,
            double heightAboveGround, double buildingWidth, double buildingLength)
        {
            WindLoadZone = zone;
            HeightAboveSeaLevel = heightAboveSeaLevel;
            TerrainCategory = terrainCategory;
            HeightAboveGround = heightAboveGround;
            BuildingWidth = buildingWidth;
            BuildingLength = buildingLength;
        }

        public WindLoad(WindLoadEnum zone, double heightAboveSeaLevel, TerrainCategoryEnum terrainCategory,
            double heightAboveGround, double buildingWidth, double buildingLength,
            WindDirectionEnum windDirection) :
            this(zone, heightAboveSeaLevel, terrainCategory, heightAboveGround, buildingWidth, buildingLength)
        {
            WindDirection = windDirection;
        }

        #endregion

        public void CalculateWindLoad(double heightForCalculations, bool windAlongTheLength)
        {
            if (heightForCalculations > HeightAboveGround)
                throw new ArgumentOutOfRangeException("Calculation height shouldn't be more than height above the ground.");

            SetVelocityValuesAndDirectionalFactorForCurrentWindZone();
            CalculateBasicWindVelocity();
            SetTheRoughnessLengthAndExtremeHeights((int)TerrainCategory - 1);

            SetBuildingFaceWidth(windAlongTheLength);

            double referenceHeight = SetReferenceHeight(heightForCalculations);

            CalculateRoughnessAndExposureFactor(referenceHeight);

            // CalculateOrographyFactor(); not implemented
            CalculateTurbulenceIntensity(referenceHeight);
            CalculateMeanWindVelocity();
            CalculatePeakVelocityPressure();
        }

        #region CalculationMethods

        /// <summary>
        /// Set proper width to further calculation.
        /// </summary>
        /// <remarks>
        /// Method is base on <c>PN-EN 1991-1-4:2005 Fig.7.4</c>.
        /// </remarks>
        /// <param name="windAlongTheLength">Wind is blowing along length.</param>
        public void SetBuildingFaceWidth(bool windAlongTheLength)
        {
            if (windAlongTheLength)
                BuildingFaceWidth = BuildingWidth;
            else
                BuildingFaceWidth = BuildingLength;
        }

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
        public void SetVelocityValuesAndDirectionalFactorForCurrentWindZone()
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
        public void CalculateBasicWindVelocity()
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
        public void SetTheRoughnessLengthAndExtremeHeights(int currentTerrainCategory)
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
        public void CalculateRoughnessAndExposureFactor(double referenceHeight)
        {
            switch (TerrainCategory)
            {
                case TerrainCategoryEnum.TERRAIN_CATEGORY_0:
                    RoughnessFactor = 1.3 * Math.Pow(referenceHeight / 10, 0.11);
                    ExposureFactor = 3.0 * Math.Pow(referenceHeight / 10, 0.17);
                    break;
                case TerrainCategoryEnum.TERRAIN_CATEGORY_1:
                    RoughnessFactor = 1.2 * Math.Pow(referenceHeight / 10, 0.13);
                    ExposureFactor = 2.8 * Math.Pow(referenceHeight / 10, 0.19);
                    break;
                case TerrainCategoryEnum.TERRAIN_CATEGORY_2:
                    RoughnessFactor = 1.0 * Math.Pow(referenceHeight / 10, 0.17);
                    ExposureFactor = 2.3 * Math.Pow(referenceHeight / 10, 0.24);
                    break;
                case TerrainCategoryEnum.TERRAIN_CATEGORY_3:
                    RoughnessFactor = 0.8 * Math.Pow(referenceHeight / 10, 0.19);
                    ExposureFactor = 1.9 * Math.Pow(referenceHeight / 10, 0.26);
                    break;
                case TerrainCategoryEnum.TERRAIN_CATEGORY_4:
                    RoughnessFactor = 0.6 * Math.Pow(referenceHeight / 10, 0.24);
                    ExposureFactor = 1.5 * Math.Pow(referenceHeight / 10, 0.29);
                    break;
            }
        }

        /// <summary>
        /// Calculate value of orography factor
        /// </summary>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4:2005 A.3</c>
        /// </remarks>
        public void CalculateOrographyFactor()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the value for turbulence intensity.
        /// </summary>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4:2005 Eq. 4.7</c>.
        /// </remarks>
        public void CalculateTurbulenceIntensity(double referenceHeight)
        {
            TurbulenceIntensity = TurbulenceFactor / (OrographyFactor * Math.Log(referenceHeight / RoughnessLength));
        }

        /// <summary>
        /// Sets the value of reference height.
        /// </summary>
        /// <exception cref="System.ArgumentException">Thrown when building is too height for this algorithms.</exception>
        /// <remarks>
        /// <para>Method base on <c>PN-EN 1991-1-4:2005 Fig. 7.4</c></para>
        /// <para>and on <c>PN-EN 1991-1-4:2008 Tab. NA.3</c></para>
        /// </remarks>
        public double SetReferenceHeight(double heightForCalculations)
        {
            if (BuildingFaceWidth >= HeightAboveGround)
                heightForCalculations = HeightAboveGround;
            else if (BuildingFaceWidth < HeightAboveGround && HeightAboveGround <= 2 * BuildingFaceWidth)
            {
                if (heightForCalculations < BuildingFaceWidth)
                    heightForCalculations = BuildingFaceWidth;
                else
                    heightForCalculations = HeightAboveGround;
            }
            else
            {
                if (heightForCalculations > HeightAboveGround - BuildingFaceWidth)
                    heightForCalculations = HeightAboveGround;
                else if (heightForCalculations <= BuildingFaceWidth)
                    heightForCalculations = BuildingFaceWidth;
                else
                {
                    int numberOfStrips = (int)(heightForCalculations - BuildingFaceWidth / HorizontalStrip);

                    heightForCalculations = BuildingFaceWidth + numberOfStrips * HorizontalStrip;
                }
            }

            double referenceHeight = (heightForCalculations >= MinimumHeight) ? heightForCalculations : MinimumHeight;

            if (referenceHeight > MaximumHeight)
                throw new ArgumentException("Construction is too height to calculate it using this algorithms.");

            return referenceHeight;
        }

        /// <summary>
        /// Sets the value for mean wind velocity.
        /// </summary>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4:2005 Eq. 4.3</c>
        /// </remarks>
        public void CalculateMeanWindVelocity()
        {
            MeanWindVelocity = RoughnessFactor * OrographyFactor * BasicWindVelocity;
        }

        /// <summary>
        /// Sets the value for mean wind velocity.
        /// </summary>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4:2005 Eq. 4.8</c>
        /// </remarks>
        public void CalculatePeakVelocityPressure()
        {
            PeakVelocityPressure = (1 + 7 * TurbulenceIntensity) * 1 / 2 * AirDensity * Math.Pow(MeanWindVelocity, 2);
        }

        /// <summary>
        /// Sets the value for air density.
        /// </summary>
        /// <remarks>
        /// Method base on <c>https://www.gribble.org/cycling/air_density.html</c>
        /// </remarks>
        public void CalculateAirDensity()
        {
            throw new NotImplementedException();
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
        public double GetDirectionalFactor(int currentWindZone)
        {
            if (WindDirection == WindDirectionEnum.NONE)
                return 1;

            if (currentWindZone == 4)
                return (DirectionalFactors[1, (int)WindDirection] + DirectionalFactors[2, (int)WindDirection]) / 2;

            return DirectionalFactors[currentWindZone - 1, (int)WindDirection - 1];
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
        public double CalculateBasicVelocityPressureForThirdZone()
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
        public double CalculateBasicVelocityPressureForSecondZone()
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
        public double CalculateBasicVelocityPressureForFirstZone()
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
        public double CalculateBasicWindVelocityForThirdZone()
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
        public double CalculateBasicWindVelocityForSecondZone()
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
        public double CalculateBasicWindVelocityForFirstZone()
        {
            if (HeightAboveSeaLevel <= 300)
                return 22;

            return 22 * (1 + 0.0006 * (HeightAboveSeaLevel - 300));
        }

        #endregion

        /// <summary>
        /// Culture national anexes
        /// </summary>
        public enum CultureNationalAnexEnum
        {
            /// <summary>Used when none of culture national anexes is selected.</summary>
            NONE,
            /// <summary>Polish culture national anex.</summary>
            PL_EC,
        }

        /// <summary>
        /// Wind zones.
        /// </summary>
        /// <remarks>Base on <c>PN-EN 1991-1-4:2008 Fig. NA.1</c>.</remarks>
        public enum WindLoadEnum
        {
            /// <summary>Used when none of wind zone is selected.</summary>
            NONE,
            /// <summary>First wind zone.</summary>
            FIRST_WIND_ZONE,
            /// <summary>Second wind zone.</summary>
            SECOND_WIND_ZONE,
            /// <summary>Third wind zone.</summary>
            THIRD_WIND_ZONE,
            /// <summary>Terrain between first and seoncd wind zone (10km strip on both sides of the border).</summary>
            /// <remarks>This base on <c>PN-EN 1991-1-4:2008 NA.5</c>.</remarks>
            BETWEEN_FIRST_AND_SECOND_WIND_ZONE,
        };

        /// <summary>
        /// Wind directions.
        /// </summary>
        public enum WindDirectionEnum
        {
            /// <summary>When none of wind directions is selected.</summary>
            NONE,
            /// <summary>0 degrees - North direction (sector no. 1).</summary>
            DEGREE_0,
            /// <summary>30 degrees (sector no. 2).</summary>
            DEGREE_30,
            /// <summary>60 degrees (sector no. 3).</summary>
            DEGREE_60,
            /// <summary>90 degrees (sector no. 4).</summary>
            DEGREE_90,
            /// <summary>120 degrees (sector no. 5).</summary>
            DEGREE_120,
            /// <summary>150 degrees (sector no. 6).</summary>
            DEGREE_150,
            /// <summary>180 degrees (sector no. 7).</summary>
            DEGREE_180,
            /// <summary>210 degrees (sector no. 8).</summary>
            DEGREE_210,
            /// <summary>240 degrees (sector no. 9).</summary>
            DEGREE_240,
            /// <summary>270 degrees (sector no. 10).</summary>
            DEGREE_270,
            /// <summary>300 degrees (sector no. 11).</summary>
            DEGREE_300,
            /// <summary>330 degrees (sector no. 12).</summary>
            DEGREE_330,

        }

        /// <summary>
        /// Terrain categories.
        /// </summary>
        public enum TerrainCategoryEnum
        {
            /// <summary>When none of terrain category is selected.</summary>
            NONE,
            /// <summary>Zero terrain category.</summary>
            /// <remarks>Sea, coastal area exposed to the open sea.</remarks>
            TERRAIN_CATEGORY_0,
            /// <summary>First terrain category.</summary>
            /// <remarks>Lakes or area with negliglible vegetation and without obstacles.</remarks>
            TERRAIN_CATEGORY_1,
            /// <summary>Second terrain category.</summary>
            /// <remarks>Area with low vegetation such as grass and isolated obstacles (trees, buildings) with separations of at least 20 obstacle heights.</remarks>
            TERRAIN_CATEGORY_2,
            /// <summary>Third terrain category.</summary>
            /// <remarks>Area with regular cover of vegetation or buildings or with isolated obstacles with separations of maximum 20 obstacle heights (such as villages, suburban terrain, permanent forest).</remarks>
            TERRAIN_CATEGORY_3,
            /// <summary>Fourth terrain category.</summary>
            /// <remarks>Area in which at least 15% of the surface is covered with buildings and their average height exceeds 15m.</remarks>
            TERRAIN_CATEGORY_4,
        }

    }
}
