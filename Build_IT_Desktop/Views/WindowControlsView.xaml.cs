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
    /// Interaction logic for WindowControlsView.xaml
    /// </summary>
    public partial class WindowControlsView : UserControl
    {
        private Window _window;

        public WindowControlsView()
        {
            InitializeComponent();

            this.Loaded += WindowControlsView_Loaded;
        }

        private void WindowControlsView_Loaded(object sender, RoutedEventArgs e)
        {
            _window = Window.GetWindow(this);
        }

        private void SpecialMinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            _window.WindowState = WindowState.Minimized;
        }

        private void AdjustWindowSizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (_window.WindowState == WindowState.Maximized)
            {
                _window.WindowState = WindowState.Normal;
                Maximize.Visibility = Visibility.Visible;
                Restore.Visibility = Visibility.Collapsed;
            }
            else
            {
                _window.MaxHeight = SystemParameters.WorkArea.Height + 9;
                _window.WindowState = WindowState.Maximized;

                Maximize.Visibility = Visibility.Collapsed;
                Restore.Visibility = Visibility.Visible;
            }
        }

        private void SpecialCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            _window.Close();
        }
    }
}
