namespace Build_IT_Data.Sections.Interfaces
{
    public interface ISection : IArea, IMomentOfInteria
    {
        #region Properties

        double SolidHeight { get; }

        #endregion // Properties
    }
}
