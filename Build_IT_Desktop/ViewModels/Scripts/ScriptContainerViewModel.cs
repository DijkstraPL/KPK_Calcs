using System;
using Build_IT_Desktop.Data.ScriptRepository.Parameters.Queries;
using Build_IT_Desktop.Models.Resources;
using Build_IT_Desktop.Views.Scripts;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;

namespace Build_IT_Desktop.ViewModels.Scripts
{
    public class ScriptContainerViewModel : BindableBase
    {
        public string ScriptName => _scriptResource.Name;
        public string ScriptDescription => _scriptResource.Description;
        public DelegateCommand SetScriptCommand { get; }

        private readonly ScriptResource _scriptResource;
        private readonly IContainerExtension _container;
        private readonly ScriptFormViewModel _scriptFormViewModel;

        public ScriptContainerViewModel(IContainerExtension container, ScriptResource scriptResource)
        {
            _scriptResource = scriptResource;
            _container = container;
            _scriptFormViewModel = _container.Resolve<ScriptFormViewModel>();

            SetScriptCommand = new DelegateCommand(SetScript);
        }

        private void SetScript()
        {
            _scriptFormViewModel.SelectedScript = _scriptResource;
        }
    }
}
