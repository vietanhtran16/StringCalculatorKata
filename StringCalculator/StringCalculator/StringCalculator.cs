using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private char[] Delimiters { get; }

        public StringCalculator()
        {
            Delimiters = new char[] { ',' };
        }

        public StringCalculator(char[] delimiters)
        {
            Delimiters = delimiters;
        }

        public int Add(string sequencedNumbers)
        {
            if (string.IsNullOrEmpty(sequencedNumbers))
                return 0;
            var numbers = sequencedNumbers.Split(Delimiters).Select(int.Parse).ToList();
            return numbers.Sum();
        }
    }
}
