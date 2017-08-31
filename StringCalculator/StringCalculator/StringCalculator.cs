using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private char[] Delimiters { get; set; }

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
            int sum;
            sum = AddNumbers(numbers);
            return sum;
        }

        private int AddNumbers(List<int> numbers)
        {
            var sum = 0;
            var negativeNumbers = new List<int>();
            foreach (var number in numbers)
            {
                if (number < 0)
                    negativeNumbers.Add(number);
                else
                {
                    sum += number;
                }


            }
            if (negativeNumbers.Count > 0)
                throw new NegativeNumberException("negatives not allowed " + string.Join(",", negativeNumbers.ToArray()));

            return sum;
        }


    }
}
