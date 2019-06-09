using System;

namespace Build_IT_CommonTools
{
    /// <summary>
    /// Class which contain information about unit of the property or field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class UnitAttribute : Attribute
    {
        #region Fields

        private readonly string _unit;

        #endregion // Fields

        #region Properties
        
        /// <value>
        /// Parameter which describes the unit of the property or field.
        /// </value>
        public string Unit => _unit;

        #endregion // Properties

        #region Constructors
        
        /// <summary>
        /// Constructor for unit attribute.
        /// </summary>
        /// <param name="unit">Unit for the field or property.</param>
        public UnitAttribute(string unit)
        {
            _unit = unit;
        }

        #endregion // Constructors
    }
}
