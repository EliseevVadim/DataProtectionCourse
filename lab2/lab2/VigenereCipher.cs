using lab2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class VigenereCipher
    {
        private Language _language;

        public VigenereCipher(Language language)
        {
            _language = language;
        }

        public Language Language { get => _language; set => _language = value; }

        public string Encrypt(string lineToEncrypt, string key)
        {
            char[] lineToEncryptLetters = lineToEncrypt.ToCharArray();
            char[] keyLetters = DuplicateKey(key.ToLower(), lineToEncrypt).ToCharArray();
            for (int i = 0; i < lineToEncryptLetters.Length; i++)
            {
                lineToEncryptLetters[i] = AddLetters(lineToEncryptLetters[i], keyLetters[i]);
            }
            return new string(lineToEncryptLetters);
        }

        public string Decrypt(string lineToDecrypt, string key)
        {
            char[] lineToDecryptLetters = lineToDecrypt.ToCharArray();
            char[] keyLetters = DuplicateKey(key.ToLower(), lineToDecrypt).ToCharArray();
            for (int i = 0; i < lineToDecryptLetters.Length; i++)
            {
                lineToDecryptLetters[i] = SubtractLetters(lineToDecryptLetters[i], keyLetters[i]);
            }
            return new string(lineToDecryptLetters);
        }

        private char AddLetters(char plainTextLetter, char keyLetter)
        {
            if (Char.IsUpper(plainTextLetter))
                return (char)PreventFromZero((plainTextLetter - _language.CapitalLetterOffset + keyLetter - _language.LowerLetterOffset) % _language.AlphabetLength + _language.CapitalLetterOffset);
            else if (Char.IsLower(plainTextLetter))
                return (char)PreventFromZero((plainTextLetter - _language.LowerLetterOffset + keyLetter - _language.LowerLetterOffset) % _language.AlphabetLength + _language.LowerLetterOffset);
            return plainTextLetter;
        }

        private char SubtractLetters(char plainTextLetter, char keyLetter)
        {
            if (Char.IsUpper(plainTextLetter))
                return (char)(PreventFromNegative((plainTextLetter - _language.CapitalLetterOffset - keyLetter + _language.LowerLetterOffset) % _language.AlphabetLength) + _language.CapitalLetterOffset);            
            else if (Char.IsLower(plainTextLetter))
                return (char)(PreventFromNegative((plainTextLetter - _language.LowerLetterOffset - keyLetter + _language.LowerLetterOffset) % _language.AlphabetLength) + _language.LowerLetterOffset);
            return plainTextLetter;
        }

        private string DuplicateKey(string key, string processingLine)
        {
            return string.Concat(Enumerable.Repeat(key, processingLine.Length)).Substring(0, processingLine.Length);
        }

        private int PreventFromNegative(int value)
        {
            return value >= 0 ? value : _language.AlphabetLength + value;
        }

        private int PreventFromZero(int value)
        {
            return value == 0 ? _language.AlphabetLength : value;
        }
    }
}
