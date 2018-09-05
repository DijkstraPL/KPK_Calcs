using KPK_CalcSite.Models.SnowLoads;
using NUnit.Framework;
using SnowLoads;
using SnowLoads.BuildingTypes;
using SnowLoads.Exceptional;
using System.Web.Mvc;

namespace KPK_CalcSite.Controllers.Tests
{
    [TestFixture()]
    public class SnowLoadsControllerTests
    {
        [Test]
        public void CalculatorTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();

            // Act
            ViewResult result = controller.Calculator() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Snow load", result.ViewBag.Title);
        }

        [Test]
        public void MonopitchRoofTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();

            // Act
            ViewResult result = controller.MonopitchRoof() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        private BuildingData CreateBuildingData(
            DesignSituation designSituation = DesignSituation.A, bool exceptional = false)
        {
            var buildingSite = new BuildingSite(ZoneEnum.FirstZone, TopographyEnum.Sheltered, 250);
            var snowLoad = new SnowLoad(buildingSite, designSituation, exceptional);
            var building = new Building(snowLoad);

            return new BuildingData()
            {
                BuildingSite = buildingSite,
                SnowLoad = snowLoad,
                Building = building
            };
        }


        [Test]
        public void CalculateMonopitchRoofTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();
            var buildingData = CreateBuildingData();
            var model = CreateMonopitchRoof(buildingData);

            // Act
            ViewResult result = controller.CalculateMonopitchRoof(model, buildingData) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("MonopitchRoofResult", result.ViewName);
            Assert.IsTrue(result.Model.GetType() == typeof(SnowLoadMonopitchRoof));
            Assert.AreNotEqual(0, model.MonopitchRoof.SnowLoadOnRoofValue);
        }

        private SnowLoadMonopitchRoof CreateMonopitchRoof(BuildingData buildingData)
        {
            return new SnowLoadMonopitchRoof()
            {
                BuildingData = buildingData,
                MonopitchRoof = new MonopitchRoof(buildingData.Building, 30)
            };
        }

        [Test]
        public void PitchedRoofTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();

            // Act
            ViewResult result = controller.PitchedRoof() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CalculatePitchedRoofTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();
            var buildingData = CreateBuildingData();
            var model = CreatePitchedRoof(buildingData);

            // Act
            ViewResult result = controller.CalculatePitchedRoof(model, buildingData) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("PitchedRoofResult", result.ViewName);
            Assert.IsTrue(result.Model.GetType() == typeof(SnowLoadPitchedRoof));
            Assert.AreNotEqual(0, model.PitchedRoof.LeftRoofCasesSnowLoad[1]);
        }

        private SnowLoadPitchedRoof CreatePitchedRoof(BuildingData buildingData)
        {
            return new SnowLoadPitchedRoof()
            {
                BuildingData = buildingData,
                PitchedRoof = new PitchedRoof(buildingData.Building, 30, 30)                
            };
        }

        [Test]
        public void MultispanRoofTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();

            // Act
            ViewResult result = controller.MultispanRoof() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CalculateMultispanRoofTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();
            var buildingData = CreateBuildingData();
            var model = CreateMultiSpanRoof(buildingData);

            // Act
            ViewResult result = controller.CalculateMultispanRoof(model, buildingData) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("MultispanRoofResult", result.ViewName);
            Assert.IsTrue(result.Model.GetType() == typeof(SnowLoadMultispanRoof));
            Assert.AreNotEqual(0, model.MultiSpanRoof.SnowLoadOnMiddleRoof);
        }

        private SnowLoadMultispanRoof CreateMultiSpanRoof(BuildingData buildingData)
        {
            return new SnowLoadMultispanRoof()
            {
                BuildingData = buildingData,
                MultiSpanRoof = new MultiSpanRoof(buildingData.Building, 30, 30)
            };
        }

        [Test]
        public void CylindricalRoofTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();

            // Act
            ViewResult result = controller.CylindricalRoof() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CalculateCylindricalRoofTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();
            var buildingData = CreateBuildingData();
            var model = CreateCylindricalRoof(buildingData);

            // Act
            ViewResult result = controller.CalculateCylindricalRoof(model, buildingData) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("CylindricalRoofResult", result.ViewName);
            Assert.IsTrue(result.Model.GetType() == typeof(SnowLoadCylindricalRoof));
            Assert.AreNotEqual(0, model.CylindricalRoof.SnowLoadOnRoofValue);
        }

        private SnowLoadCylindricalRoof CreateCylindricalRoof(BuildingData buildingData)
        {
            return new SnowLoadCylindricalRoof()
            {
                BuildingData = buildingData,
                CylindricalRoof = new CylindricalRoof(buildingData.Building, 20, 10)
            };
        }

        [Test]
        public void RoofAbuttingToTallerConstructionTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();

            // Act
            ViewResult result = controller.RoofAbuttingToTallerConstruction() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CalculateRoofAbuttingToTallerConstructionTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();
            var buildingData = CreateBuildingData();
            var model = CreateRoofAbuttingToTallerConstruction(buildingData);

            // Act
            ViewResult result = controller.CalculateRoofAbuttingToTallerConstruction(model, buildingData) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("RoofAbuttingToTallerConstructionResult", result.ViewName);
            Assert.IsTrue(result.Model.GetType() == typeof(SnowLoadRoofAbuttingToTallerConstruction));
            Assert.AreNotEqual(0, model.RoofAbuttingToTallerConstruction.SnowLoadOnRoofValue);
        }

        private SnowLoadRoofAbuttingToTallerConstruction CreateRoofAbuttingToTallerConstruction(BuildingData buildingData)
        {
            return new SnowLoadRoofAbuttingToTallerConstruction()
            {
                BuildingData = buildingData,
                RoofAbuttingToTallerConstruction = new RoofAbuttingToTallerConstruction(
                    buildingData.Building, 20, 10, 5, 
                new MonopitchRoof(buildingData.Building, 35))
            };
        }

        [Test]
        public void DriftingAtProjectionsObstructionsTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();

            // Act
            ViewResult result = controller.DriftingAtProjectionsObstructions() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CalculateDriftingAtProjectionsObstructionsTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();
            var buildingData = CreateBuildingData();
            var model = CreateDriftingAtProjectionsObstructions(buildingData);

            // Act
            ViewResult result = controller.CalculateDriftingAtProjectionsObstructions(model, buildingData) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("DriftingAtProjectionsObstructionsResult", result.ViewName);
            Assert.IsTrue(result.Model.GetType() == typeof(SnowLoadDriftingAtProjectionsObstructions));
            Assert.AreNotEqual(0, model.DriftingAtProjectionsObstructions.SnowLoadOnRoofValue);
        }

        private SnowLoadDriftingAtProjectionsObstructions CreateDriftingAtProjectionsObstructions(BuildingData buildingData)
        {
            return new SnowLoadDriftingAtProjectionsObstructions()
            {
                BuildingData = buildingData,
                DriftingAtProjectionsObstructions = new DriftingAtProjectionsObstructions(
                    buildingData.Building, 1  )
            };
        }

        [Test]
        public void SnowOverhangingTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();

            // Act
            ViewResult result = controller.SnowOverhanging() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CalculateSnowOverhangingTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();
            var buildingData = CreateBuildingData();
            var model = CreateSnowOverhanging(buildingData);

            // Act
            ViewResult result = controller.CalculateSnowOverhanging(model, buildingData) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("SnowOverhangingResult", result.ViewName);
            Assert.IsTrue(result.Model.GetType() == typeof(SnowLoadSnowOverhanging));
            Assert.AreNotEqual(0, model.SnowOverhanging.SnowLoadOnRoofValue);
        }

        private SnowLoadSnowOverhanging CreateSnowOverhanging(BuildingData buildingData)
        {
            return new SnowLoadSnowOverhanging()
            {
                BuildingData = buildingData,
                SnowOverhanging = new SnowOverhanging(
                    buildingData.Building, 1)
            };
        }

        [Test]
        public void SnowguardsTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();

            // Act
            ViewResult result = controller.Snowguards() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CalculateSnowguardsTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();
            var buildingData = CreateBuildingData();
            var model = CreateSnowguards();

            // Act
            ViewResult result = controller.CalculateSnowguards(model, buildingData) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("SnowguardsResult", result.ViewName);
            Assert.IsTrue(result.Model.GetType() == typeof(SnowLoadSnowguards));
            Assert.AreNotEqual(0, model.Snowguards.SnowLoadOnRoofValue);
        }

        private SnowLoadSnowguards CreateSnowguards()
        {
            return new SnowLoadSnowguards()
            {
                Snowguards = new Snowguards(10, 30, 2)
            };
        }

        [Test]
        public void ExceptionalMultispanRoofTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();

            // Act
            ViewResult result = controller.ExceptionalMultispanRoof() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CalculateExceptionalMultispanRoofTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();
            var buildingData = CreateBuildingData(DesignSituation.B3, true);
            var model = CreateExceptionalMultispanRoof(buildingData);

            // Act
            ViewResult result = controller.CalculateExceptionalMultispanRoof(model, buildingData) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ExceptionalMultispanRoofResult", result.ViewName);
            Assert.IsTrue(result.Model.GetType() == typeof(ExceptionalSnowLoadMultispanRoof));
            Assert.AreNotEqual(0, model.ExceptionalMultispanRoof.SnowLoad);
        }

        private ExceptionalSnowLoadMultispanRoof CreateExceptionalMultispanRoof(BuildingData buildingData)
        {
            return new ExceptionalSnowLoadMultispanRoof()
            {
                BuildingData = buildingData,
                ExceptionalMultispanRoof = new ExceptionalMultiSpanRoof(buildingData.Building, 5, 10,2)
            };
        }

        [Test]
        public void ExceptionalRoofAbuttingToTallerConstructionTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();

            // Act
            ViewResult result = controller.ExceptionalRoofAbuttingToTallerConstruction() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CalculateExceptionalRoofAbuttingToTallerConstructionTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();
            var buildingData = CreateBuildingData(DesignSituation.B3, true);
            var model = CreateExceptionalRoofAbuttingToTallerConstruction(buildingData);

            // Act
            ViewResult result = controller.CalculateExceptionalRoofAbuttingToTallerConstruction(model, buildingData) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ExceptionalRoofAbuttingToTallerConstructionResult", result.ViewName);
            Assert.IsTrue(result.Model.GetType() == typeof(ExceptionalSnowLoadRoofAbuttingToTallerConstruction));
            Assert.AreNotEqual(0, model.ExceptionalRoofAbuttingToTallerConstruction.SnowLoadNearTheEdge);
        }

        private ExceptionalSnowLoadRoofAbuttingToTallerConstruction CreateExceptionalRoofAbuttingToTallerConstruction(BuildingData buildingData)
        {
            return new ExceptionalSnowLoadRoofAbuttingToTallerConstruction()
            {
                BuildingData = buildingData,
                ExceptionalRoofAbuttingToTallerConstruction = 
                new ExceptionalRoofAbuttingToTallerConstruction(buildingData.Building, 20, 15 , 2 ,10)
            };
        }

        [Test]
        public void ExceptionalObstructionOnFlatRoofTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();

            // Act
            ViewResult result = controller.ExceptionalObstructionOnFlatRoof() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CalculateExceptionalObstructionOnFlatRoofTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();
            var buildingData = CreateBuildingData(DesignSituation.B3, true);
            var model = CreateExceptionalObstructionOnFlatRoof(buildingData);

            // Act
            ViewResult result = controller.CalculateExceptionalObstructionOnFlatRoof(model, buildingData) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ExceptionalObstructionOnFlatRoofResult", result.ViewName);
            Assert.IsTrue(result.Model.GetType() == typeof(ExceptionalSnowLoadObstructionOnFlatRoof));
            Assert.AreNotEqual(0, model.ExceptionalObstructionOnFlatRoof.LeftSnowLoad);
        }

        private ExceptionalSnowLoadObstructionOnFlatRoof CreateExceptionalObstructionOnFlatRoof(BuildingData buildingData)
        {
            return new ExceptionalSnowLoadObstructionOnFlatRoof()
            {
                BuildingData = buildingData,
                ExceptionalObstructionOnFlatRoof =
                new ExceptionalObstructionOnFlatRoof(buildingData.Building, 20, 15, 0.8, 1)
            };
        }

        [Test]
        public void ExceptionalOverDoorOrLoadingBayTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();

            // Act
            ViewResult result = controller.ExceptionalOverDoorOrLoadingBay() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CalculateExceptionalOverDoorOrLoadingBayTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();
            var buildingData = CreateBuildingData(DesignSituation.B3, true);
            var model = CreateExceptionalOverDoorOrLoadingBay(buildingData);

            // Act
            ViewResult result = controller.CalculateExceptionalOverDoorOrLoadingBay(model, buildingData) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ExceptionalOverDoorOrLoadingBayResult", result.ViewName);
            Assert.IsTrue(result.Model.GetType() == typeof(ExceptionalSnowLoadOverDoorOrLoadingBay));
            Assert.AreNotEqual(0, model.ExceptionalOverDoorOrLoadingBay.SnowLoad);
        }

        private ExceptionalSnowLoadOverDoorOrLoadingBay CreateExceptionalOverDoorOrLoadingBay(BuildingData buildingData)
        {
            return new ExceptionalSnowLoadOverDoorOrLoadingBay()
            {
                BuildingData = buildingData,
                ExceptionalOverDoorOrLoadingBay =
                new ExceptionalOverDoorOrLoadingBay(buildingData.Building, 5, 10 ,2)
            };
        }

        [Test]
        public void ExceptionalObstructionOnPitchedOrCurvedRoofTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();

            // Act
            ViewResult result = controller.ExceptionalObstructionOnPitchedOrCurvedRoof() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CalculateObstructionOnPitchedOrCurvedRoofTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();
            var buildingData = CreateBuildingData(DesignSituation.B3, true);
            var model = CreateExceptionalObstructionOnPitchedOrCurvedRoof(buildingData);

            // Act
            ViewResult result = controller.CalculateExceptionalObstructionOnPitchedOrCurvedRoof(model, buildingData) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ExceptionalObstructionOnPitchedOrCurvedRoofResult", result.ViewName);
            Assert.IsTrue(result.Model.GetType() == typeof(ExceptionalSnowLoadObstructionOnPitchedOrCurvedRoof));
            Assert.AreNotEqual(0, model.ExceptionalObstructionOnPitchedOrCurvedRoof.LeftSnowLoad);
        }

        private ExceptionalSnowLoadObstructionOnPitchedOrCurvedRoof CreateExceptionalObstructionOnPitchedOrCurvedRoof(BuildingData buildingData)
        {
            return new ExceptionalSnowLoadObstructionOnPitchedOrCurvedRoof()
            {
                BuildingData = buildingData,
                ExceptionalObstructionOnPitchedOrCurvedRoof =
                new ExceptionalObstructionOnPitchedOrCurvedRoof(buildingData.Building, 5, 10, 2, 1)
            };
        }

        [Test]
        public void ExceptionalSnowBehindParapetTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();

            // Act
            ViewResult result = controller.ExceptionalSnowBehindParapet() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CalculateSnowBehindParapetTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();
            var buildingData = CreateBuildingData(DesignSituation.B3, true);
            var model = CreateExceptionalSnowBehindParapet(buildingData);

            // Act
            ViewResult result = controller.CalculateExceptionalSnowBehindParapet(model, buildingData) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ExceptionalSnowBehindParapetResult", result.ViewName);
            Assert.IsTrue(result.Model.GetType() == typeof(ExceptionalSnowLoadSnowBehindParapet));
            Assert.AreNotEqual(0, model.ExceptionalSnowBehindParapet.SnowLoad);
        }

        private ExceptionalSnowLoadSnowBehindParapet CreateExceptionalSnowBehindParapet(BuildingData buildingData)
        {
            return new ExceptionalSnowLoadSnowBehindParapet()
            {
                BuildingData = buildingData,
                ExceptionalSnowBehindParapet =
                new ExceptionalSnowBehindParapet(buildingData.Building, 15, 1)
            };
        }

        [Test]
        public void ExceptionalSnowBehindParapetAtEavesTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();

            // Act
            ViewResult result = controller.ExceptionalSnowBehindParapetAtEaves() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CalculateSnowBehindParapetAtEavesTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();
            var buildingData = CreateBuildingData(DesignSituation.B3, true);
            var model = CreateExceptionalSnowBehindParapetAtEaves(buildingData);

            // Act
            ViewResult result = controller.CalculateExceptionalSnowBehindParapetAtEaves(model, buildingData) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ExceptionalSnowBehindParapetAtEavesResult", result.ViewName);
            Assert.IsTrue(result.Model.GetType() == typeof(ExceptionalSnowLoadSnowBehindParapetAtEaves));
            Assert.AreNotEqual(0, model.ExceptionalSnowBehindParapetAtEaves.SnowLoad);
        }

        private ExceptionalSnowLoadSnowBehindParapetAtEaves CreateExceptionalSnowBehindParapetAtEaves(BuildingData buildingData)
        {
            return new ExceptionalSnowLoadSnowBehindParapetAtEaves()
            {
                BuildingData = buildingData,
                ExceptionalSnowBehindParapetAtEaves =
                new ExceptionalSnowBehindParapetAtEaves(buildingData.Building, 15, 30,1)
            };
        }
        
        [Test]
        public void ExceptionalSnowInValleyBehindParapetTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();

            // Act
            ViewResult result = controller.ExceptionalSnowInValleyBehindParapet() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CalculateSnowInValleyBehindParapetTest()
        {
            // Arrange
            SnowLoadsController controller = new SnowLoadsController();
            var buildingData = CreateBuildingData(DesignSituation.B3, true);
            var model = CreateExceptionalSnowInValleyBehindParapet(buildingData);

            // Act
            ViewResult result = controller.CalculateExceptionalSnowInValleyBehindParapet(model, buildingData) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ExceptionalSnowInValleyBehindParapetResult", result.ViewName);
            Assert.IsTrue(result.Model.GetType() == typeof(ExceptionalSnowLoadSnowInValleyBehindParapet));
            Assert.AreNotEqual(0, model.ExceptionalSnowInValleyBehindParapet.SnowLoad);
        }

        private ExceptionalSnowLoadSnowInValleyBehindParapet CreateExceptionalSnowInValleyBehindParapet(BuildingData buildingData)
        {
            return new ExceptionalSnowLoadSnowInValleyBehindParapet()
            {
                BuildingData = buildingData,
                ExceptionalSnowInValleyBehindParapet =
                new ExceptionalSnowInValleyBehindParapet(buildingData.Building, 15, 1)
            };
        }
    }
}