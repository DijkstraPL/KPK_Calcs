using Build_IT_Mobile.ViewModels.Scripts;
using Build_IT_Mobile.Views.Scripts;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Build_IT_Mobile
{
    public partial class App : PrismApplication
    {
        #region Constructors

        public App(IPlatformInitializer platformInitializer = null)
            : base(platformInitializer)
        {

        }

        #endregion // Constructors

        #region Protected_Methods

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var unityContainer = Container.GetContainer();

            containerRegistry.RegisterForNavigation<ScriptListPage, ScriptsListViewModel>();

            // containerRegistry.RegisterForNavigation<GetAllScriptsQuery>();
            //unityContainer.RegisterType<GetAllScriptsQuery>();
            //unityContainer.RegisterType<GetAllEditableParametersForScriptQuery>();

        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(new System.Uri("/ScriptListPage", System.UriKind.Absolute));
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //moduleCatalog.AddModule<CalculationModule>();
        }

        #endregion // Protected_Methods
    }
}
