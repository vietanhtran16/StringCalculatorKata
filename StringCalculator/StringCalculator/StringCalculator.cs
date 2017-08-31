using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private char[] Delimiters { get; set; }
        private Validator Validator { get; set; }

        public StringCalculator()
        {
            Delimiters = new char[] {','};
            Validator = new Validator();
        }

        public StringCalculator(char[] delimiters)
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
                Delimiters = lines[0].Substring(2).ToCharArray();
                numbers = lines[1].Split(Delimiters).Select(int.Parse).ToList();
            }
            else if (sequencedNumbers.StartsWith("//\n"))
            {
                // TODO Handle new line delimiters
            }
            else
            {
                numbers = sequencedNumbers.Split(Delimiters).Select(int.Parse).ToList();
            }
            Validator.NegativeCheck(numbers);
            return numbers.Sum();
        }
    }
}
