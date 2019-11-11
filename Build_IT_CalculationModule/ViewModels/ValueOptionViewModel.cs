using Build_IT_Infrastructure.Models;

namespace Build_IT_CalculationModule.ViewModels
{
    public class ValueOptionViewModel
    {
        #region Properties
        
        public string Name => _valueOptionResource.Name;
        public string Value => _valueOptionResource.Value;

        public bool IsOptionChecked
        {
            get => _parameterControlViewModel.ParameterValue == Value;
            set
            {
                if (value)
                    _parameterControlViewModel.ParameterValue = Value;
            }
        }

        public string ParameterName => _parameterControlViewModel.ParameterName;

        #endregion // Properties

        #region Fields

        private readonly ValueOptionResource _valueOptionResource;
        private readonly ParameterControlViewModel _parameterControlViewModel;

        #endregion // Fields

        #region Constructors

        public ValueOptionViewModel(ValueOptionResource valueOptionResource, ParameterControlViewModel parameterControlViewModel)
        {
            _valueOptionResource = valueOptionResource;
            _parameterControlViewModel = parameterControlViewModel;
        }

        #endregion // Constructors
    }
}