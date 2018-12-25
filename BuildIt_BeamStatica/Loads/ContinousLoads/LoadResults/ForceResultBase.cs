using Build_IT_BeamStatica.Loads.ContinousLoads.Interfaces;
using Build_IT_BeamStatica.Loads.Interfaces;

namespace Build_IT_BeamStatica.Loads.ContinousLoads.LoadResults
{
    internal abstract class ForceResultBase : ResultBase, IForceResult
    {
        protected ForceResultBase(IContinousLoad continousLoad) : base(continousLoad)
        {
        }

        public abstract double GetValue(double distanceFromLoadStartPosition);
    }
}
