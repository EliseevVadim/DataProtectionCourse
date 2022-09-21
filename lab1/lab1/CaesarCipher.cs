using lab1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class CaesarCipher
    {
        private Language _language;

        public CaesarCipher(Language language)
        {
            _language = language;
        }

        public string Encrypt(string lineToEncrypt, int offset)
        {
            char[] letters = lineToEncrypt.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if (Char.IsUpper(letters[i]))
                    letters[i] = (char)(PreventFromZero((letters[i] - _language.CapitalLetterOffset + offset) % _language.AlphabetLength) + _language.CapitalLetterOffset);
                else if (Char.IsLower(letters[i]))
                    letters[i] = (char)(PreventFromZero((letters[i] - _language.LowerLetterOffset + offset) % _language.AlphabetLength) + _language.LowerLetterOffset);
            }
            return new string(letters);
        }

        public string DecryptWithASpecificOffset(string lineToDecrypt, int offset)
        {
            char[] letters = lineToDecrypt.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if (Char.IsUpper(letters[i]))
                    letters[i] = (char)(PreventFromNegative((letters[i] - _language.CapitalLetterOffset - offset) % _language.AlphabetLength) + _language.CapitalLetterOffset);
                else if (Char.IsLower(letters[i]))
                    letters[i] = (char)(PreventFromNegative((letters[i] - _language.LowerLetterOffset - offset) % _language.AlphabetLength) + _language.LowerLetterOffset);
            }
            return new string(letters);
        }

        public string[] DecryptWithUnknownOffset(string lineToDecrypt)
        {
            string[] possibleAnswers = new string[_language.AlphabetLength];
            for (int i = 1; i < _language.AlphabetLength + 1; i++)
            {
                possibleAnswers[i - 1] = DecryptWithASpecificOffset(lineToDecrypt, i);
            }
            return possibleAnswers;
        }

        private int PreventFromNegative(int value)
        {
            return value > 0 ? value : _language.AlphabetLength + value;
        }

        private int PreventFromZero(int value)
        {
            return value == 0 ? _language.AlphabetLength : value;
        }
    }
}
