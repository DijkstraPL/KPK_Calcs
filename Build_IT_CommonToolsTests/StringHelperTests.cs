using Build_IT_CommonTools;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_CommonToolsTests
{
    [TestFixture]
    public class StringHelperTests
    {
        [Test]
        public void EverythingBetweenTest_Success()
        {
            var result = "a[bcde]fgh[ijk]l".EverythingBetween("[", "]");

            CollectionAssert.IsNotEmpty(result);
            CollectionAssert.Contains(result, "bcde");
            CollectionAssert.Contains(result, "ijk");
        }
    }
}
