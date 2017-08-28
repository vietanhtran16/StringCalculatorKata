using StringCalculatorKata;
using Xunit;

namespace StringCalculatorTest
{
    public class StringCalculatorShould
    {
        [Theory]
        [InlineData(0, "")]
        [InlineData(1, "1")]
        [InlineData(3, "1,2")]
        [InlineData(6, "1,2,3")]
        public void Add_ValidInputs_ReturnSum(int expected, string numbers)
        {
            var stringCalculator = new StringCalculator();
            Assert.Equal(expected, stringCalculator.Add(numbers));
        }
    }
}
