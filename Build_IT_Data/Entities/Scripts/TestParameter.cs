using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Data.Entities.Scripts
{
    public class TestParameter
    {
        #region Properties
               
        public long Id { get; set; }
        public long ParameterId { get; set; }
        public Parameter Parameter { get; set; }

        public long TestDataId { get; set; }
        public TestData TestData { get; set; }

        public string Value { get; set; }

        #endregion // Properties               
    }
}
