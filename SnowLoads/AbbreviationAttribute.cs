using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads
{
    /// <summary>
    /// Class which contain information about abbreviation of the property or field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class AbbreviationAttribute : Attribute
    {
        private string abbreviation;
        /// <summary>
        /// Parameter which describes the abbreviation of the property or field.
        /// </summary>
        public virtual string Abbreviation
        {
            get { return abbreviation; }
        }

        /// <summary>
        /// Constructor for abbreviation attribute.
        /// </summary>
        /// <param name="abbreviation">Abbreviation for the field or property.</param>
        public AbbreviationAttribute(string abbreviation)
        {
            this.abbreviation = abbreviation;
        }
    }
}
