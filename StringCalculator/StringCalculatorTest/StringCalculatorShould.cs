using StringCalculatorKata;
using Xunit;

namespace StringCalculatorTest
{
    public class StringCalculatorShould
    {
        [Fact]
        public void Add_WhenStringIsEmpty_ReturnZero()
        {
            var stringCalculator = new StringCalculator();
            Assert.Equal(0, stringCalculator.Add(""));
        }
    }
}
