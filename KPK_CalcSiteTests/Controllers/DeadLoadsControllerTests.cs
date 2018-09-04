using KPK_CalcSite.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Web.Mvc;
using DeadLoads;

namespace KPK_CalcSite.Controllers.Tests
{
    [TestFixture()]
    public class DeadLoadsControllerTests
    {
        [Test()]
        public void DeadLoadCalculatorTest_Success()
        {
            var deadLoadsController = new DeadLoadsController();

            var result = deadLoadsController.DeadLoadCalculator();

            Assert.IsNotNull(result);
        }

        [Test()]
        public void AddMaterialTest_Success()
        {
            var deadLoadsController = new DeadLoadsController();

            var material = new Material() { Name = "Test" };


            var jsonMaterial = deadLoadsController.AddMaterial(material);

            Assert.IsNotNull(jsonMaterial);
        }
    }
}