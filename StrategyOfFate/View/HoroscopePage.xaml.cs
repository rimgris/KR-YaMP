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
    /// Логика взаимодействия для HoroscopePage.xaml
    /// </summary>
    public partial class HoroscopePage : Page
    {
        public HoroscopePage()
        {
            InitializeComponent();
            Navigator.NavigationService.LoadCompleted += OnNavigationCompleted;
        }

        private void OnNavigationCompleted(object sender, NavigationEventArgs e)
        {
            var data = (SignInformation)e.ExtraData;
            ParagraphsItemsControl.ItemsSource = data.Paragraphs;
            SignTextblock.Text = data.Name;
        }

        private void OnReturnClick(object sender, RoutedEventArgs e)
        {
            Navigator.NavigationService.LoadCompleted -= OnNavigationCompleted;
            NavigationService.Navigate(new Uri("View/HoroscopesListPage.xaml", UriKind.Relative));
        }

    }
}
