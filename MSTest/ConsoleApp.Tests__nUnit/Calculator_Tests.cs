using ConsoleApp.Services;

namespace ConsoleApp.Tests__nUnit
{
    public class Calculator_Tests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            //arrange
            calculator = new Calculator();
            calculator.Total = 0;
        }

        [Test]
        public void Should_Add_GivenNumber_To_Total()
        {
            //act
            calculator.Add(100);

            //assert

            Assert.That(calculator.Total, Is.EqualTo(100));
        }

        [Test]
        public void Should_Subtract_GivenNumber_From_Total()
        {
            //act
            calculator.Subtract(100);

            //assert

            Assert.That(calculator.Total, Is.EqualTo(-100));
        }


        [TestCase(0.1, 0.1, 0.1, 0.3)]
        [TestCase(1, 2, 3, 6)]
        [TestCase(10, 20, 0.5, 30.5)]
        public void Should_Add_Three_GivenNumbers_To_Total(decimal v1, decimal v2, decimal v3, decimal expected)
        {
            //act
            calculator.Add(v1);
            calculator.Add(v2);
            calculator.Add(v3);

            //assert

            Assert.That(calculator.Total, Is.EqualTo(expected));
        }
    }
}