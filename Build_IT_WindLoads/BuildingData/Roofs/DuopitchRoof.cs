using Build_IT_WindLoads.BuildingData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_WindLoads.BuildingData.Roofs
{
    public class DuopitchRoof : Structure, IDuopitchRoof
    {
        #region Properties

        public Rotation CurrentRotation { get; }
        public double MiddleHeight { get; private set; }
        public double OuterHeight { get; private set; }
        public double Angle { get; private set; }

        #endregion // Properties

        #region Constructors

        public DuopitchRoof(
            double length, double width,
            double outerHeight, double middleHeight, Rotation rotation)
            : base()
        {
            CurrentRotation = rotation;

            OuterHeight = outerHeight;
            MiddleHeight = middleHeight;
            Height = Math.Max(MiddleHeight, OuterHeight);
            Angle = Math.Atan((MiddleHeight - OuterHeight) / (Length / 2)) * 180 / Math.PI;

            if (CurrentRotation == Rotation.Degrees_0)
            {
                Length = length;
                Width = width;
            }
            else if (CurrentRotation == Rotation.Degrees_90)
            {
                Length = width;
                Width = length;
            }
            else
                throw new ArgumentException(nameof(CurrentRotation));

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
            if (CurrentRotation == Rotation.Degrees_0)
            {
                Areas.Add(Field.F, EdgeDistance / 4 * EdgeDistance / 10);
                Areas.Add(Field.G, (Width - 2 * EdgeDistance / 4) * EdgeDistance / 10);
                Areas.Add(Field.H, (Length / 2 - EdgeDistance / 10) * Width);
                Areas.Add(Field.J, EdgeDistance / 10 * Width);
                Areas.Add(Field.I, (Length / 2 - EdgeDistance / 10) * Width);
            }
            else if (CurrentRotation == Rotation.Degrees_90)
            {
                Areas.Add(Field.F, EdgeDistance / 4 * EdgeDistance / 10);
                Areas.Add(Field.G, (Width - 2 * EdgeDistance / 4) * EdgeDistance / 10);
                Areas.Add(Field.H, (EdgeDistance / 2 - EdgeDistance / 10) * Width);
                Areas.Add(Field.I, (Length - EdgeDistance / 2) * Width);
            }
            throw new ArgumentException(nameof(CurrentRotation));
        }

        #endregion // Private_Methods

        #region Enums

        public enum Rotation
        {
            Degrees_0,
            Degrees_90
        }

        #endregion // Enums
    }
}
