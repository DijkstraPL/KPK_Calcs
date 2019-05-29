using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Scripts;
using Build_IT_ScriptInterpreter.Scripts.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Build_IT_ScriptInterpreterTests.UnitTests.Scripts
{
    [TestFixture]
   public  class CalculationEngineTests
    {
        [Test]
        public void CalculateFromTextTest_Success()
        {
            var parameter1 = new Mock<IParameter>();
            parameter1.Setup(p => p.Context).Returns(ParameterOptions.Editable | ParameterOptions.Visible);
            parameter1.Setup(p => p.Name).Returns("a");

            var parameter2 = new Mock<IParameter>();
            parameter2.Setup(p => p.Context).Returns(ParameterOptions.Editable | ParameterOptions.Visible);
            parameter2.Setup(p => p.Name).Returns("b");

            var parameter3 = new Mock<IParameter>();
            parameter3.Setup(p => p.Context).Returns(ParameterOptions.StaticData);
            parameter3.Setup(p => p.Name).Returns("c");
            parameter3.Setup(p => p.Value).Returns(3);

            var parameter4 = new Mock<IParameter>();
            parameter4.Setup(p => p.Context).Returns(ParameterOptions.Calculation | ParameterOptions.Visible);
            parameter4.Setup(p => p.Name).Returns("d");
            parameter4.SetupProperty(p => p.Value);
            parameter4.Object.Value = "[a]+[b]*[c]";

            var script = new Mock<ICalculatable>();
            script.Setup(s => s.Parameters)
                .Returns(new List<IParameter>
                {
                    parameter1.Object,
                    parameter2.Object,
                    parameter3.Object,
                    parameter4.Object
                });

            var calculationEngine = new CalculationEngine(script.Object);

            calculationEngine.CalculateFromText("[a]=1|[b]=2");

            Assert.That(parameter4.Object.Value, Is.EqualTo(7));
        }
    }
}
