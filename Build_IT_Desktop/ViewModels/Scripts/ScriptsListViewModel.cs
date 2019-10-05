using Build_IT_Desktop.Data.ScriptRepository.Scripts.Queries;
using Build_IT_Desktop.Models;
using Build_IT_Desktop.Models.Resources;
using Newtonsoft.Json;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_Desktop.ViewModels.Scripts
{
    public class ScriptsListViewModel : BindableBase
    {
        private IContainerExtension _container;

        private IEnumerable<ScriptContainerViewModel> _scripts;
        public IEnumerable<ScriptContainerViewModel> Scripts
        {
            get { return _scripts; }
            set { SetProperty(ref _scripts, value); }
        }

        public ScriptsListViewModel(IContainerExtension container)
        {
            _container = container;

            var allScriptsQuery = _container.Resolve<GetAllScriptsQuery>();

            Task.Factory.StartNew(async () =>
            {
                var scripts = await allScriptsQuery.Execute();
                Scripts = new List<ScriptContainerViewModel>(scripts.Select(s => 
                    _container.Resolve<ScriptContainerViewModel>((typeof(ScriptResource), s))));
            });
        }
    }
}
