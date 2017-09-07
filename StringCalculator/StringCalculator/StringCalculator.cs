using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using StringCalculatorKata.Interface;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private string[] Delimiters { get; set; }
        private IValidatorOne ValidatorOne { get; set; }
        private IValidatorTwo ValidatorTwo { get; set; }


        public StringCalculator()
        {
            Delimiters = new string[] { "," };
            ValidatorOne = new ValidatorOne(1000);
            ValidatorTwo = new ValidatorTwo();
        }

        public StringCalculator(string[] delimiters)
        {
            Delimiters = delimiters;
            ValidatorOne = new ValidatorOne(1000);
            ValidatorTwo = new ValidatorTwo();
        }

        public StringCalculator(string[] delimiters, IValidatorOne validatorOne, IValidatorTwo validatorTwo)
        {
            Delimiters = delimiters;
            ValidatorOne = validatorOne;
            ValidatorTwo = validatorTwo;
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
                sequencedNumbers = lines[1];
            }
            else if (sequencedNumbers.StartsWith("//\n"))
            {
                sequencedNumbers = sequencedNumbers.Substring(3);
                Delimiters = new[] { "\n" };
            }

            numbers = sequencedNumbers.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();


            //ValidatorOne.Validate(numbers);

            ValidatorTwo.NegativeCheck(numbers);
            ValidatorTwo.IgnoreBigNumbers(numbers, 1000);

            return numbers.Sum();
        }

        private string[] GetDelimiters(string[] lines)
        {
            var delimiter = lines[0].Substring(2);

            if (delimiter.Contains("[") && delimiter.Contains("]"))
            {
                var pattern = @"\[(.*?)\]";

                return Regex.Matches(delimiter, pattern).Cast<Match>().Select(m => m.Groups[1].Value).ToArray();
            }
            return delimiter.Split();
        }
    }
}
