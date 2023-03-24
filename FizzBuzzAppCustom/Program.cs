using System;
using System.Collections.Generic;
using TwistedFizzBuzz;

namespace FizzBuzzAppCustom
{
   internal class Program
    {
        static void Main(string[] args)
        {
            TwistedFizzBuzz.TwistedFizzBuzz twistedFizzBuzz = new TwistedFizzBuzz.TwistedFizzBuzz();

            int start = 1;
            int end = 50;

            List<TwistedFizzBuzz.FizzBuzzToken> tokens= new List<FizzBuzzToken> { 
                new FizzBuzzToken { Multiple = 5, Word = "Fizz" }, new FizzBuzzToken { Multiple = 9, Word = "Buzz" }, new FizzBuzzToken { Multiple = 27, Word = "Bar" } };

            string output = twistedFizzBuzz.GetFizzBuzz(start, end, tokens);

            Console.WriteLine(output);

            Console.ReadKey();
        }
    }
}
