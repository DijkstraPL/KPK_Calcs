using Build_IT_Data.Calculators;
using Build_IT_Data.Calculators.Interfaces;
using Build_IT_SnowLoads;
using Build_IT_SnowLoads.BuildingTypes;
using Build_IT_WindLoads;
using Build_IT_WindLoads.BuildingData.Walls;
using Build_IT_WindLoads.Factors;
using Build_IT_WindLoads.TerrainOrographies;
using Build_IT_WindLoads.Terrains;
using Build_IT_WindLoads.Terrains.Enums;
using Build_IT_WindLoads.WindLoadsCases;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;

namespace Build_IT_ScriptService.SnowLoadsService
{
    [Export("WindLoad-Walls", typeof(ICalculator))]
    [Export(typeof(ICalculator))]
    [ExportMetadata("Document", "PN-EN 1991-1-3")]
    [ExportMetadata("Type", "SnowLoad")]
    public class WallsWindLoadsService : ServiceBase
    {
        #region Properties

        public Property<double> BuildingLength { get; } =
            new Property<double>("BuildingLength",
                v => Convert.ToDouble(v));
        public Property<double> BuildingWidth { get; } =
            new Property<double>("BuildingWidth",
                v => Convert.ToDouble(v));
        public Property<double> BuildingHeight { get; } =
            new Property<double>("BuildingHeight",
                v => Convert.ToDouble(v));
        public Property<EqualHeightWalls.Rotation> WindDirection { get; } =
            new Property<EqualHeightWalls.Rotation>("WindDirection",
                v => Enum.Parse<EqualHeightWalls.Rotation>(v.ToString()));
        public Property<TerrainType> TerrainType { get; } =
            new Property<TerrainType>("TerrainType",
                v => Enum.Parse<TerrainType>(v.ToString()));
        public Property<double> HorizontalDistanceToObstruction { get; } =
            new Property<double>("HorizontalDistanceToObstruction",
                v => Convert.ToDouble(v));
        // h_ave_
        public Property<double> ObstructionHeight { get; } =
            new Property<double>("ObstructionHeight",
                v => Convert.ToDouble(v));

        #endregion // Properties

        #region Constructors

        public WallsWindLoadsService()
        {
            Result = new Result(new Dictionary<string, string>() { { "w", null } });
        }

        #endregion // Constructors

        #region Public_Methods
        
        public override IResult Calculate()
        {
            EqualHeightWalls structureData = GetStructureData();
            HeightDisplacement heightDisplacement = GetHeightDisplacement(structureData);
            Terrain terrain = GetTerrainCategory(heightDisplacement);
            BuildingSite buildingSite = GetBuildingSite();
            WindLoadData windLoadData = GetWindLoadData();
            WallsWindLoads wallsWindLoads = GetWallsWindLoads();

            //snowguards.CalculateSnowLoad();

            //var result = new Result();
            //result.Properties.Add("F_s_", snowguards.ForceExertedBySnow);

            // return result;
            throw new NotImplementedException();
        }

        #endregion // Public_Methods

        #region Private_Methods

        private EqualHeightWalls GetStructureData()
            => new EqualHeightWalls(BuildingLength.Value, BuildingWidth.Value,
                BuildingHeight.Value, WindDirection.Value);

        private Terrain GetTerrainCategory(HeightDisplacement heightDisplacement)
        {
            return Terrain.Create(TerrainType.Value, heightDisplacement);
          //  return new TerrainCategoryIV();
        }
        private HeightDisplacement GetHeightDisplacement(EqualHeightWalls structureData)
        {
            if (HorizontalDistanceToObstruction.HasValue && TerrainType.Value == Build_IT_WindLoads.Terrains.Enums.TerrainType.Terrain_IV)
                return new HeightDisplacement(structureData,
                    HorizontalDistanceToObstruction.Value,
                    ObstructionHeight.HasValue ? ObstructionHeight.Value : default);
            return null;
        }
        private TerrainOrography GetTerrainOrography()
        {
            throw new NotImplementedException();
        }

        private BuildingSite GetBuildingSite()
        {
            throw new NotImplementedException();
        }

        private WindLoadData GetWindLoadData()
        {
            throw new NotImplementedException();
        }

        private WallsWindLoads GetWallsWindLoads()
        {
            throw new NotImplementedException();
            // return new WallsWindLoads(Width.Value, Slope.Value, SnowLoad.Value);
        }


        #endregion // Private_Methods
    }
}
