using Build_IT_DeadLoads.Interfaces;

namespace Build_IT_DeadLoads.SpecialRules
{
    public class DifferentDensityMaterialDecorator : MaterialDecorator
    {
        #region Constructors

        public DifferentDensityMaterialDecorator(
            IMaterial material, double additionalDensity, string name = null)
            : base(material, name)
        {
            this.MaximumDensity = additionalDensity;
            this.MinimumDensity = additionalDensity;
        }

        #endregion // Constructors
    }
}
