using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyOfFate
{
    class RangeBasedHoroscope : Horoscope
    {

        public RangeBasedHoroscope(string id)
        {
            Id = id;
        }

        public override bool IsSignMatchesDate(Dictionary<string, string> parameters, DateTime birthDate)
        {
            var beginParams = parameters["From"].Split('.');
            var endParams = parameters["To"].Split('.');
            var beginYearDay = new YearDay(Convert.ToInt32(beginParams[0]), Convert.ToInt32(beginParams[1]));
            var endYearDay = new YearDay(Convert.ToInt32(endParams[0]), Convert.ToInt32(endParams[1]));
            var birthYearDay = new YearDay(birthDate.Day, birthDate.Month);
            var signDayRange = new YearDayRange(beginYearDay, endYearDay);
            return PredictionSelectorHelper.CheckIsYearDayInRange(signDayRange, birthYearDay);
        }
    }
}
