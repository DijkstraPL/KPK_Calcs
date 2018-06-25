using System;
using System.Collections.Generic;

namespace WindLoads
{
    public sealed class BuildingWithFlatRoof : Building
    {
        #region Properties

        public WindDirectionEnum WindDirection { get; set; } = WindDirectionEnum.NONE;

        public RoofTypeEnum RoofType { get; set; } = RoofTypeEnum.NONE;

        public FieldIValuesEnum IFieldValue { get; set; } = FieldIValuesEnum.NONE;

        public override Dictionary<string, double> AreasOfWindZonesForWalls { get; set; }

        public override Dictionary<string, double> AreasOfWindZonesForRoof { get; set; }

        public override Dictionary<string, double> ExternalPressureCoefficientsForWalls { get; set; }

        public override Dictionary<string, double> ExternalPressureCoefficientsForRoof { get; set; }

        public double InterpolationFactor { get; private set; }

        public List<string> ListOfFieldsForWalls { get; } = new List<string> { "Field A", "Field B", "Field C", "Field D", "Field E" };

        public List<string> ListOfFieldsForRoof { get; } = new List<string> { "Field F", "Field G", "Field H", "Field I" };

        public override double[][,] TableWithExternalPressureCoefficientsForWalls { get; } = new double[2][,]
        {
           new double[3,5] // c_pe,10
           {
               { -1.2, -0.8, -0.5, 0.8, -0.7 }, // h/d = 5
               { -1.2, -0.8, -0.5, 0.8, -0.5 }, // h/d = 1
               { -1.2, -0.8, -0.5, 0.7, -0.3 }, // h/d = 0.25
           },
           new double[3,5] // c_pe,1
           {
               { -1.4, -1.1, -0.5, 1.0, -0.7 }, // h/d = 5
               { -1.4, -1.1, -0.5, 1.0, -0.5 }, // h/d = 1
               { -1.4, -1.1, -0.5, 1.0, -0.3 }, // h/d = 0.25
           }
        };

        public double AtticHeight { get; set; } = 0;

        public double RoundingRadius { get; set; } = 0;

        public double Angle { get; set; } = 0;

        public double[][,] TableWithExternalPressureCoefficientsForSharpEavesRoof { get; } = new double[2][,]
        {
            new double[2, 4] // c_pe,10
            {
                {-1.8, -1.2, -0.7, 0.2 }, // +0.2 for F field
                {-1.8, -1.2, -0.7, -0.2 } // -0.2 for F field
            },
            new double[2, 4] // c_pe,1
            {
                {-2.5, -2, -1.2, 0.2 }, // +0.2 for F field
                {-2.5, -2, -1.2, -0.2 } // -0.2 for F field
            }
        };

        public double[][,] TableWithExternalPressureCoefficientsForRoofWithParapetes { get; } = new double[2][,]
        {
            new double[6, 4] // c_pe,10
            {
                {-1.6, -1.1, -0.7, 0.2 }, // h_p/h = 0.025 and +0.2 for F field
                {-1.6, -1.1, -0.7, -0.2 }, // h_p/h = 0.025 and -0.2 for F field
                {-1.4, -0.9, -0.7, 0.2 }, // h_p/h = 0.05 and +0.2 for F field
                {-1.4, -0.9, -0.7, -0.2 }, // h_p/h = 0.05 and -0.2 for F field
                {-1.2, -0.8, -0.7, 0.2 }, // h_p/h = 0.10 and +0.2 for F field
                {-1.2, -0.8, -0.7, -0.2 } // h_p/h = 0.10 and -0.2 for F field
            },
            new double[6, 4] // c_pe,1
            {
                {-2.2, -1.8, -1.2, 0.2 }, // h_p/h = 0.025 and +0.2 for F field
                {-2.2, -1.8, -1.2, -0.2 }, // h_p/h = 0.025 and -0.2 for F field
                {-2.0, -1.6, -1.2, 0.2}, // h_p/h = 0.05 and +0.2 for F field
                {-2.0, -1.6, -1.2, -0.2}, // h_p/h = 0.05 and -0.2 for F field
                {-1.8, -1.4, -1.2, 0.2}, // h_p/h = 0.10 and +0.2 for F field
                {-1.8, -1.4, -1.2, -0.2} // h_p/h = 0.10 and -0.2 for F field
            }
        };

        public double[][,] TableWithExternalPressureCoefficientsForCurvedEavesRoof { get; } = new double[2][,]
        {
            new double[6, 4] // c_pe,10
            {
                {-1.0, -1.2, -0.4, 0.2}, // r/h = 0.05 and +0.2 for F field
                {-1.0, -1.2, -0.4, -0.2}, // r/h = 0.05 and -0.2 for F field
                {-0.7, -0.8, -0.3, 0.2}, // r/h = 0.10 and +0.2 for F field
                {-0.7, -0.8, -0.3, -0.2}, // r/h = 0.10 and -0.2 for F field
                {-0.5, -0.5, -0.3, 0.2}, // r/h = 0.20 and +0.2 for F field
                {-0.5, -0.5, -0.3, -0.2} // r/h = 0.20 and -0.2 for F field
            },
            new double[6, 4] // c_pe,1
            {
                {-1.5, -1.8, -0.4, 0.2}, // r/h = 0.05 and +0.2 for F field
                {-1.5, -1.8, -0.4, -0.2}, // r/h = 0.05 and -0.2 for F field
                {-1.2, -1.4, -0.3, 0.2}, // r/h = 0.10 and +0.2 for F field
                {-1.2, -1.4, -0.3, -0.2}, // r/h = 0.10 and -0.2 for F field
                {-0.8, -0.8, -0.3, 0.2}, // r/h = 0.20 and +0.2 for F field
                {-0.8, -0.8, -0.3, -0.2} // r/h = 0.20 and -0.2 for F field
            }
        };

        public double[][,] TableWithExternalPressureCoefficientsForMansardEavesRoof { get; } = new double[2][,]
{
            new double[6, 4] // c_pe,10
            {
                {-1.0, -1.0, -0.3, 0.2}, // a = 30 and +0.2 for F field
                {-1.0, -1.0, -0.3, -0.2}, // a = 30 and -0.2 for F field
                {-1.2, -1.3, -0.4, 0.2}, // a = 45 and +0.2 for F field
                {-1.2, -1.3, -0.4, -0.2}, // a = 45 and -0.2 for F field
                {-1.3, -1.3, -0.5, 0.2}, // a = 60 and +0.2 for F field
                {-1.3, -1.3, -0.5, -0.2}  // a = 60 and -0.2 for F field
            },
            new double[6, 4] // c_pe,1
            {
                {-1.5, -1.5, -0.3, 0.2}, // a = 30 and +0.2 for F field
                {-1.5, -1.5, -0.3, -0.2}, // a = 30 and -0.2 for F field
                {-1.8, -1.9, -0.4, 0.2}, // a = 45 and +0.2 for F field
                {-1.8, -1.9, -0.4, -0.2}, // a = 45 and -0.2 for F field
                {-1.9, -1.9, -0.5, 0.2}, // a = 60 and +0.2 for F field
                {-1.9, -1.9, -0.5, -0.2}  // a = 60 and -0.2 for F field
            }
};

        public override InternalPressureCoefficientEnum InternalPressureCoefficientFromEnum { get; set; }

        public override double InternalPressureCoefficient { get; set; }

        #endregion

        #region Constructors

        public BuildingWithFlatRoof(InternalPressureCoefficientEnum internalPressureCoefficient, double buildingWidth, double buildingLength, double buildingHeight)
        {
            InternalPressureCoefficientFromEnum = internalPressureCoefficient;

            SetInternalPressureCoefficient();

            AreasOfWindZonesForWalls = new Dictionary<string, double>();
            ExternalPressureCoefficientsForWalls = new Dictionary<string, double>();
            foreach (string field in ListOfFieldsForWalls)
            {
                AreasOfWindZonesForWalls.Add(field, 0);
                ExternalPressureCoefficientsForWalls.Add(field, 0);
            }

            AreasOfWindZonesForRoof = new Dictionary<string, double>();
            ExternalPressureCoefficientsForRoof = new Dictionary<string, double>();
            foreach (string field in ListOfFieldsForRoof)
            {
                AreasOfWindZonesForRoof.Add(field, 0);
                ExternalPressureCoefficientsForRoof.Add(field, 0);
            }

            BuildingWidth = buildingWidth;
            BuildingLength = buildingLength;
            BuildingHeight = buildingHeight;
        }

        public BuildingWithFlatRoof(InternalPressureCoefficientEnum internalPressureCoefficient,
            double buildingWidth, double buildingLength, double buildingHeight, RoofTypeEnum roofType, double valueOfEnum)
            : this(internalPressureCoefficient, buildingWidth, buildingLength, buildingHeight)
        {




            RoofType = roofType;

            switch (RoofType)
            {
                case RoofTypeEnum.SHARP_EAVES:
                    break;
                case RoofTypeEnum.WITH_PARAPETS:
                    AtticHeight = valueOfEnum;
                    break;
                case RoofTypeEnum.CURVED_EAVES:
                    RoundingRadius = valueOfEnum;
                    break;
                case RoofTypeEnum.MANSARD_EAVES:
                    Angle = valueOfEnum;
                    break;
                default:
                    throw new ArgumentException("Roof type should be selected.");
            }
        }
        
        #endregion

        public void CalculateWindLoads(WindDirectionEnum windDirection, FieldIValuesEnum valueOfIField)
        {
            IFieldValue = valueOfIField;

            SetInternalPressureCoefficient();
            CalculateAreas(windDirection);
            CalculateExternalPressureCoefficientForWalls();
            CalculateExternalPressureCoefficientForRoof();
        }

        private void SetInternalPressureCoefficient()
        {
            switch (InternalPressureCoefficientFromEnum)
            {
                case InternalPressureCoefficientEnum.POINT_TWO:
                    InternalPressureCoefficient = 0.2;
                    break;
                case InternalPressureCoefficientEnum.MINUS_POINT_THREE:
                    InternalPressureCoefficient = -0.3;
                    break;
                case InternalPressureCoefficientEnum.CALCULATE:
                    throw new NotImplementedException();
                case InternalPressureCoefficientEnum.NONE:
                    throw new ArgumentException("There is no specified which internal pressure coefficient should be taken into evaluations.");
            }
        }

        protected override void CalculateExternalPressureCoefficientForRoof()
        {
            switch (RoofType)
            {
                case RoofTypeEnum.SHARP_EAVES:
                    CalculateExternalPressureCoefficientForSharpEavesRoof();
                    break;
                case RoofTypeEnum.WITH_PARAPETS:
                    CalculateExternalPressureCoefficientForRoofWithParapets();
                    break;
                case RoofTypeEnum.CURVED_EAVES:
                    CalculateExternalPressureCoefficientForCurvedEavesRoof();
                    break;
                case RoofTypeEnum.MANSARD_EAVES:
                    CalculateExternalPressureCoefficientForMansardEavesRoof();
                    break;
                case RoofTypeEnum.NONE:
                    throw new ArgumentException("Roof type should be specified.");
                default:
                    break;
            }
        }

        private void CalculateExternalPressureCoefficientForMansardEavesRoof()
        {
            int i = 0;

            double externalPressureCoefficientsFoRoofMin;
            double externalPressureCoefficientsForRoofMax;

            int index = (int)IFieldValue - 1;

            double mansardInterpolationFactor = RoundingRadius / BuildingHeight;

            if (mansardInterpolationFactor < 30)
                throw new ArgumentOutOfRangeException("Current factor of height to one of the building dimensions is not supported, by the current algorithms.");

            foreach (string field in ListOfFieldsForRoof)
            {
                if (mansardInterpolationFactor <= 45)
                {
                    externalPressureCoefficientsFoRoofMin = LinearInterpolation
                        (TableWithExternalPressureCoefficientsForMansardEavesRoof[1][1 + index, i], TableWithExternalPressureCoefficientsForMansardEavesRoof[1][0 + index, i], 0.05, 0.025);

                    externalPressureCoefficientsForRoofMax = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForMansardEavesRoof[0][1 + index, i], TableWithExternalPressureCoefficientsForMansardEavesRoof[0][0 + index, i], 0.05, 0.025);
                }
                else if (mansardInterpolationFactor <= 60)
                {
                    externalPressureCoefficientsFoRoofMin = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForMansardEavesRoof[1][2 + index, i], TableWithExternalPressureCoefficientsForMansardEavesRoof[1][1 + index, i], 0.10, 0.05);

                    externalPressureCoefficientsForRoofMax = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForMansardEavesRoof[0][2 + index, i], TableWithExternalPressureCoefficientsForMansardEavesRoof[0][1 + index, i], 0.10, 0.05);
                }
                else
                {
                    externalPressureCoefficientsFoRoofMin = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForSharpEavesRoof[1][0 + index, i], TableWithExternalPressureCoefficientsForMansardEavesRoof[1][2 + index, i], 0.10, 0.05);

                    externalPressureCoefficientsForRoofMax = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForSharpEavesRoof[0][0 + index, i], TableWithExternalPressureCoefficientsForMansardEavesRoof[0][2 + index, i], 0.10, 0.05);
                }

                if (AreasOfWindZonesForRoof[field] >= 10)
                    ExternalPressureCoefficientsForRoof[field] = externalPressureCoefficientsForRoofMax;
                else if (AreasOfWindZonesForRoof[field] <= 1)
                    ExternalPressureCoefficientsForRoof[field] = externalPressureCoefficientsFoRoofMin;
                else
                    ExternalPressureCoefficientsForRoof[field] =
                    CalculateExternalPressureCoefficientForValueBetweenMinAndMax
                       (externalPressureCoefficientsFoRoofMin, externalPressureCoefficientsForRoofMax, AreasOfWindZonesForRoof[field]);

                i++;
            }
        }

        private void CalculateExternalPressureCoefficientForCurvedEavesRoof()
        {
            int i = 0;

            double externalPressureCoefficientsFoRoofMin;
            double externalPressureCoefficientsForRoofMax;

            int index = (int)IFieldValue - 1;

            double curvedInterpolationFactor = RoundingRadius / BuildingHeight;

            if (curvedInterpolationFactor > 0.2 || curvedInterpolationFactor < 0.05)
                throw new ArgumentOutOfRangeException("Current factor of height to one of the building dimensions is not supported, by the current algorithms.");

            foreach (string field in ListOfFieldsForRoof)
            {
                if (curvedInterpolationFactor <= 0.10)
                {
                    externalPressureCoefficientsFoRoofMin = LinearInterpolation
                        (TableWithExternalPressureCoefficientsForCurvedEavesRoof[1][1 + index, i], TableWithExternalPressureCoefficientsForCurvedEavesRoof[1][0 + index, i], 0.10, 0.05);

                    externalPressureCoefficientsForRoofMax = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForCurvedEavesRoof[0][1 + index, i], TableWithExternalPressureCoefficientsForCurvedEavesRoof[0][0 + index, i], 0.10, 0.05);
                }
                else
                {
                    externalPressureCoefficientsFoRoofMin = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForCurvedEavesRoof[1][2 + index, i], TableWithExternalPressureCoefficientsForCurvedEavesRoof[1][1 + index, i], 0.20, 0.10);

                    externalPressureCoefficientsForRoofMax = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForCurvedEavesRoof[0][2 + index, i], TableWithExternalPressureCoefficientsForCurvedEavesRoof[0][1 + index, i], 0.20, 0.10);
                }

                if (AreasOfWindZonesForRoof[field] >= 10)
                    ExternalPressureCoefficientsForRoof[field] = externalPressureCoefficientsForRoofMax;
                else if (AreasOfWindZonesForRoof[field] <= 1)
                    ExternalPressureCoefficientsForRoof[field] = externalPressureCoefficientsFoRoofMin;
                else
                    ExternalPressureCoefficientsForRoof[field] =
                    CalculateExternalPressureCoefficientForValueBetweenMinAndMax
                       (externalPressureCoefficientsFoRoofMin, externalPressureCoefficientsForRoofMax, AreasOfWindZonesForRoof[field]);

                i++;
            }
        }

        private void CalculateExternalPressureCoefficientForRoofWithParapets()
        {
            int i = 0;

            double externalPressureCoefficientsFoRoofMin;
            double externalPressureCoefficientsForRoofMax;

            int index = (int)IFieldValue - 1;

            double atticInterpolationFactor = AtticHeight / (BuildingHeight - AtticHeight);

            if (atticInterpolationFactor > 0.1 || atticInterpolationFactor < 0.025)
                throw new ArgumentOutOfRangeException("Current factor of height to one of the building dimensions is not supported, by the current algorithms.");

            foreach (string field in ListOfFieldsForRoof)
            {
                if (atticInterpolationFactor <= 0.05)
                {
                    externalPressureCoefficientsFoRoofMin = LinearInterpolation
                        (TableWithExternalPressureCoefficientsForRoofWithParapetes[1][1 + index, i], TableWithExternalPressureCoefficientsForRoofWithParapetes[1][0 + index, i], 0.05, 0.025);

                    externalPressureCoefficientsForRoofMax = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForRoofWithParapetes[0][1 + index, i], TableWithExternalPressureCoefficientsForRoofWithParapetes[0][0 + index, i], 0.05, 0.025);
                }
                else
                {
                    externalPressureCoefficientsFoRoofMin = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForRoofWithParapetes[1][2 + index, i], TableWithExternalPressureCoefficientsForRoofWithParapetes[1][1 + index, i], 0.10, 0.05);

                    externalPressureCoefficientsForRoofMax = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForRoofWithParapetes[0][2 + index, i], TableWithExternalPressureCoefficientsForRoofWithParapetes[0][1 + index, i], 0.10, 0.05);
                }

                if (AreasOfWindZonesForRoof[field] >= 10)
                    ExternalPressureCoefficientsForRoof[field] = externalPressureCoefficientsForRoofMax;
                else if (AreasOfWindZonesForRoof[field] <= 1)
                    ExternalPressureCoefficientsForRoof[field] = externalPressureCoefficientsFoRoofMin;
                else
                    ExternalPressureCoefficientsForRoof[field] =
                    CalculateExternalPressureCoefficientForValueBetweenMinAndMax
                       (externalPressureCoefficientsFoRoofMin, externalPressureCoefficientsForRoofMax, AreasOfWindZonesForRoof[field]);

                i++;
            }
        }

        private void CalculateExternalPressureCoefficientForSharpEavesRoof()
        {
            int i = 0;

            int index = (int)IFieldValue - 1;

            foreach (string field in ListOfFieldsForRoof)
            {
                if (AreasOfWindZonesForRoof[field] >= 10)
                    ExternalPressureCoefficientsForRoof[field] = TableWithExternalPressureCoefficientsForSharpEavesRoof[0][index, i];
                else if (AreasOfWindZonesForRoof[field] <= 1)
                    ExternalPressureCoefficientsForRoof[field] = TableWithExternalPressureCoefficientsForSharpEavesRoof[1][index, i];
                else
                    ExternalPressureCoefficientsForRoof[field] =
                    CalculateExternalPressureCoefficientForValueBetweenMinAndMax
                       (TableWithExternalPressureCoefficientsForSharpEavesRoof[1][index, i], TableWithExternalPressureCoefficientsForSharpEavesRoof[0][index, i], AreasOfWindZonesForRoof[field]);

                i++;
            }
        }

        protected override void CalculateExternalPressureCoefficientForWalls()
        {
            int i = 0;

            double externalPressureCoefficientsForWallsMin;
            double externalPressureCoefficientsForWallsMax;

            foreach (string field in ListOfFieldsForWalls)
            {
                if (InterpolationFactor > 1)
                {
                    externalPressureCoefficientsForWallsMin = LinearInterpolation
                        (TableWithExternalPressureCoefficientsForWalls[1][1, i], TableWithExternalPressureCoefficientsForWalls[1][0, i], 1, 5);

                    externalPressureCoefficientsForWallsMax = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForWalls[0][1, i], TableWithExternalPressureCoefficientsForWalls[0][0, i], 1, 5);
                }
                else
                {
                    externalPressureCoefficientsForWallsMin = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForWalls[1][2, i], TableWithExternalPressureCoefficientsForWalls[1][1, i], 0.25, 1);

                    externalPressureCoefficientsForWallsMax = LinearInterpolation
                       (TableWithExternalPressureCoefficientsForWalls[0][2, i], TableWithExternalPressureCoefficientsForWalls[0][1, i], 0.25, 1);
                }

                if (AreasOfWindZonesForWalls[field] >= 10)
                    ExternalPressureCoefficientsForWalls[field] = externalPressureCoefficientsForWallsMax;
                else if (AreasOfWindZonesForWalls[field] <= 1)
                    ExternalPressureCoefficientsForWalls[field] = externalPressureCoefficientsForWallsMin;
                else
                    ExternalPressureCoefficientsForWalls[field] =
                        CalculateExternalPressureCoefficientForValueBetweenMinAndMax
                           (externalPressureCoefficientsForWallsMin, externalPressureCoefficientsForWallsMax, AreasOfWindZonesForWalls[field]);

                i++;
            }
        }

        private double LinearInterpolation(double minValue, double maxValue, double minInterpolation, double maxInterpolation)
        => minValue + (maxValue - minValue) / (maxInterpolation - minInterpolation) * (InterpolationFactor - minInterpolation);

        private double CalculateInterpolationFactorForWalls(double d, double b, double h)
        {
            double interpolationFactor = h / d;

            if (interpolationFactor > 5)
                throw new ArgumentOutOfRangeException("Current factor of height to one of the building dimensions is not sup[ported, by the current algorithms.");

            if (interpolationFactor <= 0.25)
                interpolationFactor = 0.25;

            return interpolationFactor;
        }

        protected override void CalculateAreas(WindDirectionEnum windDirection)
        {
            double d;
            double b;
            double h;

            SetProperWallBuildingDimensions(windDirection, out d, out b, out h);

            double wallZoneRange = Math.Min(b, 2 * h);

            SetAreasForWallFields(wallZoneRange, d, b, h);

            SetAreasForRoofFields(wallZoneRange, d, b, h);

            InterpolationFactor = CalculateInterpolationFactorForWalls(d, b, h);
        }

        protected override void SetAreasForRoofFields(double wallZoneRange, double d, double b, double h)
        {
            AreasOfWindZonesForRoof["Field F"] = wallZoneRange / 4 * wallZoneRange / 10;
            AreasOfWindZonesForRoof["Field G"] = (b - 2 * wallZoneRange / 4) * wallZoneRange / 10;
            AreasOfWindZonesForRoof["Field H"] = (wallZoneRange / 2 - wallZoneRange / 10) * b;
            AreasOfWindZonesForRoof["Field I"] = (d - wallZoneRange / 2) * b;
        }

        protected override void SetAreasForWallFields(double wallZoneRange, double d, double b, double h)
        {
            if (wallZoneRange < d)
            {
                AreasOfWindZonesForWalls["Field A"] = wallZoneRange / 5 * h;
                AreasOfWindZonesForWalls["Field B"] = wallZoneRange * 4 / 5 * h;
                AreasOfWindZonesForWalls["Field C"] = (d - wallZoneRange) * h;
                AreasOfWindZonesForWalls["Field D"] = b * h;
                AreasOfWindZonesForWalls["Field E"] = b * h;
            }
            else if (wallZoneRange >= d && wallZoneRange < 5 * d)
            {
                AreasOfWindZonesForWalls["Field A"] = wallZoneRange / 5 * h;
                AreasOfWindZonesForWalls["Field B"] = (d - wallZoneRange / 5) * h;
                AreasOfWindZonesForWalls["Field C"] = 0;
                AreasOfWindZonesForWalls["Field D"] = b * h;
                AreasOfWindZonesForWalls["Field E"] = b * h;
            }
            else
            {
                AreasOfWindZonesForWalls["Field A"] = d * h;
                AreasOfWindZonesForWalls["Field B"] = 0;
                AreasOfWindZonesForWalls["Field C"] = 0;
                AreasOfWindZonesForWalls["Field D"] = b * h;
                AreasOfWindZonesForWalls["Field E"] = b * h;
            }
        }

        protected override void SetProperWallBuildingDimensions(WindDirectionEnum windDirection, out double d, out double b, out double h)
        {
            switch (windDirection)
            {
                case WindDirectionEnum.RIGHT:
                case WindDirectionEnum.LEFT:
                    d = BuildingWidth;
                    b = BuildingLength;
                    break;
                case WindDirectionEnum.UP:
                case WindDirectionEnum.DOWN:
                    d = BuildingLength;
                    b = BuildingWidth;
                    break;
                case WindDirectionEnum.NONE:
                default:
                    throw new ArgumentException("There is no wind direction selected.");
            }

            h = BuildingHeight;
        }

        public enum RoofTypeEnum
        {
            NONE,
            SHARP_EAVES,
            WITH_PARAPETS,
            CURVED_EAVES,
            MANSARD_EAVES,
        }

        public enum FieldIValuesEnum
        {
            NONE,
            POINT_TWO,
            MINUS_POINT_TWO
        }
    }
}
