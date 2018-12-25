using Build_IT_BeamStatica.Loads.ContinousLoads.Interfaces;
using Build_IT_BeamStatica.Loads.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;

namespace Build_IT_BeamStatica.Loads.ContinousLoads.LoadResults
{
    internal abstract class DisplacementResultBase : ResultBase, IDisplacementResult
    {
        protected DisplacementResultBase(IContinousLoad continousLoad) : base(continousLoad)
        {
        }

        public abstract double GetValue(ISpan span, double distanceFromLeftSide, double currentLength);
    }
}
