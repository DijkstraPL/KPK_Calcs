using CalcSite.Controllers;
using KPK_CalcSite.Models;
using NUnit.Framework;
using System.Web.Mvc;

namespace KPK_CalcSiteTests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Calculator()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Calculators() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ContactForm()
        {
            //Arrange
            HomeController controller = new HomeController();
            var mail = new MailModels()
            {
                FirstName = "FirstNameTest",
                LastName = "LastNameTest",
                Email = "EmailTest@test.com",
                Country = "CountryTest",
                Message = "MessageTest",
                Telephone = "TelephoneTest"
            };

            // Act
            ViewResult result = controller.ContactForm(mail) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
