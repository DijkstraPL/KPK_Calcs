using System;
using System.Collections.Generic;

namespace WindLoads
{
    public abstract class Building
    {
        #region Properties

        /// <summary>Width of the building also known as <c>d</c>.</summary>
        public double BuildingWidth { get; set; }

        /// <summary>Length of the building also known as <c>b</c>.</summary>
        public double BuildingLength { get; set; }

        /// <summary>Height of the building also known as <c>h</c>.</summary>
        public double BuildingHeight { get; set; }

        #endregion

        #region Abstract properties

        /// <summary>Areas for walls with names of the zones.</summary>
        public abstract Dictionary<string, double> AreasOfWindZonesForWalls { get; set; }

        /// <summary>Areas for roof with names of the zones.</summary>
        public abstract Dictionary<string, double> AreasOfWindZonesForRoof { get; set; }

        /// <summary>External pressure coefficient for walls also known as <c>c_pe</c>.</summary>
        public abstract Dictionary<string, double> ExternalPressureCoefficientsForWalls { get; set; }

        /// <summary>External pressure coefficient for roof also known as <c>c_pe</c>.</summary>
        public abstract Dictionary<string, double> ExternalPressureCoefficientsForRoof { get; set; }

        /// <summary>External pressure coefficient list for walls also known as <c>c_pe,10</c> and <c>c_pe,1</c>.</summary>
        public abstract double[][,] TableWithExternalPressureCoefficientsForWalls { get; }

        /// <summary>Internal pressure coefficient from an enumerator also known as <c>c_pi</c>.</summary>
        public abstract InternalPressureCoefficientEnum InternalPressureCoefficientFromEnum { get; set; }

        /// <summary>Internal pressure coefficient also known as <c>c_pi</c>.</summary>
        public abstract double InternalPressureCoefficient { get; set; }

        #endregion


        #region Abstract methods

        /// <summary>
        /// Calculate external pressure coefficient for walls.
        /// </summary>
        /// <remarks>
        /// <para>Method should base on <c>PN-EN 1991-1-4:2005 Tab. 7.1</c>, <c>PN-EN 1991-1-4:2005 Fig. 7.5</c></para>
        /// <para>and on <c>PN-EN 1991-1-4:2005 7.2.1 NOTE2</c>.</para>
        /// </remarks>
        protected abstract void CalculateExternalPressureCoefficientForWalls();

        /// <summary>
        /// Calculate external pressure coefficient for roof.
        /// </summary>
        /// <remarks>
        /// <para>Method should base on <c>PN-EN 1991-1-4:2005 Tab. 7.2 / 7.3a / 7.3b / 7.4a / 7.4b / 7.5</c></para>
        /// <para>depending on case and on <c>PN-EN 1991-1-4:2005 7.2.1 NOTE2</c>.</para>
        /// </remarks>
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

        /// <summary>
        /// Set calculated areas into Dictionary.
        /// </summary>
        /// <param name="wallZoneRange">Dimension of the building according to <c>PN-EN 1991-1-4 Fig. 7.5</c> also known as <c>e</c>.</param>
        /// <param name="d">Dimension of the building according to <c>PN-EN 1991-1-4 Fig. 7.5</c>.</param>
        /// <param name="b">Dimension of the building according to <c>PN-EN 1991-1-4 Fig. 7.5</c>.</param>
        /// <param name="h">Dimension of the building according to <c>PN-EN 1991-1-4 Fig. 7.5</c>.</param>
        protected abstract void SetAreasForRoofFields(double wallZoneRange, double d, double b, double h);

        #endregion

        #region Calculation methods

        /// <summary>
        /// Method which calculate value of external pressure coefficient for areas which are less than 10.
        /// </summary>
        /// <remarks>
        /// Method base on <c>PN-EN 1991-1-4 Fig.7.2</c>.
        /// </remarks>
        /// <param name="externalPressureCoefficientMin">Value of external pressure coefficient for one square meter area.</param>
        /// <param name="externalPressureCoefficientMax">Value of external pressure coefficient for ten square meter area.</param>
        /// <param name="area">Area of current field.</param>
        /// <returns>Proper value of external pressure coefficient</returns>
        protected double CalculateExternalPressureCoefficientForValueBetweenMinAndMax
            (double externalPressureCoefficientMin, double externalPressureCoefficientMax, double area)
            => externalPressureCoefficientMin - (externalPressureCoefficientMin - externalPressureCoefficientMax) * Math.Log10(area);

        #endregion

        /// <summary>
        /// Internal pressure coefficient.
        /// </summary>
        /// <remarks>
        /// Enumerator base on <c>PN-EN 1991-1-4 7.2.9.(6) NOTE2</c>.
        /// </remarks>
        public enum InternalPressureCoefficientEnum
        {
            /// <summary>None of internal pressure coefficients is selected.</summary>
            NONE,
            /// <summary>Internal pressure coefficient is equal to 0.2.</summary>
            POINT_TWO,
            /// <summary>Internal pressure coefficient is equal to -0.3.</summary>
            MINUS_POINT_THREE,
            /// <summary>Internal pressure coefficient should be evaluated.</summary>
            CALCULATE
        }

        /// <summary>
        /// Wind directions.
        /// </summary>
        public enum WindDirectionEnum
        {
            /// <summary>None of wind directions is selected.</summary>
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
}
