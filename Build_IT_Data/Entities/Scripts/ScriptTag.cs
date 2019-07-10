namespace Build_IT_Data.Entities.Scripts
{
    public class ScriptTag
    {
        #region Properties
        
        public long ScriptId { get; set; }
        public long TagId { get; set; }
        public Script Script { get; set; }
        public Tag Tag { get; set; }

        #endregion // Properties
    }
}
