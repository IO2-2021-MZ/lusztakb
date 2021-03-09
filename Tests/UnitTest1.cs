using NUnit.Framework;
using System;

namespace StringCalculator.Test
{
    public class CalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmptyStringReturnZero()
        {
            Calculator calculator = new Calculator();
            string input = "";
            int expectedOutput = 0;
            int output = calculator.Add(input);

            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void SingleNumberReturnsValue()
        {
            Calculator calculator = new Calculator();
            string input = "7";
            int expectedOutput = 7;
            int output = calculator.Add(input);

            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void TwoNumbersCommaDelimitedReturnsTheSum()
        {
            Calculator calculator = new Calculator();
            string input = "7,23";
            int expectedOutput = 30;
            int output = calculator.Add(input);

            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void TwoNumbersNewlineDelimitedReturnsTheSum()
        {
            Calculator calculator = new Calculator();
            string input = "7\n33";
            int expectedOutput = 40;
            int output = calculator.Add(input);

            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void ThreeNumbersCommaDelimitedReturnsTheSum()
        {
            Calculator calculator = new Calculator();
            string input = "7,23,30";
            int expectedOutput = 60;
            int output = calculator.Add(input);

            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void ThreeNumbersNewlineDelimitedReturnsTheSum()
        {
            Calculator calculator = new Calculator();
            string input = "7\n33\n10";
            int expectedOutput = 50;
            int output = calculator.Add(input);

            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void ThreeNumbersNewlineCommaDelimitedReturnsTheSum()
        {
            Calculator calculator = new Calculator();
            string input = "7\n33,17,3\n10";
            int expectedOutput = 70;
            int output = calculator.Add(input);

            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void NegativeNumbersThrowAnException()
        {
            Calculator calculator = new Calculator();
            string input = "-20,20\n-44";
            try
            {
                int output = calculator.Add(input);
                Assert.Fail();
            }
            catch (Exception e)
            {

                Assert.AreEqual(e.Message, "Negative number");
            }
        }

        [Test]
        public void NumbersGreaterThan1000AreIgnored()
        {
            Calculator calculator = new Calculator();
            string input = "5,10000\n30";
            int expectedOutput = 35;
            int output = calculator.Add(input);

            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void SingleCharDelimeterCanBeDefinedOnTheFirstLine()
        {
            Calculator calculator = new Calculator();
            string input = "//#\n5,100#100\n30";
            int expectedOutput = 235;
            int output = calculator.Add(input);

            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void MultiCharDelimeterCanBeDefinedOnTheFirstLine()
        {
            Calculator calculator = new Calculator();
            string input = "//[bbb]\n5,100bbb100\n30";
            int expectedOutput = 235;
            int output = calculator.Add(input);

            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void ManySingleOrMultiCharDelimitersCanBeDefined()
        {
            Calculator calculator = new Calculator();
            string input = "//[bbb][aaa]\n5,100bbb100aaa215\n30";
            int expectedOutput = 450;
            int output = calculator.Add(input);

            Assert.AreEqual(expectedOutput, output);
        }


    }
}