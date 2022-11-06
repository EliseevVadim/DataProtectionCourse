using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class PermutationsCipher
    {
        private string _key;

        public PermutationsCipher(string key)
        {
            _key = key;
        }

        public string Key { get => _key; set => _key = value; }

        public string Encrypt(string lineToEncrypt)
        {
            string preparedKey = PrepareKey();
            string sortedKey = String.Concat(preparedKey.OrderBy(symbol => symbol));
            List<int> sequence = preparedKey.Select(symbol => sortedKey.IndexOf(symbol)).ToList();
            string trimmedLineToEncrypt = String.Concat(lineToEncrypt.Split(' '));
            string[] parts = SplitByCount(trimmedLineToEncrypt, preparedKey.Length);
            List<string> results = new List<string>();
            List<string> temps = new List<string>();
            for (int i = 0; i < parts.Length; i++)
            {
                int size = i * sequence.Count + sequence.Count >= parts.Length ? parts.Length - i * sequence.Count : sequence.Count;
                if (size < 0)
                    break;
                for (int j = i * sequence.Count; j < i * sequence.Count + size; j++)
                {
                    string addition = sequence
                         .Zip(parts[j], (index, symbol) => new { index, symbol })
                         .OrderBy(element => element.index)
                         .Aggregate(string.Empty, (line, element) => line + element.symbol);
                    temps.Add(addition);
                }
                temps = TransposeStrings(temps);
                results.AddRange(temps);
                temps.Clear();
            }
            return string.Join(' ', results);  
        }

        public string Decrypt(string lineToDecrypt)
        {
            string preparedKey = PrepareKey();
            string sortedKey = String.Concat(preparedKey.OrderBy(symbol => symbol));
            List<int> sequence = preparedKey.Select(symbol => sortedKey.IndexOf(symbol)).ToList();
            List<string> temps = new List<string>();
            List<string> preparedData = new List<string>();
            List<char> tempChars = new List<char>();
            string[] parts = lineToDecrypt.Split(' ');
            for (int i = 0; i < parts.Length; i++)
            {
                int size = i * sequence.Count + sequence.Count >= parts.Length ? parts.Length - i * sequence.Count : sequence.Count;
                if (size < 0)
                    break;
                for (int j = i * sequence.Count; j < i * sequence.Count + size; j++)
                {
                    temps.Add(parts[j]);
                }
                temps = TransposeStrings(temps);
                for (int k = 0; k < temps.Count; k++)
                {
                    try
                    {
                        temps[k] = temps[k]
                            .Zip(sequence, (symbol, index) => new { symbol, index })
                            .Aggregate(string.Empty, (line, element) => line + temps[k][element.index]);
                    }
                    catch(IndexOutOfRangeException) 
                    {
                        int[] remainSequence = TruncateAndScaleSequence(sequence, temps[k].Length);
                        temps[k] = temps[k]
                            .Zip(remainSequence, (symbol, index) => new { symbol, index })
                            .Aggregate(string.Empty, (line, element) => line + temps[k][element.index]);
                    }
                }
                preparedData.AddRange(temps);
                temps.Clear();
            }
            return String.Concat(preparedData);
        }

        private string PrepareKey()
        {
            return String.Concat(String.Concat(_key.Trim().ToLower().Split(' ')).Distinct());
        }

        private string[] SplitByCount(string text, int count)
        {
            List<string> result = Enumerable.Range(0, text.Length / count)
                .Select(i => text.Substring(i * count, count))
                .ToList();
            result.Add(text.Substring(text.Length / count * count, text.Length % count));
            return result
                .Where(item => !string.IsNullOrEmpty(item))
                .ToArray();
        }

        private List<string> TransposeStrings(List<string> source)
        {          
            if (source.Count <= 1)
                return source;
            List<string> result = new List<string>();
            string temp = string.Empty;
            for (int i = 0; i < source[0].Length; i++)
            {
                for (int j = 0; j < source.Count; j++)
                {
                    try
                    {
                        temp += source[j][i];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }
                }
                result.Add(temp);
                temp = string.Empty;
            }
            return result;
        }

        private int[] TruncateAndScaleSequence(List<int> sequence, int count)
        {
            int[] remainSequence = sequence.Take(count).ToArray();
            List<int> sortedSequence = remainSequence.OrderBy(element => element).ToList();
            int[] result = remainSequence.Select(element => sortedSequence.IndexOf(element)).ToArray();
            return result;
        }
    }
}
