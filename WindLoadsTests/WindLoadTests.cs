using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindLoads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindLoads.Tests
{
    [TestClass()]
    public class WindLoadTests
    {
        public WindLoad windLoadFirst = new WindLoad(WindLoad.WindLoadEnum.FIRST_WIND_ZONE, 200, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_2, 20, 50, 70);
        public WindLoad windLoadSecond = new WindLoad(WindLoad.WindLoadEnum.THIRD_WIND_ZONE, 350, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_3, 50, 20, 40, WindLoad.WindDirectionEnum.DEGREE_90);

        [TestMethod, Description("Ensure that user couldn't set calculation height more than construction height.")]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Calculation height shouldn't be more than height above the ground.")]
        public void CalculateWindLoad_HeightForCalculationsIsMoreThanBuildingHeight_Exception()
        {
            windLoadFirst.CalculateWindLoad(25, false);
        }

        [DataTestMethod, Description("Ensure that SetVelocityValuesAndDirectionalFactorForCurrentWindZone method evaluates properly.")]
        [DataRow(WindLoad.WindLoadEnum.SECOND_WIND_ZONE, 100, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_0, 5, 10, 30, WindLoad.WindDirectionEnum.DEGREE_60, 3, 26, 0.42, 0.8)]
        [DataRow(WindLoad.WindLoadEnum.FIRST_WIND_ZONE, 200, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_2, 20, 50, 70, WindLoad.WindDirectionEnum.NONE, 20, 22, 0.3, 1)]
        [DataRow(WindLoad.WindLoadEnum.THIRD_WIND_ZONE, 350, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_3, 50, 20, 40, WindLoad.WindDirectionEnum.DEGREE_90, 20, 22.66, 0.307, 0.7)]
        public void CalculateWindLoadTest_SetVelocityValuesAndDirectionalFactorForCurrentWindZone_True
            (WindLoad.WindLoadEnum windZone, double heightAboveSea, WindLoad.TerrainCategoryEnum terrainCategory,
            double buildingHeight, double buildingWidth, double buildingLength, WindLoad.WindDirectionEnum windDirection,
            double calculationHeight,
            double expectedFundamentalBasicWindVelocity, double expectedBasicVelocityPressure, double expectedDirectionalFactor)
        {
            WindLoad windLoad = new WindLoad(windZone, heightAboveSea, terrainCategory, buildingHeight, buildingWidth, buildingLength, windDirection);
            windLoad.CalculateWindLoad(calculationHeight, false);

            Assert.AreEqual(Math.Round(windLoad.FundamentalValueOFTheBasicWindVelocity, 3), expectedFundamentalBasicWindVelocity);
            Assert.AreEqual(Math.Round(windLoad.BasicVelocityPressure, 3), expectedBasicVelocityPressure);
            Assert.AreEqual(Math.Round(windLoad.DirectionalFactor, 3), expectedDirectionalFactor);
        }

        [TestMethod, Description("Ensure that there is exception when user doesn't select any of the possible wind zones.")]
        [ExpectedException(typeof(ArgumentException), "Current wind zone is not supported!")]
        public void SetVelocityValuesAndDirectionalFactorForCurrentWindZone_NoneZoneSelected_Exception()
        {
            windLoadSecond.WindLoadZone = WindLoad.WindLoadEnum.NONE;

            windLoadSecond.CalculateWindLoad(20, false);
        }

        [DataTestMethod, Description("Ensure that equations for basic wind velocity are properly defined.")]
        [DataRow(WindLoad.WindLoadEnum.SECOND_WIND_ZONE, 100, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_0, 5, 10, 30, WindLoad.WindDirectionEnum.DEGREE_60, 3, 20.8)]
        [DataRow(WindLoad.WindLoadEnum.FIRST_WIND_ZONE, 200, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_2, 20, 50, 70, WindLoad.WindDirectionEnum.NONE, 20, 22)]
        [DataRow(WindLoad.WindLoadEnum.THIRD_WIND_ZONE, 350, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_3, 50, 20, 40, WindLoad.WindDirectionEnum.DEGREE_90, 20, 15.862)]
        public void CalculateWindLoadTest_CalculateBasicWindVelocity_True
        (WindLoad.WindLoadEnum windZone, double heightAboveSea, WindLoad.TerrainCategoryEnum terrainCategory,
        double buildingHeight, double buildingWidth, double buildingLength, WindLoad.WindDirectionEnum windDirection,
        double calculationHeight,
        double expectedBasicWindVelocity)
        {
            WindLoad windLoad = new WindLoad(windZone, heightAboveSea, terrainCategory, buildingHeight, buildingWidth, buildingLength, windDirection);
            windLoad.CalculateWindLoad(calculationHeight, false);

            Assert.AreEqual(Math.Round(windLoad.BasicWindVelocity, 3), expectedBasicWindVelocity);
        }

        [TestMethod, Description("Ensure that there is exception when user doesn't select any of the possible terrain category.")]
        [ExpectedException(typeof(ArgumentException), "There is none terrain category selected.")]
        public void CalculateWindLoadTest_SetTheRoughnessLengthAndExtremeHeights_HeightAboveSeaLessThan300_Exception()
        {
            windLoadFirst.TerrainCategory = WindLoad.TerrainCategoryEnum.NONE;
            windLoadFirst.CalculateWindLoad(20, false);
        }


        [DataTestMethod, Description("Ensure that SetTheRoughnessLengthAndExtremeHeights method calculate everything properly.")]
        [DataRow(WindLoad.WindLoadEnum.SECOND_WIND_ZONE, 100, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_0, 5, 10, 30, WindLoad.WindDirectionEnum.DEGREE_60, 3, 0.003, 1, 200)]
        [DataRow(WindLoad.WindLoadEnum.FIRST_WIND_ZONE, 200, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_2, 20, 50, 70, WindLoad.WindDirectionEnum.NONE, 20, 0.05, 2, 300)]
        [DataRow(WindLoad.WindLoadEnum.THIRD_WIND_ZONE, 350, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_3, 50, 20, 40, WindLoad.WindDirectionEnum.DEGREE_90, 20, 0.3 ,5, 400)]
        public void CalculateWindLoadTest_SetTheRoughnessLengthAndExtremeHeights_True
        (WindLoad.WindLoadEnum windZone, double heightAboveSea, WindLoad.TerrainCategoryEnum terrainCategory,
        double buildingHeight, double buildingWidth, double buildingLength, WindLoad.WindDirectionEnum windDirection,
        double calculationHeight,
        double expectedRoughnessLength, double expectedMinimumHeight, double expectedMaximumHeight)
        {
            WindLoad windLoad = new WindLoad(windZone, heightAboveSea, terrainCategory, buildingHeight, buildingWidth, buildingLength, windDirection);
            windLoad.CalculateWindLoad(calculationHeight, false);

            Assert.AreEqual(Math.Round(windLoad.RoughnessLength, 3), expectedRoughnessLength);
            Assert.AreEqual(windLoad.MinimumHeight, expectedMinimumHeight);
            Assert.AreEqual(windLoad.MaximumHeight, expectedMaximumHeight);
        }


        [DataTestMethod, Description("Ensure that SetBuildingFaceWidth method calculate everything properly.")]
        [DataRow(WindLoad.WindLoadEnum.SECOND_WIND_ZONE, 100, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_0, 5, 10, 30, WindLoad.WindDirectionEnum.DEGREE_60, 3, true, 10)]
        [DataRow(WindLoad.WindLoadEnum.FIRST_WIND_ZONE, 200, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_2, 20, 50, 70, WindLoad.WindDirectionEnum.NONE, 20, false, 70)]
        [DataRow(WindLoad.WindLoadEnum.THIRD_WIND_ZONE, 350, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_3, 50, 20, 10, WindLoad.WindDirectionEnum.DEGREE_90, 20, true, 20)]
        public void CalculateWindLoadTest_SetBuildingFaceWidth_True
        (WindLoad.WindLoadEnum windZone, double heightAboveSea, WindLoad.TerrainCategoryEnum terrainCategory,
        double buildingHeight, double buildingWidth, double buildingLength, WindLoad.WindDirectionEnum windDirection,
        double calculationHeight, bool windAlongTheLength,
        double expectedBuildingFaceWidth)
        {
            WindLoad windLoad = new WindLoad(windZone, heightAboveSea, terrainCategory, buildingHeight, buildingWidth, buildingLength, windDirection);
            windLoad.CalculateWindLoad(calculationHeight, windAlongTheLength);

            Assert.AreEqual(Math.Round(windLoad.BuildingFaceWidth, 3), expectedBuildingFaceWidth);
        }

        //[TestMethod, Description("Ensure that Reference Height is calculated properly.")]
        //public void SetReferenceHeight_HeightAboveSeaLessThan300_True()
        //{
        //    PrivateObject windObj = new PrivateObject(windLoadFirst);

        //    var referenceHeight = windObj.Invoke("SetReferenceHeight", 20);

        //    Assert.AreEqual(referenceHeight, 20);
        //}
        
        [DataTestMethod, Description("Ensure that CalculateRoughnessAndExposureFactor method calculate everything properly.")]
        [DataRow(WindLoad.WindLoadEnum.SECOND_WIND_ZONE, 100, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_0, 5, 10, 30, WindLoad.WindDirectionEnum.DEGREE_60, 3, true, 1.205, 2.667)]
        [DataRow(WindLoad.WindLoadEnum.FIRST_WIND_ZONE, 200, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_2, 20, 50, 70, WindLoad.WindDirectionEnum.NONE, 20, false, 1.125, 2.716)]
        [DataRow(WindLoad.WindLoadEnum.THIRD_WIND_ZONE, 350, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_3, 50, 20, 10, WindLoad.WindDirectionEnum.DEGREE_90, 10, true, 0.913, 2.275)]
        [DataRow(WindLoad.WindLoadEnum.THIRD_WIND_ZONE, 350, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_1, 50, 10, 10, WindLoad.WindDirectionEnum.DEGREE_90, 40, true, 1.437, 3.644)]
        [DataRow(WindLoad.WindLoadEnum.THIRD_WIND_ZONE, 350, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_1, 50, 10, 10, WindLoad.WindDirectionEnum.DEGREE_90, 45, true, 1.479, 3.802)]
        public void CalculateWindLoadTest_CalculateRoughnessAndExposureFactor_True
        (WindLoad.WindLoadEnum windZone, double heightAboveSea, WindLoad.TerrainCategoryEnum terrainCategory,
        double buildingHeight, double buildingWidth, double buildingLength, WindLoad.WindDirectionEnum windDirection,
        double calculationHeight, bool windAlongTheLength,
        double expectedRoughnessFactor, double expectedExposureFactor)
        {
            WindLoad windLoad = new WindLoad(windZone, heightAboveSea, terrainCategory, buildingHeight, buildingWidth, buildingLength, windDirection);
            windLoad.CalculateWindLoad(calculationHeight, windAlongTheLength);

            Assert.AreEqual(Math.Round(windLoad.RoughnessFactor, 3), expectedRoughnessFactor);
            Assert.AreEqual(Math.Round(windLoad.ExposureFactor, 3), expectedExposureFactor);
        }

        [DataTestMethod, Description("Ensure that CalculateTurbulenceIntensity method calculate everything properly.")]
        [DataRow(WindLoad.WindLoadEnum.SECOND_WIND_ZONE, 100, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_0, 5, 10, 30, WindLoad.WindDirectionEnum.DEGREE_60, 3, true, 0.135)]
        [DataRow(WindLoad.WindLoadEnum.FIRST_WIND_ZONE, 200, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_2, 20, 50, 70, WindLoad.WindDirectionEnum.NONE, 20, false, 0.167)]
        [DataRow(WindLoad.WindLoadEnum.THIRD_WIND_ZONE, 350, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_3, 50, 20, 10, WindLoad.WindDirectionEnum.DEGREE_90, 20, true, 0.238)]
        public void CalculateWindLoadTest_CalculateTurbulenceIntensity_True
        (WindLoad.WindLoadEnum windZone, double heightAboveSea, WindLoad.TerrainCategoryEnum terrainCategory,
        double buildingHeight, double buildingWidth, double buildingLength, WindLoad.WindDirectionEnum windDirection,
        double calculationHeight, bool windAlongTheLength,
        double expectedTurbulenceIntensity)
        {
            WindLoad windLoad = new WindLoad(windZone, heightAboveSea, terrainCategory, buildingHeight, buildingWidth, buildingLength, windDirection);
            windLoad.CalculateWindLoad(calculationHeight, windAlongTheLength);

            Assert.AreEqual(Math.Round(windLoad.TurbulenceIntensity, 3), expectedTurbulenceIntensity);
        }

        [DataTestMethod, Description("Ensure that CalculateMeanWindVelocity method calculate everything properly.")]
        [DataRow(WindLoad.WindLoadEnum.SECOND_WIND_ZONE, 100, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_0, 5, 10, 30, WindLoad.WindDirectionEnum.DEGREE_60, 3, true, 25.064)]
        [DataRow(WindLoad.WindLoadEnum.FIRST_WIND_ZONE, 200, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_2, 20, 50, 70, WindLoad.WindDirectionEnum.NONE, 20, false, 24.750)]
        [DataRow(WindLoad.WindLoadEnum.THIRD_WIND_ZONE, 350, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_3, 50, 20, 10, WindLoad.WindDirectionEnum.DEGREE_90, 10, true, 14.482)]
        public void CalculateWindLoadTest_CalculateMeanWindVelocity_True
        (WindLoad.WindLoadEnum windZone, double heightAboveSea, WindLoad.TerrainCategoryEnum terrainCategory,
        double buildingHeight, double buildingWidth, double buildingLength, WindLoad.WindDirectionEnum windDirection,
        double calculationHeight, bool windAlongTheLength,
        double expectedMeanWindVelocity)
        {
            WindLoad windLoad = new WindLoad(windZone, heightAboveSea, terrainCategory, buildingHeight, buildingWidth, buildingLength, windDirection);
            windLoad.CalculateWindLoad(calculationHeight, windAlongTheLength);

            Assert.AreEqual(Math.Round(windLoad.MeanWindVelocity, 3), expectedMeanWindVelocity);
        }
    }
}