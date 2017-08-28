using StringCalculatorKata;
using Xunit;

namespace StringCalculatorTest
{
    public class StringCalculatorShould
    {
        [Theory]
        [InlineData(0, "")]
        public void Add_ValidInputs_ReturnSum(int expected, string numbers)
        {
            var stringCalculator = new StringCalculator();
            Assert.Equal(expected, stringCalculator.Add(numbers));
        }
    }
}
