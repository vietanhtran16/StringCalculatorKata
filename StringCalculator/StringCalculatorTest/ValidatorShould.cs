using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorKata;
using Xunit;
using Assert = Xunit.Assert;

namespace StringCalculatorTest
{
    public class ValidatorShould
    {
        [Fact]
        [ExpectedException(typeof(NegativeNumberException))]
        public void NegativeCheck_WithMultiNegativeNumbers()
        {
            var validator = new Validator();

            var numbers = new List<int>(){ -1, 2, -3 };
            var expected = "negatives not allowed -1,-3";
            var exception = Assert.Throws<NegativeNumberException>(() => validator.NegativeCheck(numbers));
            Assert.Equal(expected, exception.Message);

            numbers = new List<int>() { -1 };
            expected = "negatives not allowed -1";
            exception = Assert.Throws<NegativeNumberException>(() => validator.NegativeCheck(numbers));
            Assert.Equal(expected, exception.Message);

            numbers = new List<int>() { -1,-2 };
            expected = "negatives not allowed -1,-2";
            exception = Assert.Throws<NegativeNumberException>(() => validator.NegativeCheck(numbers));
            Assert.Equal(expected, exception.Message);

            numbers = new List<int>() { -1, 2, -3 };
            expected = "negatives not allowed -1,-3";
            exception = Assert.Throws<NegativeNumberException>(() => validator.NegativeCheck(numbers));
            Assert.Equal(expected, exception.Message);
        }

        [Fact]
        public void IgnoreBigNumbers_WithNumberOver1k()
        {
            var validator = new Validator();
            
            var numbers = new List<int>(){999, 1000, 1001};
            var expected = new List<int>() {999, 1000};
            var actual = validator.IgnoreBigNumbers(numbers, 1000);
            Assert.Equal(expected, actual);
        }
    }
}
