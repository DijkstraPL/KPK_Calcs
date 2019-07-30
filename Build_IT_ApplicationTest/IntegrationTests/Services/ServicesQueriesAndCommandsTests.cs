using Build_IT_Application.ScriptInterpreter.Services.Queries.GetAllServices;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Build_IT_ApplicationTest.IntegrationTests.Services
{
    [TestFixture]
    public class ServicesQueriesAndCommandsTests
    {
        [Test]
        public void GetAllServicesQueryTest_Success()
        {
            var getAllServicesQuery = new GetAllServicesQuery.Handler();
            var results = getAllServicesQuery.Handle(new GetAllServicesQuery(), CancellationToken.None).Result;

            Assert.That(results.Count(), Is.GreaterThan(0));
            foreach (var result in results)
            {
                Assert.That(result.ContractName, Is.Not.Null.And.Not.Empty);
                Assert.That(result.Properties.Count(), Is.GreaterThan(0));
                Assert.That(result.Results.Count(), Is.GreaterThan(0));
            }
        }
    }
}
