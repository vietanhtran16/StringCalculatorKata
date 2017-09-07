using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using StringCalculatorKata.Interface;

namespace StringCalculatorKata
{
    public class ValidatorOne : IValidatorOne
    {
        private int _threshold;
        public ValidatorOne(int threshold)
        {
            _threshold = threshold;
        }

        public List<int> Validate(List<int> numbers)
        {
            NegativeCheck(numbers);
            return IgnoreBigNumbers(numbers, _threshold);
        }

        public List<int> IgnoreBigNumbers(List<int> numbers, int ceilingThreshold)
        {
            return numbers.Where(i => i <= ceilingThreshold).ToList();
        }


        public void NegativeCheck(List<int> numbers)
        {
            if (!numbers.Any(i => i < 0))
                return;

            var negativeNumbers = numbers.Where(i => i < 0).ToArray();

            if (negativeNumbers.Length > 0)
                throw new NegativeNumberException("negatives not allowed " + string.Join(",", negativeNumbers));
        }
    }
}
