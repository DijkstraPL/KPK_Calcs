using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Build_IT_Desktop.Views
{
    /// <summary>
    /// Interaction logic for HeaderView.xaml
    /// </summary>
    public partial class HeaderView : UserControl
    {
        private Window _window;
        private readonly IContainerExtension _container;
        private readonly IRegionManager _regionManager;

        public HeaderView(IContainerExtension container, IRegionManager regionManager)
        {
            InitializeComponent();
            _container = container;
            _regionManager = regionManager;

            this.Loaded += WindowControlsView_Loaded;
        }

        private void WindowControlsView_Loaded(object sender, RoutedEventArgs e)
        {
            _window = Window.GetWindow(this);

            var windowControlsView = _container.Resolve<WindowControlsView>();
            IRegion windowControlsRegion = _regionManager.Regions["WindowControlsRegion"];
            windowControlsRegion.Add(windowControlsView);
        }

        private void Special_DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (_window.WindowState == WindowState.Maximized)
                _window.WindowState = WindowState.Normal;

            _window.DragMove();
        }
    }
}
