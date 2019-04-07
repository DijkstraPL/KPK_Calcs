namespace Build_IT_BeamStatica.Sections.Interfaces
{
    public interface ISection : IArea, IMomentOfInteria
    {
        #region Properties

        double SolidHeight { get; }

        #endregion // Properties
    }
}
