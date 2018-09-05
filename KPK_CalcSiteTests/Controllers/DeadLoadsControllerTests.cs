using NUnit.Framework;
using System.Web.Mvc;

namespace KPK_CalcSite.Controllers.Tests
{
    [TestFixture()]
    public class DeadLoadsControllerTests
    {
        [Test()]
        public void DeadLoadCalculatorTest()
        {
            // Arrange
            DeadLoadsController controller = new DeadLoadsController();

            // Act
            ViewResult result = controller.DeadLoadCalculator() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Dead load", result.ViewBag.Title);
        }

        [Test()]
        public void GetSubcategoriesTest()
        {
            // Arrange
            DeadLoadsController controller = new DeadLoadsController();

            // Act
            JsonResult result = controller.GetSubcategories("1", "Concretes");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
        }

        [Test()]
        public void GetMaterialTest()
        {
            // Arrange
            DeadLoadsController controller = new DeadLoadsController();

            // Act
            JsonResult result = controller.GetMaterial("34");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual("Żelbet", ((DeadLoads.Material)result.Data).Name);
        }
    }
}