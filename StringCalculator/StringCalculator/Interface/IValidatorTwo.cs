using System.Collections.Generic;

namespace StringCalculatorKata.Interface
{
    public interface IValidatorTwo
    {
        List<int> IgnoreBigNumbers(List<int> numbers, int ceilingThreshold);
        void NegativeCheck(List<int> numbers);
    }
}