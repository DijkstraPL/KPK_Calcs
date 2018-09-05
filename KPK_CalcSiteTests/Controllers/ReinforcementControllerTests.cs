using KPK_CalcSite.ViewModels;
using NUnit.Framework;
using System.Web.Mvc;

namespace KPK_CalcSite.Controllers.Tests
{
    [TestFixture()]
    public class ReinforcementControllerTests
    {

        [Test()]
        public void ReinforcementAnchoringTest()
        {
            // Arrange
            ReinforcementController controller = new ReinforcementController();

            // Act
            ViewResult result = controller.ReinforcementAnchoring() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ReinforcementAnchoring", result.ViewName);
            Assert.IsTrue(result.Model.GetType() == typeof(ReinforcementAnchoringViewModel));
        }

        [Test()]
        public void CalculateReinforcementAnchoring()
        {
            // Arrange
            ReinforcementController controller = new ReinforcementController();
            var model = new ReinforcementAnchoringViewModel()
            {
                ReinforcementDiameter = 12,
                ConcreteClassName = ReinforcementAnchoring.ConcreteClassEnum.C20_25,
                PressInReinforcement = 500
            };

            // Act
            ViewResult result = controller.CalculateReinforcementAnchoring(model) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ReinforcementAnchoring", result.ViewName);
            Assert.IsTrue(result.Model.GetType() == typeof(ReinforcementAnchoringViewModel));
            Assert.IsTrue(model.ShowResults);
        }
    }
}