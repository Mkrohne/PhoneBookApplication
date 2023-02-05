using ConsoleApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Tests__MSTest
{
    [TestClass]
    public class FileManagerTests
    {
        [TestMethod]
        public void Should_Create_a_File_With_Json_Content()
        {
            //arrange
            FileManager fileManager = new FileManager();
            fileManager.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
            string content = JsonConvert.SerializeObject(new { FirstName = "Marcus", LastName = "Krohné" });

            //act
            fileManager.Save(content);
            string result = fileManager.Read();

            //assert
            Assert.IsTrue(File.Exists(fileManager.FilePath));
            Assert.AreEqual(content, result);

        }
    }
}
