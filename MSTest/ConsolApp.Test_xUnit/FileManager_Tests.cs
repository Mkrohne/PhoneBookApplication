using ConsoleApp.Services;
using Newtonsoft.Json;


namespace ConsolApp.Test_xUnit
{
    public class FileManager_Tests
    {
        FileManager fileManager;
        string content;

        public FileManager_Tests()
        {
            //arrange
            fileManager = new FileManager();
            fileManager.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\pbList.json";
            content = JsonConvert.SerializeObject(new { FirstName = "Marcus", LastName = "Krohné", PhoneNumber = "0738048834", Adress = "Parkvägen 25, 694 35, Hallsberg", Email = "marcuskrohne@gmail.com" });
        }

        [Fact]
        public void Should_Create_a_File_With_Json_Content()
        {
            //act
            fileManager.Save(content);
            string result = fileManager.Read();

            //assert
            Assert.True(File.Exists(fileManager.FilePath));
            Assert.Equal(result.Trim(), content);

        }
    }
}
