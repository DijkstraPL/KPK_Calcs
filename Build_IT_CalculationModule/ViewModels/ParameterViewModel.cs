using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace Build_IT_CalculationModule.ViewModels
{
    public class ParameterViewModel
    {
        #region Properties
        
        public string ParameterName => ParameterResource.Name;
        public string ParameterValue
        {
            get => ParameterResource.Value;
            set { ParameterResource.Value = value; }
        }
        public IEnumerable<ValueOptionViewModel> ValueOptions { get; }

        public bool IsEditable => (ParameterResource.ValueOptionSetting & ValueOptionSettings.UserInput) != 0;
        public bool ContainsValueOptions => ParameterResource.ValueOptions?.Count > 0;

        public ParameterResource ParameterResource { get; }

        #endregion // Properties

        #region Constructors
        
        public ParameterViewModel(ParameterResource parameterResource)
        {
            ParameterResource = parameterResource;

            ValueOptions = ParameterResource.ValueOptions?.Select(vo => new ValueOptionViewModel(vo));
        }

        #endregion // Constructors

    }
}