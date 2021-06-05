using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StrategyOfFate
{
    static class PredictionSelectorHelper
    {

        public static bool CheckIsYearDayInRange(YearDayRange range, YearDay day)
        {
            return CheckIsYearDayInRange(range.Begin.Day, range.Begin.Month, range.End.Day, range.End.Month, day.Day, day.Month);
        }

        public static bool CheckIsYearDayInRange(int startDay, int startMonth, int endDay, int endMonth, int day, int month)
        {
            var lowerBorder = new DateTime(1932, startMonth, startDay);
            var upperBorder = new DateTime(1932, endMonth, endDay);
            var x = new DateTime(1932, month, day);

            return (lowerBorder <= x) && (upperBorder >= x);
        }

        public static int GetYearAstrolgicalIndex(int year, int baseYear, int step)
        {
            return (year - baseYear) % step;
        }

        public static int GetLuckyNumber(DateTime birthDate)
        {
            var r = new Regex("[0-9]");
            var ms = r.Matches(birthDate.Year.ToString("0000") + birthDate.Day.ToString("00") + birthDate.Month.ToString("00"));
            int sum = 0;
            foreach(Match m in ms)
            {
                sum += Convert.ToInt32(m.Value);
            }
            while (sum > 9)
            {
                int tSum = 0;
                ms = r.Matches(sum.ToString());
                foreach (Match m in ms)
                {
                    tSum += Convert.ToInt32(m.Value);
                }
                sum = tSum;
            }
            return sum;
        }

    }
}
