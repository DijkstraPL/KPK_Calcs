using Build_IT_CommonTools;
using Build_IT_WindLoads.BuildingData.Interfaces;
using System;
using System.Collections.Generic;

namespace Build_IT_WindLoads.BuildingData
{
    public abstract class Structure : IStructure
    {
        #region Properties

        /// <summary>
        /// d
        /// </summary>
        [Abbreviation("d")]
        [Unit("m")]
        public double Length { get; protected set; }

        /// <summary>
        /// b
        /// </summary>
        [Abbreviation("b")]
        [Unit("m")]
        public double Width { get; protected set; }

        /// <summary>
        /// h
        /// </summary>
        [Abbreviation("h")]
        [Unit("m")]
        public double Height { get; protected set; }

        /// <summary>
        /// e
        /// </summary>
        [Abbreviation("e")]
        [Unit("m")]
        public double EdgeDistance 
            => Math.Min(Width, 2 * Height);
        
        public IDictionary<Field, double> Areas { get;  }

        #endregion // Properties

        #region Constructors
        public Structure(double length, double width, double height)
        {
            if (length < 0 || width < 0 || height < 0)
                throw new ArgumentOutOfRangeException("Wrong building dimensions.");

            Length = length;
            Width = width;
            Height = height;

            Areas = new Dictionary<Field, double>();
        }

        #endregion // Constructors

        #region Public_Methods

        public abstract double GetReferenceHeight();

        #endregion // Public_Methods
    }
}
