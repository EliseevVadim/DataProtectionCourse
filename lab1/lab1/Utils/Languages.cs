using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Utils
{
    public class Languages
    {
        public static Language English => new Language()
        {
            AlphabetLength = 26,
            CapitalLetterOffset = 64,
            LowerLetterOffset = 96
        };

        public static Language Russian => new Language()
        {
            AlphabetLength = 32,
            CapitalLetterOffset = 1039,
            LowerLetterOffset = 1071
        };
    }
}
