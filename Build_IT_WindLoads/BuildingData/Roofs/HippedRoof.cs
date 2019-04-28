using Build_IT_WindLoads.BuildingData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_WindLoads.BuildingData.Roofs
{
    public class HippedRoof : Structure, IHippedRoof
    {
        #region Properties

        public Rotation CurrentRotation { get; }
        public double MiddleHeight { get; private set; }
        public double OuterHeight { get; private set; }
        public double Angle { get; private set; }
        public double RidgeLength { get; private set; }

        #endregion // Properties

        #region Constructors

        public HippedRoof(
            double length, double width, double ridgeLength,
            double outerHeight, double middleHeight, Rotation rotation)
            : base()
        {
            CurrentRotation = rotation;

            OuterHeight = outerHeight;
            MiddleHeight = middleHeight;
            Height = MiddleHeight;
            RidgeLength = ridgeLength;

            if (CurrentRotation == Rotation.Degrees_0)
            {
                Length = length;
                Width = width;
                Angle = Math.Atan((MiddleHeight - OuterHeight) / 
                    (Length / 2)) * 180 / Math.PI;
            }
            else if (CurrentRotation == Rotation.Degrees_90)
            {
                Length = width;
                Width = length;
                Angle = Math.Atan((MiddleHeight - OuterHeight) /
                    ((Length - RidgeLength) / 2)) * 180 / Math.PI;
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
                var restDistance = Width / 2 - 
                    GetDistanceForParallelToRidgeWindAt(EdgeDistance / 10) / 2;
                var areaForFField = ((EdgeDistance / 4 + 
                    (EdgeDistance / 4 - restDistance)) *
                    EdgeDistance / 10) / 2;

                Areas.Add(Field.F, areaForFField);
                Areas.Add(Field.G, (Width - 2 * EdgeDistance / 4) * EdgeDistance / 10);
                Areas.Add(Field.H, (GetDistanceForParallelToRidgeWindAt(EdgeDistance / 10) + RidgeLength ) * 
                    (Length / 2 - EdgeDistance / 10) / 2);
                Areas.Add(Field.I, ((GetDistanceForParallelToRidgeWindAt(
                    Length/ 2 - EdgeDistance / 10)  + (Width -  EdgeDistance / 10 ) *2)) * 
                    (Length / 2 - EdgeDistance / 10));
                //Areas.Add(Field.J, EdgeDistance / 10 * Width);
            }
            else if (CurrentRotation == Rotation.Degrees_90)
            {
                //Areas.Add(Field.F, EdgeDistance / 4 * EdgeDistance / 10);
                //Areas.Add(Field.G, (Width - 2 * EdgeDistance / 4) * EdgeDistance / 10);
                //Areas.Add(Field.H, (EdgeDistance / 2 - EdgeDistance / 10) * Width);
                //Areas.Add(Field.I, (Length - EdgeDistance / 2) * Width);
            }
            else
                throw new ArgumentException(nameof(CurrentRotation));
        }

        private double GetDistanceForParallelToRidgeWindAt(double x)
        {
           return ((RidgeLength / Length - Width / Length) *
                    x + Width / 2) * 2;
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
