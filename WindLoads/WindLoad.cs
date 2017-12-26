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

        /// <value>Air density also known as <c>ρ</c>.</value>
        public double AirDensity { get; set; } = 1.25;

        /// <value>Air density also known as <c>q_p(z)</c>.</value>
        public double PeakVelocityPressure { get; private set; } = 1.25;

        /// <value>Width of the building also known as <c>d</c>.</value>
        public double BuildingWidth { get; set; }

        /// <value>Length of the building also known as <c>b</c>.</value>
        public double BuildingLength { get; set; }

        /// <value>Width of the building face also known as <c>b</c>.</value>
        public double BuildingFaceWidth { get; set; }

        /// <value>Height for horizontal strips also known as <c>h_strip</c>.</value>
        public double HorizontalStrip { get; set; } = 1.0;

        #endregion

        #region Constructors

        public WindLoad(WindLoadEnum zone, float heightAboveSeaLevel, TerrainCategoryEnum terrainCategory,
            double heightAboveGround, double buildingWidth, double buildingLength)
        {
            WindLoadZone = zone;
            HeightAboveSeaLevel = heightAboveSeaLevel;
            TerrainCategory = terrainCategory;
            HeightAboveGround = heightAboveGround;
            BuildingWidth = buildingWidth;
            BuildingLength = buildingLength;
        }

        public WindLoad(WindLoadEnum zone, float heightAboveSeaLevel, TerrainCategoryEnum terrainCategory,
            double heightAboveGround, double buildingWidth, double buildingLength,
            WindDirectionEnum windDirection) :
            this(zone, heightAboveSeaLevel, terrainCategory, heightAboveGround, buildingWidth, buildingLength)
        {
            WindDirection = windDirection;
        }

        #endregion

        public void CalculateWindLoad(double heightForCalculations, bool windAlongTheLength)
        {
            SetVelocityValuesAndDirectionalFactorForCurrentWindZone();
            CalculateBasicWindVelocity();
            SetTheRoughnessLengthAndExtremeHeights((int)TerrainCategory - 1);

            double referenceHeight = SetReferenceHeight(heightForCalculations);

            CalculateRoughnessAndExposureFactor(referenceHeight);
            // CalculateOrographyFactor(); not implemented
            CalculateTurbulenceIntensity(referenceHeight);
            CalculateMeanWindVelocity();
            CalculatePeakVelocityPressure();
        }

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
        private void CalculateRoughnessAndExposureFactor(double referenceHeight)
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
        private void CalculateOrographyFactor()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the value for turbulence intensity.
        /// </summary>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4:2005 Eq. 4.7</c>.
        /// </remarks>
        private void CalculateTurbulenceIntensity(double referenceHeight)
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
        private double SetReferenceHeight(double heightForCalculations)
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
                    int numberOfStrips = (int)(heightForCalculations - BuildingFaceWidth / HorizontalStrip) + 1;

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
        private void CalculateMeanWindVelocity()
        {
            MeanWindVelocity = RoughnessFactor * OrographyFactor * BasicWindVelocity;
        }

        /// <summary>
        /// Sets the value for mean wind velocity.
        /// </summary>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4:2005 Eq. 4.8</c>
        /// </remarks>
        private void CalculatePeakVelocityPressure()
        {
            PeakVelocityPressure = (1 + 7 * TurbulenceIntensity) * 1 / 2 * AirDensity * Math.Pow(MeanWindVelocity, 2);
        }

        /// <summary>
        /// Sets the value for air density.
        /// </summary>
        /// <remarks>
        /// Method base on <c>https://www.gribble.org/cycling/air_density.html</c>
        /// </remarks>
        private void CalculateAirDensity()
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

    public abstract class Building
    {
        #region Properties

        /// <value>Width of the building also known as <c>d</c>.</value>
        public double BuildingWidth { get; set; }

        /// <value>Length of the building also known as <c>b</c>.</value>
        public double BuildingLength { get; set; }

        /// <value>Height of the building also known as <c>h</c>.</value>
        public double BuildingHeight { get; set; }

        /// <value>Areas for walls with names of the zones.</value>
        protected abstract Dictionary<string, double> AreasOfWindZonesForWalls { get; set; }

        /// <value>Areas for roof with names of the zones.</value>
        protected abstract Dictionary<string, double> AreasOfWindZonesForRoof { get; set; }

        /// <value>External pressure coefficient for walls also known as <c>c_pe</c>.</value>
        protected abstract Dictionary<string, double> ExternalPressureCoefficientsForWalls { get; set; }

        /// <value>External pressure coefficient for roof also known as <c>c_pe</c>.</value>
        protected abstract Dictionary<string, double> ExternalPressureCoefficientsForRoof { get; set; }

        /// <value>External pressure coefficient list for walls also known as <c>c_pe,10</c> and <c>c_pe,1</c>.</value>
        public abstract double[][,] TableWithExternalPressureCoefficientsForWalls { get; }

        /// <value>Internal pressure coefficient from an enumerator also known as <c>c_pi</c>.</value>
        public abstract InternalPressureCoefficientEnum InternalPressureCoefficientFromEnum { get; set; }

        /// <value>Internal pressure coefficient also known as <c>c_pi</c>.</value>
        public abstract double InternalPressureCoefficient { get; set; }

        #endregion

        protected abstract void CalculateExternalPressureCoefficientForWalls();

        protected abstract void CalculateExternalPressureCoefficientForRoof();

        /// <summary>
        /// Method use to calculate area of wall zones.
        /// </summary>
        /// <param name="windDirection">Direction of wind according to <c>PN-EN 1991-1-4 Fig. 7.5</c>.</param>
        /// <seealso cref="Building.SetProperWallBuildingDimensions(WindDirectionEnum, out double, out double, out double)"/>
        /// <seealso cref="Building.SetAreasForWallZones(double, double, double, double)"/>
        protected abstract void CalculateAreas(WindDirectionEnum windDirection);

        /// <summary>
        /// Sets proper building dimensions, which are needed in calculations.
        /// </summary>
        /// <param name="windDirection">Direction of wind according to <c>PN-EN 1991-1-4 Fig. 7.5</c>.</param>
        /// <param name="d">Dimension of the building according to <c>PN-EN 1991-1-4 Fig. 7.5</c>.</param>
        /// <param name="b">Dimension of the building according to <c>PN-EN 1991-1-4 Fig. 7.5</c>.</param>
        /// <param name="h">Dimension of the building according to <c>PN-EN 1991-1-4 Fig. 7.5</c>.</param>
        protected abstract void SetProperWallBuildingDimensions(WindDirectionEnum windDirection, out double d, out double b, out double h);

        /// <summary>
        /// Set calculated areas into Dictionary.
        /// </summary>
        /// <param name="wallZoneRange">Dimension of the building according to <c>PN-EN 1991-1-4 Fig. 7.5</c> also known as <c>e</c>.</param>
        /// <param name="d">Dimension of the building according to <c>PN-EN 1991-1-4 Fig. 7.5</c>.</param>
        /// <param name="b">Dimension of the building according to <c>PN-EN 1991-1-4 Fig. 7.5</c>.</param>
        /// <param name="h">Dimension of the building according to <c>PN-EN 1991-1-4 Fig. 7.5</c>.</param>
        protected abstract void SetAreasForWallFields(double wallZoneRange, double d, double b, double h);

        protected abstract double CalculateInterpolationFactorForWalls(double d, double b, double h);

        protected abstract double CalculateExternalPressureCoefficientForValueBetweenMinAndMax
            (double externalPressureCoefficientMin, double externalPressureCoefficientMax, double area);

        public enum InternalPressureCoefficientEnum
        {
            NONE,
            POINT_TWO,
            MINUS_POINT_THREE,
            CALCULATE
        }

        /// <summary>
        /// Wind directions.
        /// </summary>
        public enum WindDirectionEnum
        {
            /// <summary>When none of wind directions is selected.</summary>
            NONE,
            /// <summary>Wind is blowing upwards.</summary>
            UP,
            /// <summary>Wind is blowing downwards.</summary>
            DOWN,
            /// <summary>The wind blows to the left.</summary>
            LEFT,
            /// <summary>The wind blows to the right.</summary>
            RIGHT
        }
    }

    public sealed class BuildingWithFlatRoof : Building
    {
        #region Properties

        public WindDirectionEnum WindDirection { get; set; } = WindDirectionEnum.NONE;

        public RoofTypeEnum RoofType { get; set; } = RoofTypeEnum.NONE;

        public FieldIValuesEnum IFieldValue { get; set; } = FieldIValuesEnum.NONE;

        protected override Dictionary<string, double> AreasOfWindZonesForWalls { get; set; }

        protected override Dictionary<string, double> AreasOfWindZonesForRoof { get; set; }

        protected override Dictionary<string, double> ExternalPressureCoefficientsForWalls { get; set; }

        protected override Dictionary<string, double> ExternalPressureCoefficientsForRoof { get; set; }

        public double InterpolationFactor { get; private set; }

        public List<string> ListOfFieldsForWalls { get; } = new List<string> { "Field A", "Field B", "Field C", "Field D", "Field E" };

        public List<string> ListOfFieldsForRoof { get; } = new List<string> { "Field F", "Field G", "Field H", "Field I" };

        public override double[][,] TableWithExternalPressureCoefficientsForWalls { get; } = new double[2][,]
        {
           new double[3,5] // c_pe,10
           {
               { -1.2, -0.8, -0.5, 0.8, -0.7 }, // h/d = 5
               { -1.2, -0.8, -0.5, 0.8, -0.5 }, // h/d = 1
               { -1.2, -0.8, -0.5, 0.7, -0.3 }, // h/d = 0.25
           },
           new double[3,5] // c_pe,1
           {
               { -1.4, -1.1, -0.5, 1.0, -0.7 }, // h/d = 5
               { -1.4, -1.1, -0.5, 1.0, -0.5 }, // h/d = 1
               { -1.4, -1.1, -0.5, 1.0, -0.3 }, // h/d = 0.25
           }
        };

        public double AtticHeight { get; set; } = 0;

        public double RoundingRadius { get; set; } = 0;

        public double Angle { get; set; } = 0;

        public double[][,] TableWithExternalPressureCoefficientsForSharpEavesRoof { get; } = new double[2][,]
        {
            new double[2, 4] // c_pe,10
            {
                {-1.8, -1.2, -0.7, 0.2 }, // +0.2 for F field
                {-1.8, -1.2, -0.7, -0.2 } // -0.2 for F field
            },
            new double[2, 4] // c_pe,1
            {
                {-2.5, -2, -1.2, 0.2 }, // +0.2 for F field
                {-2.5, -2, -1.2, -0.2 } // -0.2 for F field
            }
        };

        public double[][,] TableWithExternalPressureCoefficientsForRoofWithParapetes { get; } = new double[2][,]
        {
            new double[6, 4] // c_pe,10
            {
                {-1.6, -1.1, -0.7, 0.2 }, // h_p/h = 0.025 and +0.2 for F field
                {-1.6, -1.1, -0.7, -0.2 }, // h_p/h = 0.025 and -0.2 for F field
                {-1.4, -0.9, -0.7, 0.2 }, // h_p/h = 0.05 and +0.2 for F field
                {-1.4, -0.9, -0.7, -0.2 }, // h_p/h = 0.05 and -0.2 for F field
                {-1.2, -0.8, -0.7, 0.2 }, // h_p/h = 0.10 and +0.2 for F field
                {-1.2, -0.8, -0.7, -0.2 } // h_p/h = 0.10 and -0.2 for F field
            },
            new double[6, 4] // c_pe,1
            {
                {-2.2, -1.8, -1.2, 0.2 }, // h_p/h = 0.025 and +0.2 for F field
                {-2.2, -1.8, -1.2, -0.2 }, // h_p/h = 0.025 and -0.2 for F field
                {-2.0, -1.6, -1.2, 0.2}, // h_p/h = 0.05 and +0.2 for F field
                {-2.0, -1.6, -1.2, -0.2}, // h_p/h = 0.05 and -0.2 for F field
                {-1.8, -1.4, -1.2, 0.2}, // h_p/h = 0.10 and +0.2 for F field
                {-1.8, -1.4, -1.2, -0.2} // h_p/h = 0.10 and -0.2 for F field
            }
        };

        public double[][,] TableWithExternalPressureCoefficientsForCurvedEavesRoof { get; } = new double[2][,]
        {
            new double[6, 4] // c_pe,10
            {
                {-1.0, -1.2, -0.4, 0.2}, // r/h = 0.05 and +0.2 for F field
                {-1.0, -1.2, -0.4, -0.2}, // r/h = 0.05 and -0.2 for F field
                {-0.7, -0.8, -0.3, 0.2}, // r/h = 0.10 and +0.2 for F field
                {-0.7, -0.8, -0.3, -0.2}, // r/h = 0.10 and -0.2 for F field
                {-0.5, -0.5, -0.3, 0.2}, // r/h = 0.20 and +0.2 for F field
                {-0.5, -0.5, -0.3, -0.2} // r/h = 0.20 and -0.2 for F field
            },
            new double[6, 4] // c_pe,1
            {
                {-1.5, -1.8, -0.4, 0.2}, // r/h = 0.05 and +0.2 for F field
                {-1.5, -1.8, -0.4, -0.2}, // r/h = 0.05 and -0.2 for F field
                {-1.2, -1.4, -0.3, 0.2}, // r/h = 0.10 and +0.2 for F field
                {-1.2, -1.4, -0.3, -0.2}, // r/h = 0.10 and -0.2 for F field
                {-0.8, -0.8, -0.3, 0.2}, // r/h = 0.20 and +0.2 for F field
                {-0.8, -0.8, -0.3, -0.2} // r/h = 0.20 and -0.2 for F field
            }
        };

        public double[][,] TableWithExternalPressureCoefficientsForMansardEavesRoof { get; } = new double[2][,]
{
            new double[6, 4] // c_pe,10
            {
                {-1.0, -1.0, -0.3, 0.2}, // a = 30 and +0.2 for F field
                {-1.0, -1.0, -0.3, -0.2}, // a = 30 and -0.2 for F field
                {-1.2, -1.3, -0.4, 0.2}, // a = 45 and +0.2 for F field
                {-1.2, -1.3, -0.4, -0.2}, // a = 45 and -0.2 for F field
                {-1.3, -1.3, -0.5, 0.2}, // a = 60 and +0.2 for F field
                {-1.3, -1.3, -0.5, -0.2}  // a = 60 and -0.2 for F field
            },
            new double[6, 4] // c_pe,1
            {
                {-1.5, -1.5, -0.3, 0.2}, // a = 30 and +0.2 for F field
                {-1.5, -1.5, -0.3, -0.2}, // a = 30 and -0.2 for F field
                {-1.8, -1.9, -0.4, 0.2}, // a = 45 and +0.2 for F field
                {-1.8, -1.9, -0.4, -0.2}, // a = 45 and -0.2 for F field
                {-1.9, -1.9, -0.5, 0.2}, // a = 60 and +0.2 for F field
                {-1.9, -1.9, -0.5, -0.2}  // a = 60 and -0.2 for F field
            }
};

        public override InternalPressureCoefficientEnum InternalPressureCoefficientFromEnum { get; set; }

        public override double InternalPressureCoefficient { get; set; }

        #endregion

        #region Constructors

        public BuildingWithFlatRoof(InternalPressureCoefficientEnum internalPressureCoefficient)
        {
            InternalPressureCoefficientFromEnum = internalPressureCoefficient;

            SetInternalPressureCoefficient();

            AreasOfWindZonesForWalls = new Dictionary<string, double>();
            ExternalPressureCoefficientsForWalls = new Dictionary<string, double>();
            foreach (string field in ListOfFieldsForWalls)
            {
                AreasOfWindZonesForWalls.Add(field, 0);
                ExternalPressureCoefficientsForWalls.Add(field, 0);
            }

            AreasOfWindZonesForRoof = new Dictionary<string, double>();
            ExternalPressureCoefficientsForRoof = new Dictionary<string, double>();
            foreach (string field in ListOfFieldsForRoof)
            {
                AreasOfWindZonesForRoof.Add(field, 0);
                ExternalPressureCoefficientsForRoof.Add(field, 0);
            }
        }

        #endregion

        private void SetInternalPressureCoefficient()
        {
            switch (InternalPressureCoefficientFromEnum)
            {
                case InternalPressureCoefficientEnum.POINT_TWO:
                    InternalPressureCoefficient = 0.2;
                    break;
                case InternalPressureCoefficientEnum.MINUS_POINT_THREE:
                    InternalPressureCoefficient = -0.3;
                    break;
                case InternalPressureCoefficientEnum.CALCULATE:
                    throw new NotImplementedException();
                case InternalPressureCoefficientEnum.NONE:
                    throw new ArgumentException("There is no specified which internal pressure coefficient should be taken into evaluations.");
            }
        }

        protected override void CalculateExternalPressureCoefficientForRoof()
        {
            switch (RoofType)
            {
                case RoofTypeEnum.SHARP_EAVES:
                    CalculateExternalPressureCoefficientForSharpEavesRoof();
                    break;
                case RoofTypeEnum.WITH_PARAPETS:
                    CalculateExternalPressureCoefficientForRoofWithParapets();
                    break;
                case RoofTypeEnum.CURVED_EAVES:
                    CalculateExternalPressureCoefficientForCurvedEavesRoof();
                    break;
                case RoofTypeEnum.MANSARD_EAVES:
                    CalculateExternalPressureCoefficientForMansardEavesRoof();
                    break;
                case RoofTypeEnum.NONE:
                    throw new ArgumentException("Roof type should be specified.");
                default:
                    break;
            }
        }

        private void CalculateExternalPressureCoefficientForMansardEavesRoof()
        {
            int i = 0;

            double externalPressureCoefficientsFoRoofMin;
            double externalPressureCoefficientsForRoofMax;

            int index = (int)IFieldValue - 1;

            double mansardInterpolationFactor = RoundingRadius / BuildingHeight;

            if (mansardInterpolationFactor <30 )
                throw new ArgumentOutOfRangeException("Current factor of height to one of the building dimensions is not supported, by the current algorithms.");

            foreach (string field in ListOfFieldsForRoof)
            {
                if (mansardInterpolationFactor <= 45)
                {
                    externalPressureCoefficientsFoRoofMin = LinearInterpolation
                        (TableWithExternalPressureCoefficientsForMansardEavesRoof[1][1 + index, i], TableWithExternalPressureCoefficientsForMansardEavesRoof[1][0 + index, i], 0.05, 0.025);

                    externalPressureCoefficientsForRoofMax = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForMansardEavesRoof[0][1 + index, i], TableWithExternalPressureCoefficientsForMansardEavesRoof[0][0 + index, i], 0.05, 0.025);
                }
                else if (mansardInterpolationFactor <= 60)
                {
                    externalPressureCoefficientsFoRoofMin = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForMansardEavesRoof[1][2 + index, i], TableWithExternalPressureCoefficientsForMansardEavesRoof[1][1 + index, i], 0.10, 0.05);

                    externalPressureCoefficientsForRoofMax = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForMansardEavesRoof[0][2 + index, i], TableWithExternalPressureCoefficientsForMansardEavesRoof[0][1 + index, i], 0.10, 0.05);
                }
                else
                {
                    externalPressureCoefficientsFoRoofMin = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForSharpEavesRoof[1][0 + index, i], TableWithExternalPressureCoefficientsForMansardEavesRoof[1][2 + index, i], 0.10, 0.05);

                    externalPressureCoefficientsForRoofMax = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForSharpEavesRoof[0][0+ index, i], TableWithExternalPressureCoefficientsForMansardEavesRoof[0][2 + index, i], 0.10, 0.05);
                }

                if (AreasOfWindZonesForRoof[field] >= 10)
                    ExternalPressureCoefficientsForRoof[field] = externalPressureCoefficientsForRoofMax;
                else if (AreasOfWindZonesForRoof[field] <= 1)
                    ExternalPressureCoefficientsForRoof[field] = externalPressureCoefficientsFoRoofMin;
                else
                    ExternalPressureCoefficientsForRoof[field] =
                    CalculateExternalPressureCoefficientForValueBetweenMinAndMax
                       (externalPressureCoefficientsFoRoofMin, externalPressureCoefficientsForRoofMax, AreasOfWindZonesForRoof[field]);

                i++;
            }
        }

        private void CalculateExternalPressureCoefficientForCurvedEavesRoof()
        {
            int i = 0;

            double externalPressureCoefficientsFoRoofMin;
            double externalPressureCoefficientsForRoofMax;

            int index = (int)IFieldValue - 1;

            double curvedInterpolationFactor = RoundingRadius / BuildingHeight;

            if (curvedInterpolationFactor > 0.2 || curvedInterpolationFactor < 0.05)
                throw new ArgumentOutOfRangeException("Current factor of height to one of the building dimensions is not supported, by the current algorithms.");

            foreach (string field in ListOfFieldsForRoof)
            {
                if (curvedInterpolationFactor <= 0.10)
                {
                    externalPressureCoefficientsFoRoofMin = LinearInterpolation
                        (TableWithExternalPressureCoefficientsForCurvedEavesRoof[1][1 + index, i], TableWithExternalPressureCoefficientsForCurvedEavesRoof[1][0 + index, i], 0.10, 0.05);

                    externalPressureCoefficientsForRoofMax = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForCurvedEavesRoof[0][1 + index, i], TableWithExternalPressureCoefficientsForCurvedEavesRoof[0][0 + index, i], 0.10, 0.05);
                }
                else
                {
                    externalPressureCoefficientsFoRoofMin = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForCurvedEavesRoof[1][2 + index, i], TableWithExternalPressureCoefficientsForCurvedEavesRoof[1][1 + index, i], 0.20, 0.10);

                    externalPressureCoefficientsForRoofMax = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForCurvedEavesRoof[0][2 + index, i], TableWithExternalPressureCoefficientsForCurvedEavesRoof[0][1 + index, i], 0.20, 0.10);
                }

                if (AreasOfWindZonesForRoof[field] >= 10)
                    ExternalPressureCoefficientsForRoof[field] = externalPressureCoefficientsForRoofMax;
                else if (AreasOfWindZonesForRoof[field] <= 1)
                    ExternalPressureCoefficientsForRoof[field] = externalPressureCoefficientsFoRoofMin;
                else
                    ExternalPressureCoefficientsForRoof[field] =
                    CalculateExternalPressureCoefficientForValueBetweenMinAndMax
                       (externalPressureCoefficientsFoRoofMin, externalPressureCoefficientsForRoofMax, AreasOfWindZonesForRoof[field]);

                i++;
            }
        }

        private void CalculateExternalPressureCoefficientForRoofWithParapets()
        {
            int i = 0;

            double externalPressureCoefficientsFoRoofMin;
            double externalPressureCoefficientsForRoofMax;

            int index = (int)IFieldValue - 1;

            double atticInterpolationFactor = AtticHeight / (BuildingHeight - AtticHeight);

            if (atticInterpolationFactor > 0.1 || atticInterpolationFactor < 0.025)
                throw new ArgumentOutOfRangeException("Current factor of height to one of the building dimensions is not supported, by the current algorithms.");

            foreach (string field in ListOfFieldsForRoof)
            {
                if (atticInterpolationFactor <= 0.05)
                {
                    externalPressureCoefficientsFoRoofMin = LinearInterpolation
                        (TableWithExternalPressureCoefficientsForRoofWithParapetes[1][1+ index, i], TableWithExternalPressureCoefficientsForRoofWithParapetes[1][0+ index, i], 0.05, 0.025);

                    externalPressureCoefficientsForRoofMax = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForRoofWithParapetes[0][1+ index, i], TableWithExternalPressureCoefficientsForRoofWithParapetes[0][0+ index, i], 0.05, 0.025);
                }
                else
                {
                    externalPressureCoefficientsFoRoofMin = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForRoofWithParapetes[1][2+ index, i], TableWithExternalPressureCoefficientsForRoofWithParapetes[1][1+ index, i], 0.10, 0.05);

                    externalPressureCoefficientsForRoofMax = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForRoofWithParapetes[0][2+ index, i], TableWithExternalPressureCoefficientsForRoofWithParapetes[0][1+ index, i], 0.10, 0.05);
                }

                if (AreasOfWindZonesForRoof[field] >= 10)
                    ExternalPressureCoefficientsForRoof[field] = externalPressureCoefficientsForRoofMax;
                else if (AreasOfWindZonesForRoof[field] <= 1)
                    ExternalPressureCoefficientsForRoof[field] = externalPressureCoefficientsFoRoofMin;
                else
                    ExternalPressureCoefficientsForRoof[field] =
                    CalculateExternalPressureCoefficientForValueBetweenMinAndMax
                       (externalPressureCoefficientsFoRoofMin, externalPressureCoefficientsForRoofMax, AreasOfWindZonesForRoof[field]);

                i++;
            }
        }

        private void CalculateExternalPressureCoefficientForSharpEavesRoof()
        {
            int i = 0;

            int index = (int)IFieldValue - 1;

            foreach (string field in ListOfFieldsForRoof)
            {
                if (AreasOfWindZonesForRoof[field] >= 10)
                    ExternalPressureCoefficientsForRoof[field] = TableWithExternalPressureCoefficientsForSharpEavesRoof[0][index, i];
                else if (AreasOfWindZonesForRoof[field] <= 1)
                    ExternalPressureCoefficientsForRoof[field] = TableWithExternalPressureCoefficientsForSharpEavesRoof[1][index, i];
                else
                    ExternalPressureCoefficientsForRoof[field] =
                    CalculateExternalPressureCoefficientForValueBetweenMinAndMax
                       (TableWithExternalPressureCoefficientsForSharpEavesRoof[1][index, i], TableWithExternalPressureCoefficientsForSharpEavesRoof[0][index, i], AreasOfWindZonesForRoof[field]);

                i++;
            }
        }

        protected override void CalculateExternalPressureCoefficientForWalls()
        {
            int i = 0;

            double externalPressureCoefficientsForWallsMin;
            double externalPressureCoefficientsForWallsMax;

            foreach (string field in ListOfFieldsForWalls)
            {
                if (InterpolationFactor > 1)
                {
                    externalPressureCoefficientsForWallsMin = LinearInterpolation
                        (TableWithExternalPressureCoefficientsForWalls[1][1, i], TableWithExternalPressureCoefficientsForWalls[1][0, i], 1, 5);

                    externalPressureCoefficientsForWallsMax = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForWalls[0][1, i], TableWithExternalPressureCoefficientsForWalls[0][0, i], 1, 5);
                }
                else
                {
                    externalPressureCoefficientsForWallsMin = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForWalls[1][2, i], TableWithExternalPressureCoefficientsForWalls[1][1, i], 0.25, 1);

                    externalPressureCoefficientsForWallsMax = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForWalls[0][2, i], TableWithExternalPressureCoefficientsForWalls[0][1, i], 0.25, 1);
                }

                if (AreasOfWindZonesForWalls[field] >= 10)
                    ExternalPressureCoefficientsForWalls[field] = externalPressureCoefficientsForWallsMax;
                else if (AreasOfWindZonesForWalls[field] <= 1)
                    ExternalPressureCoefficientsForWalls[field] = externalPressureCoefficientsForWallsMin;
                else
                    ExternalPressureCoefficientsForWalls[field] =
                        CalculateExternalPressureCoefficientForValueBetweenMinAndMax
                           (externalPressureCoefficientsForWallsMin, externalPressureCoefficientsForWallsMax, AreasOfWindZonesForWalls[field]);

                i++;
            }
        }

        private double LinearInterpolation(double minValue, double maxValue, double minInterpolation, double maxInterpolation)
        => minValue + (maxValue - minValue) / (maxInterpolation - minInterpolation) * (InterpolationFactor - minInterpolation);

        protected override double CalculateInterpolationFactorForWalls(double d, double b, double h)
        {
            double interpolationFactor = h / d;

            if (interpolationFactor > 5)
                throw new ArgumentOutOfRangeException("Current factor of height to one of the building dimensions is not sup[ported, by the current algorithms.");

            if (interpolationFactor <= 0.25)
                interpolationFactor = 0.25;

            return interpolationFactor;
        }

        protected override double CalculateExternalPressureCoefficientForValueBetweenMinAndMax
            (double externalPressureCoefficientMin, double externalPressureCoefficientMax, double area)
            => externalPressureCoefficientMin - (externalPressureCoefficientMin - externalPressureCoefficientMax) * Math.Log10(area);

        protected override void CalculateAreas(WindDirectionEnum windDirection)
        {
            double d;
            double b;
            double h;

            SetProperWallBuildingDimensions(windDirection, out d, out b, out h);

            double wallZoneRange = Math.Min(b, 2 * h);

            SetAreasForWallFields(wallZoneRange, d, b, h);

            SetAreasForRoofFields(wallZoneRange, d, b, h);

            InterpolationFactor = CalculateInterpolationFactorForWalls(d, b, h);
        }

        private void SetAreasForRoofFields(double wallZoneRange, double d, double b, double h)
        {
            AreasOfWindZonesForRoof["Field F"] = wallZoneRange / 4 * wallZoneRange / 10;
            AreasOfWindZonesForRoof["Field G"] = (b - 2 * wallZoneRange / 4) * wallZoneRange / 10;
            AreasOfWindZonesForRoof["Field H"] = (wallZoneRange / 2 - wallZoneRange / 10) * b;
            AreasOfWindZonesForRoof["Field I"] = (d - wallZoneRange / 2) * b;
        }

        protected override void SetAreasForWallFields(double wallZoneRange, double d, double b, double h)
        {
            if (wallZoneRange < d)
            {
                AreasOfWindZonesForWalls["Field A"] = wallZoneRange / 5 * h;
                AreasOfWindZonesForWalls["Field B"] = wallZoneRange * 4 / 5 * h;
                AreasOfWindZonesForWalls["Field C"] = (d - wallZoneRange) * h;
                AreasOfWindZonesForWalls["Field D"] = b * h;
                AreasOfWindZonesForWalls["Field E"] = b * h;
            }
            else if (wallZoneRange >= d && wallZoneRange < 5 * d)
            {
                AreasOfWindZonesForWalls["Field A"] = wallZoneRange / 5 * h;
                AreasOfWindZonesForWalls["Field B"] = (d - wallZoneRange / 5) * h;
                AreasOfWindZonesForWalls["Field C"] = 0;
                AreasOfWindZonesForWalls["Field D"] = b * h;
                AreasOfWindZonesForWalls["Field E"] = b * h;
            }
            else
            {
                AreasOfWindZonesForWalls["Field A"] = d * h;
                AreasOfWindZonesForWalls["Field B"] = 0;
                AreasOfWindZonesForWalls["Field C"] = 0;
                AreasOfWindZonesForWalls["Field D"] = b * h;
                AreasOfWindZonesForWalls["Field E"] = b * h;
            }
        }

        protected override void SetProperWallBuildingDimensions(WindDirectionEnum windDirection, out double d, out double b, out double h)
        {
            switch (windDirection)
            {
                case WindDirectionEnum.RIGHT:
                case WindDirectionEnum.LEFT:
                    d = BuildingWidth;
                    b = BuildingLength;
                    break;
                case WindDirectionEnum.UP:
                case WindDirectionEnum.DOWN:
                    d = BuildingLength;
                    b = BuildingWidth;
                    break;
                case WindDirectionEnum.NONE:
                default:
                    throw new ArgumentException("There is no wind direction selected.");
            }

            h = BuildingHeight;
        }


        public enum RoofTypeEnum
        {
            NONE,
            SHARP_EAVES,
            WITH_PARAPETS,
            CURVED_EAVES,
            MANSARD_EAVES,
        }


        public enum FieldIValuesEnum
        {
            NONE,
            POINT_TWO,
            MINUS_POINT_TWO
        }
    }

}
