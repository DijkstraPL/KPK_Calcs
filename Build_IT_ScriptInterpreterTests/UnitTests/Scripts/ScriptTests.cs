using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Scripts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreterTests.UnitTests.Scripts
{
    [TestFixture]
    public class ScriptTests
    {
        [Test]
        public void GetParameterByNameTest_Success()
        {
            var parameter1 = Mock.Of<IParameter>(p => p.Name == "a");
            var parameter2 = Mock.Of<IParameter>(p => p.Name == "b");

            var script = new Script()
            {
                Parameters = new List<IParameter>()
                {
                    parameter1,
                    parameter2
                }
            };

            var parameter = script.GetParameterByName("a");

            Assert.That(parameter, Is.SameAs(parameter1));
        }
    }
}
