using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Data.Entities.Scripts
{
    public class TestData
    {
        #region Properties
               
        public long Id { get; set; }
        public long ScriptId { get; set; }
        public Script Script { get; set; }
        public string Name { get; set; }
        public ICollection<TestParameter> TestParameters { get; private set; }
        public ICollection<Assertion> Assertions { get; private set; }

        #endregion // Properties               

        #region Constructors

        public TestData()
        {
            TestParameters = new HashSet<TestParameter>();
            Assertions = new HashSet<Assertion>();
        }

        #endregion // Constructors
    }
}
