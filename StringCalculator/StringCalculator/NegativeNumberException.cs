using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorKata
{
    public class NegativeNumberException : Exception
    {

        public NegativeNumberException(string message) : base(message)
        {
        }

    }
}
