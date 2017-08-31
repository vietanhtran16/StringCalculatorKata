using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculatorKata
{
    public class Validator
    {


        //public List<int> IsDataValid()
        //{
        //    Remove


        //    return null;
        //}


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
