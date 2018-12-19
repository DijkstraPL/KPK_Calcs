namespace Build_IT_BeamStatica.Sections.Interfaces
{
    public interface ISection : IArea, IMomentOfInteria
    {
        double SolidHeight { get; }
    }
}
