using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyOfFate
{
    class DoubleRangeBasedHoroscope : Horoscope
    {
        public DoubleRangeBasedHoroscope(string id)
        {
            Id = id;
        }

        public override bool IsSignMatchesDate(Dictionary<string, string> parameters, DateTime birthDate)
        {
            var range1Params = parameters["Range1"].Split('-');
            var range2Params = parameters["Range2"].Split('-');
            var range1BeginParams = range1Params[0].Split('.');
            var range2BeginParams = range2Params[0].Split('.');
            var range1EndParams = range1Params[1].Split('.');
            var range2EndParams = range2Params[1].Split('.');

            var beginYearDay1 = new YearDay(Convert.ToInt32(range1BeginParams[0]), Convert.ToInt32(range1BeginParams[1]));
            var endYearDay1 = new YearDay(Convert.ToInt32(range1EndParams[0]), Convert.ToInt32(range1EndParams[1]));
            var beginYearDay2 = new YearDay(Convert.ToInt32(range2BeginParams[0]), Convert.ToInt32(range2BeginParams[1]));
            var endYearDay2 = new YearDay(Convert.ToInt32(range2EndParams[0]), Convert.ToInt32(range2EndParams[1]));
            var birthYearDay = new YearDay(birthDate.Day, birthDate.Month);
            var signDayRange1 = new YearDayRange(beginYearDay1, endYearDay1);
            var signDayRange2 = new YearDayRange(beginYearDay2, endYearDay2);
            return PredictionSelectorHelper.CheckIsYearDayInRange(signDayRange1, birthYearDay) || PredictionSelectorHelper.CheckIsYearDayInRange(signDayRange2, birthYearDay);
        }
    }
}
