using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyOfFate
{
    public interface IPredictionProvider
    {

        string GetPredictionByBirthDate(); 

    }
}
