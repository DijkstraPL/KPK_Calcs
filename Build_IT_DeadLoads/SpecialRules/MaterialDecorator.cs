using Build_IT_DeadLoads.Interfaces;

namespace Build_IT_DeadLoads
{
    public abstract class MaterialDecorator : Material
    {
        #region Properties
        
        public IMaterial Material { get; }

        private readonly string _name;
        public override string Name
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_name))
                    return Material.Name;
                return Material.Name + " - " + _name;
            }
        }

        private double _maximumDensity;
        public sealed override double MaximumDensity
        {
            get => _maximumDensity + Material.MaximumDensity;
            protected set
            {
                _maximumDensity = value;
            }
        }

        private double _minimumDensity;
        public sealed override double MinimumDensity
        {
            get => _minimumDensity + Material.MinimumDensity;
            protected set
            {
                _minimumDensity = value;
            }
        }

        #endregion // Properties

        #region Constructors
        
        public MaterialDecorator(IMaterial material, string name = null)
        {
            _name = name;
            Material = material;
        }

        #endregion // Constructors
    }
}
