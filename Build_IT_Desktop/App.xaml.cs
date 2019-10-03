using Build_IT_Desktop.Data.ScriptRepository.Scripts.Queries;
using Build_IT_Desktop.Views;
using Prism.Ioc;
using Prism.Unity;
using System.Windows;

namespace Build_IT_Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var unityContainer = Container.GetContainer();

            unityContainer.RegisterTypeForNavigation<GetAllScriptsQuery>();
        }
    }
}
