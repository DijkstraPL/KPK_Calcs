using Build_IT_CalculationModule;
using Build_IT_Desktop.Views;
using Build_IT_Infrastructure.Data.ScriptRepository.Parameters.Queries;
using Build_IT_Infrastructure.Data.ScriptRepository.Scripts.Queries;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;

namespace Build_IT_Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        #region Protected_Methods
        
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var unityContainer = Container.GetContainer();

            unityContainer.RegisterTypeForNavigation<GetAllScriptsQuery>();
            unityContainer.RegisterTypeForNavigation<GetAllEdiitableParametersForScriptQuery>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<CalculationModule>();
        }

        #endregion // Protected_Methods
    }
}
