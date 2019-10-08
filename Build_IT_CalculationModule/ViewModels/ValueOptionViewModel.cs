using Build_IT_Infrastructure.Models;

namespace Build_IT_CalculationModule.ViewModels
{
    public class ValueOptionViewModel
    {
        #region Properties
        
        public string Name => _valueOptionResource.Name;
        public string Value => _valueOptionResource.Value;

        #endregion // Properties

        #region Fields

        private readonly ValueOptionResource _valueOptionResource;

        #endregion // Fields

        #region constructors
        
        public ValueOptionViewModel(ValueOptionResource valueOptionResource)
        {
            _valueOptionResource = valueOptionResource;
        }

        #endregion // constructors
    }
}