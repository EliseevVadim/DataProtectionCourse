using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Utils
{
    public class Languages
    {
        public static Language English => new Language()
        {
            AlphabetLength = 26,
            CapitalLetterOffset = 65,
            LowerLetterOffset = 97
        };

        public static Language Russian => new Language()
        {
            AlphabetLength = 32,
            CapitalLetterOffset = 1040,
            LowerLetterOffset = 1072
        };
    }
}
