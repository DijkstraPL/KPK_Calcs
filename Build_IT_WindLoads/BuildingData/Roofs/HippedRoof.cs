using Build_IT_CommonTools;
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

        [Abbreviation("α_0")]
        [Unit("°")]
        public double Angle0 { get; private set; }
        [Abbreviation("α_90")]
        [Unit("°")]
        public double Angle90 { get; private set; }
        public double RidgeLength { get; private set; }

        public double Angle0InRadians => Angle0 * Math.PI / 180;
        public double Angle90InRadians => Angle90 * Math.PI / 180;

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
            }
            else if (CurrentRotation == Rotation.Degrees_90)
            {
                Length = width;
                Width = length;
            }
            else
                throw new ArgumentException(nameof(CurrentRotation));

            Angle0 = Math.Atan((MiddleHeight - OuterHeight) /
                (length / 2)) * 180 / Math.PI;
            Angle90 = Math.Atan((MiddleHeight - OuterHeight) /
                ((width - RidgeLength) / 2)) * 180 / Math.PI;

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
                    EdgeDistance / 10 /
                    Math.Cos(Angle0InRadians)) / 2;

                Areas.Add(Field.F, areaForFField);
                Areas.Add(Field.G, (Width - 2 * EdgeDistance / 4) * EdgeDistance / 10);
                Areas.Add(Field.H, (GetDistanceForParallelToRidgeWindAt(EdgeDistance / 10) + RidgeLength ) * 
                    (Length / 2 - EdgeDistance / 10) / 2);
                Areas.Add(Field.I, ((GetDistanceForParallelToRidgeWindAt(
                    Length/ 2 - EdgeDistance / 10)  + (Width -  EdgeDistance / 10 ) *2)) * 
                    (Length / 2 - EdgeDistance / 10));
                Areas.Add(Field.J, EdgeDistance / 10 * (Length / 2 - EdgeDistance / 10));
                Areas.Add(Field.K, (GetDistanceForParallelToRidgeWindAt(
                    Length / 2 - EdgeDistance / 10)));
                // TODO: Add this + angles
                Areas.Add(Field.L,  EdgeDistance / 10  );
                Areas.Add(Field.M,  (Length - EdgeDistance / 10)  );
            }
            else if (CurrentRotation == Rotation.Degrees_90)
            {
                Areas.Add(Field.F, 1);
                Areas.Add(Field.G, 1);
                Areas.Add(Field.H, 1);
                Areas.Add(Field.I, 1);
                Areas.Add(Field.J, 1);
                Areas.Add(Field.L, 1);
                Areas.Add(Field.M, 1);
                Areas.Add(Field.N, 1);
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
