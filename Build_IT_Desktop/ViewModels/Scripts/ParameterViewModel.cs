using Build_IT_Desktop.Models.Resources;
using System.Collections.Generic;
using System.Linq;

namespace Build_IT_Desktop.ViewModels.Scripts
{
    public class ParameterViewModel
    {
        public string ParameterName => ParameterResource.Name;
        public string ParameterValue
        {
            get => ParameterResource.Value;
            set { ParameterResource.Value = value; }
        }
        public IEnumerable<ValueOptionViewModel> ValueOptions { get; set; }

        public ParameterResource ParameterResource { get; }

        public ParameterViewModel(ParameterResource parameterResource)
        {
            ParameterResource = parameterResource;

            ValueOptions = ParameterResource.ValueOptions?.Select(vo => new ValueOptionViewModel(vo));
        }

    }

    public class ValueOptionViewModel
    {
        private readonly ValueOptionResource _valueOptionResource;

        public string Name => _valueOptionResource.Name;
        public string Value => _valueOptionResource.Value;

        public ValueOptionViewModel(ValueOptionResource valueOptionResource)
        {
            _valueOptionResource = valueOptionResource;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}