using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StrategyOfFate
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void OnSignsClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/HoroscopesListPage.xaml", UriKind.Relative));
        }

        private void OnSettingsClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/DatePage.xaml", UriKind.Relative));
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            PredictionTextBlock.Text = App.GetInstance().PredictionProvider.GetPredictionByBirthDate();
            LuckyNumberTextBlock.Text = PredictionSelectorHelper.GetLuckyNumber(Properties.Settings.Default.BirthDate).ToString();
        }
    }
}
