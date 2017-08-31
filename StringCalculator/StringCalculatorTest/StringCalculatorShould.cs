using System;
using System.Security.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorKata;
using Xunit;
using Assert = Xunit.Assert;

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

        [Fact]
        public void Add_NewLineDelimiter()
        {
            var delimiters = new[] {',', '\n'};
            var stringCalculator = new StringCalculator(delimiters);
            Assert.Equal(6, stringCalculator.Add("1\n2,3"));
        }

        [Fact]
        public void Add_CustomDelimiter()
        {
            var stringCalculator = new StringCalculator();
            Assert.Equal(3, stringCalculator.Add("//;\n1;2"));
        }

        [Theory]
        [ExpectedException(typeof(NegativeNumberException))]
        [InlineData("negatives not allowed -1", "-1")]
        public void Add_WithNegativeNumbers(string expected, string numbers)
        {
            var stringCalculator = new StringCalculator();
            var exception = Assert.Throws<NegativeNumberException>(() => stringCalculator.Add(numbers));
            Assert.Equal(expected, exception.Message);
        }
    }
}
