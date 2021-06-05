using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyOfFate
{

    struct YearDay
    {
        public int Day, Month;

        public YearDay (int day, int month)
        {
            Day = day;
            Month = month;
        }

    }

    struct YearDayRange
    {
        public YearDay Begin, End;

        public YearDayRange (YearDay begin, YearDay end)
        {
            End = end;
            Begin = begin;
        }

    }
}
