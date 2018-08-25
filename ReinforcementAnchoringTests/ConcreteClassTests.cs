using NUnit.Framework;
using System;

namespace ReinforcementAnchoring.Tests
{
    [TestFixture()]
    [Description("Check DesignValueConcreteTensileStrength for the ConcreteClass.")]
    public class ConcreteClassTests
    {
        [Test()]
        public void ConcreteClassTest_DesignValueConcreteTensileStrength_Success()
        {
            var concreteClass = ConcreteClass.ConcreteClasses[ConcreteClassEnum.C30_37];

            Assert.AreEqual(1.429, Math.Round(concreteClass.DesignValueConcreteTensileStrength,3),
                "DesignValueConcreteTensileStrength not calculated properly.");
        }
    }
}