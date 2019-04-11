using System.Globalization;

namespace Build_IT_CommonTools
{
    public static class ParseExtended
    {
        #region Public_Methods

        public static double GetDouble(this string value)
        {
            double result;

            // Try parsing in the current culture
            if (!double.TryParse(value, NumberStyles.Any,
                CultureInfo.CurrentCulture, out result) &&
                // Then try in US english
                !double.TryParse(value, NumberStyles.Any,
                CultureInfo.GetCultureInfo("en-US"), out result) &&
                // Then in neutral language
                !double.TryParse(value, NumberStyles.Any,
                CultureInfo.InvariantCulture, out result))
            {
                result = default(double);
            }
            return result;
        }

        #endregion // Public_Methods
    }
}
