using ConsoleApp.Models;
using ConsoleApp.Services;
using Newtonsoft.Json;

namespace ConsoleApp.Tests__nUnit
{
    public class FileManager_Tests
    {
        FileManager fileManager;
        string content;

        [SetUp]
        public void Setup()
        {
            //arrange
            fileManager = new FileManager();
            fileManager.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
            content = JsonConvert.SerializeObject(new { FirstName = "Marcus", LastName = "Krohné" });


        }

        [Test]
        public void Should_Create_a_File_With_Json_Content()
        {
            //act
            fileManager.Save(content);
            string result = fileManager.Read();

            //assert
            Assert.IsTrue(File.Exists(fileManager.FilePath));
            Assert.That(result.Trim(), Is.EqualTo(content.Trim()));            
        }
    }
}
