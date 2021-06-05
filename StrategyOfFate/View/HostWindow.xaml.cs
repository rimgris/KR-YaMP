using System;
using System.Windows;

namespace StrategyOfFate
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnMinimizeClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void OnNormalMaximizeClick(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

        private void OnCloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnWindowStateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                MaximizeImage.Visibility = Visibility.Visible;
                NormalImage.Visibility = Visibility.Collapsed;
                ExternalBorder.Margin = new Thickness(5, 5, 5, 0);
            }
            else
            {
                MaximizeImage.Visibility = Visibility.Collapsed;
                NormalImage.Visibility = Visibility.Visible;
                ExternalBorder.Margin = new Thickness(0);
            }
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.BirthDate == DateTime.MinValue)
            {
                PageFrame.NavigationService.Navigate(new Uri("View/DatePage.xaml", UriKind.Relative));
            }
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
