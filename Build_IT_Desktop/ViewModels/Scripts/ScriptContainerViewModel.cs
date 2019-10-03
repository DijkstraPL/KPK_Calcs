using Build_IT_Desktop.Models.Resources;
using Prism.Mvvm;

namespace Build_IT_Desktop.ViewModels.Scripts
{
    public class ScriptContainerViewModel : BindableBase
    {
        private ScriptResource _scriptResource;

        public string ScriptName => _scriptResource.Name;
        public string ScriptDescription => _scriptResource.Description;

        public ScriptContainerViewModel(ScriptResource scriptResource)
        {
            _scriptResource = scriptResource;
        }

    }
}
