using Build_IT_WindLoads.BuildingData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_WindLoads.BuildingData
{
    public class FlatRoofBuilding : Structure, IFlatRoofBuilding
    {
        #region Constructors

        public FlatRoofBuilding(double length, double width, double height, bool rotated = false)
            : base(length, width, height)
        {
            if (rotated)
            {
                var temp = Length;
                Length = Width;
                Width = temp;
            }

            SetWallAreas();
            SetRoofAreas();
        }

        #endregion // Constructors

        #region Public_Methods

        public override double GetReferenceHeight()
            => 0.6 * Height;

        #endregion // Public_Methods

        #region Private_Methods

        private void SetWallAreas()
        {
            if (EdgeDistance < Length)
                SetWallAreasForLargeBuildingWidth();
            else if (EdgeDistance >= 5 * Length)
                SetWallAreasForSmallBuildingWidth();
            else
                SetWallAreasForMediumBuildingWidth();

            Areas.Add(Field.D, Width * Height);
            Areas.Add(Field.E, Width * Height);
        }

        private void SetWallAreasForLargeBuildingWidth()
        {
            Areas.Add(Field.A, EdgeDistance / 5 * Height);
            Areas.Add(Field.B, 4 * EdgeDistance / 5 * Height);
            Areas.Add(Field.C, (Length - EdgeDistance) * Height);
        }

        private void SetWallAreasForSmallBuildingWidth()
        {
            Areas.Add(Field.A, Length * Height);
        }

        private void SetWallAreasForMediumBuildingWidth()
        {
            Areas.Add(Field.A, EdgeDistance / 5 * Height);
            Areas.Add(Field.B, (Length - EdgeDistance / 5) * Height);
        }

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
