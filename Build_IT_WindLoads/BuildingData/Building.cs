using Build_IT_CommonTools;
using Build_IT_WindLoads.BuildingData.Interfaces;
using System;

namespace Build_IT_WindLoads.BuildingData
{
    public class Building : IBuilding
    {
        #region Properties

        [Abbreviation("d")]
        [Unit("m")]
        public double Length { get; }
        [Abbreviation("b")]
        [Unit("m")]
        public double Width { get; }
        [Abbreviation("h")]
        [Unit("m")]
        public double Height { get; }

        [Abbreviation("e")]
        [Unit("m")]
        public double EdgeDistance 
            => Math.Min(Width, 2 * Height);
        
        #endregion // Properties
        
        #region Constructors

        public Building(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        #endregion // Constructors
    }
}
