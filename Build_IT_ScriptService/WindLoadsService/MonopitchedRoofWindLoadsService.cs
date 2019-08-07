﻿using Build_IT_Data.Calculators;
using Build_IT_Data.Calculators.Interfaces;
using Build_IT_WindLoads;
using Build_IT_WindLoads.BuildingData;
using Build_IT_WindLoads.BuildingData.Interfaces;
using Build_IT_WindLoads.Factors;
using Build_IT_WindLoads.TerrainOrographies;
using Build_IT_WindLoads.Terrains;
using Build_IT_WindLoads.WindLoadsCases;
using Build_IT_WindLoads.WindLoadsCases.Roofs;
using System;
using System.Collections.Generic;
using System.Composition;

namespace Build_IT_ScriptService.WindLoadsService
{
    [Export("WindLoad-MonopitchedRoof", typeof(ICalculator))]
    [Export(typeof(ICalculator))]
    [ExportMetadata("Document", "PN-EN 1991-1-4")]
    [ExportMetadata("Type", "WindLoad")]
    public class MonopitchedRoofWindLoadsService : WindLoadBaseService
    {
        #region Properties

        public Property<double> BuildingLength { get; } =
            new Property<double>("BuildingLength",
                v => Convert.ToDouble(v));
        public Property<double> BuildingWidth { get; } =
            new Property<double>("BuildingWidth",
                v => Convert.ToDouble(v));
        public Property<double> BuildingMaxHeight { get; } =
            new Property<double>("BuildingMaxHeight",
                v => Convert.ToDouble(v));
        public Property<double> BuildingMinHeight { get; } =
            new Property<double>("BuildingMinHeight",
                v => Convert.ToDouble(v));

        public Property<double> ReferenceHeight { get; } =
            new Property<double>("ReferenceHeight",
                v => Convert.ToDouble(v));

        public Property<MonopitchRoof.Rotation> BuildingOrientation { get; } =
            new Property<MonopitchRoof.Rotation>("BuildingOrientation",
                v => Enum.Parse<MonopitchRoof.Rotation>(v.ToString()), required: false);

        #endregion // Properties

        #region Constructors

        public MonopitchedRoofWindLoadsService()
        {
            Result = new Result(new Dictionary<string, string>() {
                { "e", null },
                { "v_b,0_", null },
                { "c_dir_", null },
                { "v_b_", null },
                { "c_r_(z_e_)", null },
                { "c_0_(z_e_)", null },
                { "v_m_(z_e_)", null },
                { "I_v_(z_e_)", null },
                { "q_p_(z_e_)", null },
                { "c_sc,d_", null },
                { "w_e,Fup_", null },
                { "w_e,Flow_", null },
                { "w_e,F_", null },
                { "w_e,G_", null },
                { "w_e,H_", null },
                { "w_e,I_", null },
            });
        }

        #endregion // Constructors

        #region Public_Methods

        public override IResult Calculate()
        {
            MonopitchRoof structureData = GetStructureData();
            HeightDisplacement heightDisplacement = GetHeightDisplacement(structureData);
            TerrainOrography terrainOrography = GetTerrainOrography();
            Terrain terrain = GetTerrainCategory(heightDisplacement, terrainOrography);
            DirectionalFactor directionalFactor = GetDirectionalFactor();
            BuildingSite buildingSite = GetBuildingSite(terrain, directionalFactor);
            ReferenceHeightDueToNeighbouringStructures referenceHeightDueToNeighbouringStructures
                = GetReferenceHeightDueToNeighbouringStructures();
            WindLoadData windLoadData = GetWindLoadData(buildingSite, structureData, referenceHeightDueToNeighbouringStructures);
            MonopitchedRoofWindLoads wallsWindLoads = GetMonopitchRoofWindLoads(structureData, windLoadData);
            StructuralFactorCalculator structuralFactorCalculator =
                GetStructuralFactorCalculator(structureData, terrain, windLoadData);
            ExternalPressureWindForce externalPressureWindForce =
                GetExternalPressureWindForce(windLoadData, wallsWindLoads, structuralFactorCalculator);

            var referenceHeight = ReferenceHeight.HasValue ? ReferenceHeight.Value : BuildingMaxHeight.Value;
            var externalPressureWindForceMax = externalPressureWindForce.GetExternalPressureWindForceMaxAt(
                referenceHeight, calculateStructuralFactor: structuralFactorCalculator != null);

            Result["e"] = structureData.EdgeDistance;
            Result["v_b,0_"] = buildingSite.FundamentalValueBasicWindVelocity;
            Result["c_dir_"] = directionalFactor?.GetFactor() ?? DirectionalFactor.DefaultDirectionalFactor;
            Result["v_b_"] = buildingSite.BasicWindVelocity;
            Result["c_r_(z_e_)"] = terrain.GetRoughnessFactorAt(referenceHeight);
            Result["c_0_(z_e_)"] = terrainOrography?.GetFactorAt(referenceHeight) ?? TerrainOrography.DefaultOrographyFactor;
            Result["v_m_(z_e_)"] = windLoadData.GetMeanWindVelocityAt(referenceHeight);
            Result["I_v_(z_e_)"] = windLoadData.GetTurbulenceIntensityAt(referenceHeight);
            Result["q_p_(z_e_)"] = windLoadData.GetPeakVelocityPressureAt(referenceHeight);
            Result["c_s_c_d_"] = structuralFactorCalculator?.GetStructuralFactor(structuralFactorCalculator != null) ?? StructuralFactorCalculator.DefaultStructuralFactor;
            SetPressureWindForces(externalPressureWindForceMax);

            return Result;
        }

        #endregion // Public_Methods

        #region Private_Methods

        private void SetPressureWindForces(IDictionary<Field, double> externalPressureWindForceMax)
        {
            Result["w_e,F_"] = externalPressureWindForceMax.ContainsKey(Field.F) ? externalPressureWindForceMax[Field.F] : double.NaN;
            Result["w_e,Fup_"] = externalPressureWindForceMax.ContainsKey(Field.Fup) ? externalPressureWindForceMax[Field.Fup] : double.NaN;
            Result["w_e,Flow_"] = externalPressureWindForceMax.ContainsKey(Field.Fup) ? externalPressureWindForceMax[Field.Flow] : double.NaN;
            Result["w_e,G_"] = externalPressureWindForceMax.ContainsKey(Field.G) ? externalPressureWindForceMax[Field.G] : double.NaN;
            Result["w_e,H_"] = externalPressureWindForceMax.ContainsKey(Field.H) ? externalPressureWindForceMax[Field.H] : double.NaN;
            Result["w_e,I_"] = externalPressureWindForceMax.ContainsKey(Field.I) ? externalPressureWindForceMax[Field.I] : double.NaN;
        }

        private MonopitchRoof GetStructureData()
        {
            return new MonopitchRoof(BuildingLength.Value, BuildingWidth.Value,
                BuildingMaxHeight.Value, BuildingMinHeight.Value, BuildingOrientation.Value);
        }

        private MonopitchedRoofWindLoads GetMonopitchRoofWindLoads(IMonopitchRoof structure, IWindLoadData windLoadData)
        {
            return MonopitchedRoofWindLoads.Create(structure, windLoadData);
        }

        #endregion // Private_Methods
    }
}
