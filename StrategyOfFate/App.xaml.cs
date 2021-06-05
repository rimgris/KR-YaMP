using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StrategyOfFate
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        public IPredictionProvider PredictionProvider { get; set; }
        public IHoroDataProvider HoroDataProvider { get; set; }

        private static App current;

        public static App GetInstance()
        {
            return current;
        }

        private void OnApplicationStartup(object sender, StartupEventArgs e)
        {
            current = this;
            PredictionProvider = new OnlinePredictionProvider();
            HoroDataProvider = new XMLHoroDataProvider();
        }
    }
}
