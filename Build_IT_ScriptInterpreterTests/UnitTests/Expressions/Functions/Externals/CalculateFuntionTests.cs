﻿using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_ScriptInterpreter.Expressions.Functions.Externals;
using Moq;
using NUnit.Framework;

namespace Build_IT_ScriptInterpreterTests.UnitTests.Expressions.Functions.Externals
{
    [TestFixture]
    public class CalculateFuntionTests
    {
        [Test]
        public void ConstructorTest_Success()
        {
            var calculateFunction = new CalculateFunction();

            Assert.That(calculateFunction.Name, Is.EqualTo("CALCULATE"));
            Assert.That(calculateFunction.Function, Is.Not.Null);
        }

        [Test]
        public void ConstructorTest_WithRepositories_Success()
        {
            var scriptRepository = new Mock<IScriptRepository>();
            var parameterRepositort = new Mock<IParameterRepository>();
            var calculateFunction = new CalculateFunction(scriptRepository.Object, parameterRepositort.Object);

            Assert.That(calculateFunction.Name, Is.EqualTo("CALCULATE"));
            Assert.That(calculateFunction.Function, Is.Not.Null);
        }
    }
}
