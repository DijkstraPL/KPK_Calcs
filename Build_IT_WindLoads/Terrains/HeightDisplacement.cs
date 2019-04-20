using Build_IT_CommonTools;
using Build_IT_WindLoads.BuildingData.Interfaces;
using Build_IT_WindLoads.Factors.Interfaces;
using Build_IT_WindLoads.Terrains;
using Build_IT_WindLoads.Terrains.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_WindLoads.Terrains
{
    public class HeightDisplacement : IFactor
    {
        #region Fields

        private readonly ITerrain _terrain;
        private readonly IStructure _building;

        #endregion // Fields

        #region Properties

        [Abbreviation("x")]
        [Unit("m")]
        public double HorizontalDistanceToObstruction { get; }

        [Abbreviation("h_ave")]
        [Unit("m")]
        public double ObstructionsHeight { get; } = 15;

        #endregion // Properties

        #region Constructors

        public HeightDisplacement(ITerrain terrain,
            IStructure building,
            double horizontalDistanceToObstruction,
            double obstructionHeight = 15)
        {
            _terrain = terrain;
            _building = building;
            HorizontalDistanceToObstruction = horizontalDistanceToObstruction;
            ObstructionsHeight = obstructionHeight;
        }

        #endregion // Constructors

        #region Public_Methods

        public double GetFactor()
        {
            if (HorizontalDistanceToObstruction <= 2 * ObstructionsHeight)
                return Math.Min(0.8 * ObstructionsHeight, 0.6 * _building.Height);
            else if (2 * ObstructionsHeight < HorizontalDistanceToObstruction &&
                HorizontalDistanceToObstruction < 6 * ObstructionsHeight)
                return Math.Min(
                    1.2 * ObstructionsHeight - 0.2 * HorizontalDistanceToObstruction,
                    0.6 * _building.Height);
            else
                return 0;
        }

        #endregion // Public_Methods
    }
}
