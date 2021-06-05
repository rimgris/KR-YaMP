using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyOfFate
{
    public abstract class Horoscope
    {

        public string Id { get; set; }
        public abstract bool IsSignMatchesDate(Dictionary<string, string> parameters, DateTime birthDate);

    }
}
