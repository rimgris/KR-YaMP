using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyOfFate
{
    class YearBasedHoroscope : Horoscope
    {
        public YearBasedHoroscope(string id)
        {
            Id = id;
        }

        public override bool IsSignMatchesDate(Dictionary<string, string> parameters, DateTime birthDate)
        {
            var bYear = birthDate.Year;
            var baseYear = Convert.ToInt32(parameters["BaseYear"]);
            var step = Convert.ToInt32(parameters["Step"]);
            return PredictionSelectorHelper.GetYearAstrolgicalIndex(bYear, baseYear, step) == 0;
        }

    }
}
