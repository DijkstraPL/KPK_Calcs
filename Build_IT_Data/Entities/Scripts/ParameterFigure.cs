namespace Build_IT_Data.Entities.Scripts
{
    public class ParameterFigure
    {
        #region Properties
        
        public long ParameterId { get; set; }
        public long FigureId { get; set; }
        public Parameter Parameter { get; set; }
        public Figure Figure { get; set; }

        #endregion // Properties
    }
}
