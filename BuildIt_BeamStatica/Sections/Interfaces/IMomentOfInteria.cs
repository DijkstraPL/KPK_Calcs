using Build_IT_Tools;

namespace Build_IT_BeamStatica.Sections.Interfaces
{
    public interface IMomentOfInteria
    {
        [Abbreviation("I")]
        [Unit("cm4")]
        double MomentOfInteria { get; }
    }
}
