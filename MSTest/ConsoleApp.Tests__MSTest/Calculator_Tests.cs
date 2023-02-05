using ConsoleApp.Services;

namespace ConsoleApp.Tests__MSTest
{
    [TestClass]
    public class Calculator_Tests
    {
        [TestMethod]
        public void Should_Add_GivenNumber_To_Total()
        {
            //Arrange - f�rberedelser
            Calculator calculator = new Calculator();
            calculator.Total = 0m;

            //Act - utf�randet
            calculator.Add(100.0m);

            //Assert utv�rderingen
            Assert.AreEqual(100m, calculator.Total);
        }
        [TestMethod]
        public void Should_Subtract_GivenNumber_From_Total()
        {
            //Arrange - f�rberedelser
            Calculator calculator = new Calculator();
            calculator.Total = 100m;

            //Act - utf�randet
            calculator.Subtract(50.0m);

            //Assert utv�rderingen
            Assert.AreEqual(50m, calculator.Total);
        }
    }
}