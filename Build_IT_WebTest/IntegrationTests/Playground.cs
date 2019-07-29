using Build_IT_Web.Controllers.ScriptInterpreterControllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_WebTest.IntegrationTests
{
    [TestFixture]
    public class Playground
    {
        [Test]
        public void Test()
        {
            var servicesController = new ServicesController();
        }
    }
}
