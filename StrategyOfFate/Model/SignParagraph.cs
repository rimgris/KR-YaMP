using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyOfFate
{
    public class SignParagraph
    {
        public string Content { get; set; }
        public string Header { get; set; }

        public SignParagraph(string header, string content)
        {
            Content = content;
            Header = header;
        }

    }
}
