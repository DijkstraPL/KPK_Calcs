using Build_IT_Desktop.Data.ScriptRepository.Calculators;
using Build_IT_Desktop.Data.ScriptRepository.Calculators.Queries;
using Build_IT_Desktop.Data.ScriptRepository.Parameters.Queries;
using Build_IT_Desktop.Models.Resources;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_Desktop.ViewModels.Scripts
{
    public class ScriptFormViewModel : BindableBase
    {
        private ScriptResource _selectedScript;
        public ScriptResource SelectedScript
        {
            get => _selectedScript;
            set
            {
                SetProperty(ref _selectedScript, value);
                ScriptChanged(this, EventArgs.Empty);
            }
        }

        private IEnumerable<ParameterViewModel> _parameterViewModels;
        public IEnumerable<ParameterViewModel> ParameterViewModels
        {
            get { return _parameterViewModels; }
            set { SetProperty(ref _parameterViewModels, value); }
        }
        
        private IEnumerable<ParameterResource> _calculatedParameters;
        public IEnumerable<ParameterResource> CalculatedParameters
        {
            get { return _calculatedParameters; }
            set { SetProperty(ref _calculatedParameters, value); }
        }


        public DelegateCommand CalculateCommand { get; }


        private IContainerExtension _container;




        public event Func<object, EventArgs, Task> ScriptChanged;

        public ScriptFormViewModel(IContainerExtension container)
        {
            _container = container;

            CalculateCommand = new DelegateCommand(async () => await Calculate());

            ScriptChanged += (s, e) => SetParameters();
        }

        private async Task SetParameters()
        {
            CalculatedParameters = null;

            var getAllParametersForScriptQuery = _container.Resolve<GetAllEdiitableParametersForScriptQuery>((typeof(long), SelectedScript.Id));
            var parameters = await getAllParametersForScriptQuery.Execute();
            ParameterViewModels = new List<ParameterViewModel>(parameters.Select(p =>
                _container.Resolve<ParameterViewModel>((typeof(ParameterResource), p))));
        }

        private async Task Calculate()
        {
            var parameters = ParameterViewModels.Select(pvm => pvm.ParameterResource).ToList();
            var calculateQuery = _container.Resolve<CalculateQuery>(
                (typeof(long), _selectedScript.Id), (typeof(List<ParameterResource>), parameters));

            CalculatedParameters = await calculateQuery.Execute();
        }
    }
}
