using Build_IT_Data.Units.Enums;
using Build_IT_DeadLoads.Interfaces;

namespace Build_IT_DeadLoads
{
    public class Material : IMaterial
    {
        #region Properties

        public virtual string Name { get; protected set; }
        public virtual double MinimumDensity { get; protected set; }
        public virtual double MaximumDensity { get; protected set; }
        public LoadUnit Unit { get; }

        #endregion // Properties
    }
}
