using Build_IT_Desktop.Models.Resources;

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

        public ParameterResource ParameterResource { get; }

        public ParameterViewModel(ParameterResource parameterResource)
        {
            ParameterResource = parameterResource;
        }

    }
}