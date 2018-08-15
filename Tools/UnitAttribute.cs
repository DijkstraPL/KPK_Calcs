using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    /// <summary>
    /// Class which contain information about unit of the property or field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class UnitAttribute : Attribute
    {
        private string unit;
        /// <value>
        /// Parameter which describes the unit of the property or field.
        /// </value>
        public string Unit => unit;

        /// <summary>
        /// Constructor for unit attribute.
        /// </summary>
        /// <param name="unit">Unit for the field or property.</param>
        public UnitAttribute(string unit)
        {
            this.unit = unit;
        }
    }
}
