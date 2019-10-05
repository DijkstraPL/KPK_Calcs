using Build_IT_Desktop.Views.Constants;
using Build_IT_Desktop.Views.Scripts;
using Prism.Ioc;
using Prism.Regions;
using System.Windows;

namespace Build_IT_Desktop.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IContainerExtension _container;
        private readonly IRegionManager _regionManager;

        public MainWindow(IContainerExtension container, IRegionManager regionManager)
        {
            InitializeComponent();
            _container = container;
            _regionManager = regionManager;

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var content = _container.Resolve<ScriptsListView>();
            IRegion region = _regionManager.Regions[Regions.CONTENT_REGION];
            region.Add(content);
            
            var headerView = _container.Resolve<HeaderView>();
            IRegion headerRegion = _regionManager.Regions[Regions.HEADER_REGION];
            headerRegion.Add(headerView);
                       
            var detailsView = _container.Resolve<ScriptFormView>();
            IRegion detailsRegion = _regionManager.Regions[Regions.DETAILS_REGION];
            detailsRegion.Add(detailsView);

        }
    }
}
