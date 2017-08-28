using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {

        public int Add(string sequencedNumbers)
        {
            if (string.IsNullOrEmpty(sequencedNumbers))
                return 0;
            var numbers = sequencedNumbers.Split(',').Select(int.Parse).ToList();
            return numbers.Sum();
        }
    }
}
