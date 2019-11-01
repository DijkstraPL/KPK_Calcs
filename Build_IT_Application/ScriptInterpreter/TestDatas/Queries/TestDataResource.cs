using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Application.ScriptInterpreter.TestDatas.Queries
{
    public class TestDataResource
    {
        #region Properties
        
        public long Id { get; set; }
        public long ScriptId { get; set; }
        public string Name { get; set; }
        public ICollection<TestParameterResource> TestParameters { get; private set; }
        public ICollection<AssertionResource> Assertions { get; private set; }

        #endregion // Properties

        #region Constructors

        public TestDataResource()
        {
            TestParameters = new HashSet<TestParameterResource>();
            Assertions = new HashSet<AssertionResource>();
        }

        #endregion // Constructors
    }
}
