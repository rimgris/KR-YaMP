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
    /// Логика взаимодействия для HoroscopesListPage.xaml
    /// </summary>
    public partial class HoroscopesListPage : Page
    {
        public HoroscopesListPage()
        {
            InitializeComponent();
        }
        

        private void OnReturnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/HomePage.xaml", UriKind.Relative));
        }

        private void OnDruidClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/HoroscopePage.xaml", UriKind.Relative),
               App.GetInstance().HoroDataProvider.GetSignInformation(new DoubleRangeBasedHoroscope("Druid")));
        }

        private void OnFlowerClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/HoroscopePage.xaml", UriKind.Relative),
               App.GetInstance().HoroDataProvider.GetSignInformation(new RangeBasedHoroscope("Flower")));
        }

        private void OnIndianClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/HoroscopePage.xaml", UriKind.Relative),
               App.GetInstance().HoroDataProvider.GetSignInformation(new RangeBasedHoroscope("Indian")));
        }

        private void OnChineeseClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/HoroscopePage.xaml", UriKind.Relative),
   App.GetInstance().HoroDataProvider.GetSignInformation(new YearBasedHoroscope("Chinese")));
        }

        private void OnJapaneseClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/HoroscopePage.xaml", UriKind.Relative),
               App.GetInstance().HoroDataProvider.GetSignInformation(new YearBasedHoroscope("Japanese")));
        }

        private void OnNumerologicalClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/HoroscopePage.xaml", UriKind.Relative),
               App.GetInstance().HoroDataProvider.GetSignInformation(new NumerologicalHoroscope("Numerologic")));
        }

        private void OnZodiacClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/HoroscopePage.xaml", UriKind.Relative),
                           App.GetInstance().HoroDataProvider.GetSignInformation(new RangeBasedHoroscope("Zodiac")));
        }

        private void OnZoroClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/HoroscopePage.xaml", UriKind.Relative),
   App.GetInstance().HoroDataProvider.GetSignInformation(new YearBasedHoroscope("Zoro")));
        }
    }
}
