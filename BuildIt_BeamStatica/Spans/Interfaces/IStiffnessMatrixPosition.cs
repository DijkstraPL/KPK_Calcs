namespace Build_IT_BeamStatica.Spans.Interfaces
{
    public interface IStiffnessMatrixPosition
    {
        #region Properties
        
        short RowNumber { get; }
        short ColumnNumber { get; }
        double Value { get; set; }

        #endregion // Properties
    }
}
