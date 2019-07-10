namespace Build_IT_Data.Entities.DeadLoads
{
    public class MaterialAddition
    {
        #region Properties
        
        public long AdditionId { get; set; }
        public Addition Addition { get; set; }
        public long MaterialId { get; set; }
        public Material Material { get; set; }

        #endregion // Properties
    }
}
