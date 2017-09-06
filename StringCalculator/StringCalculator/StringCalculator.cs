using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private string[] Delimiters { get; set; }
        private Validator Validator { get; set; }

        public StringCalculator()
        {
            Delimiters = new string[] { "," };
            Validator = new Validator();
        }

        public StringCalculator(string[] delimiters)
        {
            Delimiters = delimiters;
            Validator = new Validator();
        }

        public int Add(string sequencedNumbers)
        {
            if (string.IsNullOrEmpty(sequencedNumbers))
                return 0;

            List<int> numbers = null;

            if (sequencedNumbers.StartsWith("//") && !sequencedNumbers.StartsWith("//\n"))
            {
                var lines = sequencedNumbers.Split('\n');
                Delimiters = GetDelimiters(lines);
                numbers = lines[1].Split(Delimiters, StringSplitOptions.None).Select(int.Parse).ToList();
            }
            else if (sequencedNumbers.StartsWith("//\n"))
            {
                // TODO Handle new line delimiters
            }
            else
            {
                numbers = sequencedNumbers.Split(Delimiters, StringSplitOptions.None).Select(int.Parse).ToList();
            }
            Validator.NegativeCheck(numbers);
            return numbers.Sum();
        }

        private string[] GetDelimiters(string[] lines)
        {
            var delimiter = lines[0].Substring(2);

            if (!delimiter.Contains("[")) return delimiter.Split();
            var pattern = @"\[(.*?)\]";

            return Regex.Matches(delimiter, pattern).Cast<Match>().Select(m => m.Groups[1].Value).ToArray();
        }
    }
}
