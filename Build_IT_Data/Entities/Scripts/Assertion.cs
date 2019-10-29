namespace Build_IT_Data.Entities.Scripts
{
    public class Assertion
    {
        #region Properties

        public long Id { get; set; }
        public string Value { get; set; }
        public long TestDataId { get; set; }
        public TestData TestData { get; set; }

        #endregion // Properties
    }
}