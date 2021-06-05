using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для DatePage.xaml
    /// </summary>
    public partial class DatePage : Page
    {
        public DatePage()
        {
            InitializeComponent();
        }

        private void OnReturnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/HomePage.xaml", UriKind.Relative));
        }

        private void OnSaveClick(object sender, RoutedEventArgs e)
        {
            var subs = DateTextBox.Text.Split('/');
            Properties.Settings.Default.BirthDate = 
                new DateTime(Convert.ToInt32(subs[2]),
                             Convert.ToInt32(subs[1]), 
                             Convert.ToInt32(subs[0]));
            NavigationService.Navigate(new Uri("View/HomePage.xaml", UriKind.Relative));
        }

        private void OnPreviewDateTextInput(object sender, TextCompositionEventArgs e)
        {
            var r = new Regex(@"[^0-9/]+");
            if (r.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }

        private void OnDateTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateForDateFormat();
        }

        private void UpdateForDateFormat()
        {
            if (SaveButton == null) { return; }
            SaveButton.IsEnabled = CheckDateFormat();
        }

        private bool CheckDateFormat()
        {
             return new Regex(@"[0-9]{2}\/[0-9]{2}\/[0-9]{4}").IsMatch(DateTextBox.Text);
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            var bDate = Properties.Settings.Default.BirthDate;
            if (bDate == DateTime.MinValue)
            {
                ReturnButton.Visibility = Visibility.Collapsed;
                DateTextBox.Text = "xx/xx/xxxx";
            } else
            {
                ReturnButton.Visibility = Visibility.Visible;
                DateTextBox.Text = string.Format("{0}/{1}/{2}", bDate.Day.ToString("00"), bDate.Month.ToString("00"), bDate.Year.ToString("0000"));
            }
            UpdateForDateFormat();
        }

        private void OnDateTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (DateTextBox.Text == "xx/xx/xxxx")
            {
                DateTextBox.Text = "";
            }
        }

        private void OnDateTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (!CheckDateFormat())
            {
                DateTextBox.Text = "xx/xx/xxxx";
            }
        }
    }
}
