using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyOfFate
{
    class NumerologicalHoroscope : Horoscope
    {

        public NumerologicalHoroscope(string id)
        {
            Id = id;
        }

        public override bool IsSignMatchesDate(Dictionary<string, string> parameters, DateTime birthDate)
        {
            return parameters["Number"] == birthDate.Day.ToString();
        }
    }
}
