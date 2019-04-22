using Build_IT_CommonTools;
using Build_IT_WindLoads.BuildingData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Build_IT_WindLoads.BuildingData.Roofs
{
    public class FlatRoof : Structure, IFlatRoofBuilding
    {
        #region Constructors

        public FlatRoof(
            double length, double width, double height, bool rotated = false) : base()
        {
            if (length < 0 || width < 0 || height < 0)
                throw new ArgumentOutOfRangeException("Wrong building dimensions.");

            if (rotated)
            {
                Length = width;
                Width = length;
            }
            else
            {
                Length = length;
                Width = width;
            }
            Height = height;

            SetRoofAreas();
        }

        #endregion // Constructors

        #region Public_Methods

        public override double GetReferenceHeight()
            => 0.6 * Height;

        #endregion // Public_Methods

        #region Private_Methods
        
        private void SetRoofAreas()
        {
            Areas.Add(Field.F, EdgeDistance / 4 * EdgeDistance / 10);
            Areas.Add(Field.G, (Width - 2 * EdgeDistance / 4) * EdgeDistance / 10);
            Areas.Add(Field.H, (EdgeDistance / 2 - EdgeDistance / 10) * Width);
            Areas.Add(Field.I, (Length - EdgeDistance / 2) * Width);
        }

        #endregion // Private_Methods
    }
}
