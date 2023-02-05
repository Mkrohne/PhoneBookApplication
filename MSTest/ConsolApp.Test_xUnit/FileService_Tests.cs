using ConsoleApp.Services;
using Newtonsoft.Json;


namespace ConsolApp.Test_xUnit
{
    public class FileService_Tests
    {
        FileService fileService;
        string contacts;

        public FileService_Tests()
        {
            //arrange
            fileService = new FileService();
            fileService.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\pbList.json";
            contacts = JsonConvert.SerializeObject(new { FirstName = "Marcus", LastName = "Krohné", PhoneNumber = "0738048834", Adress = "Parkvägen 25, 694 35, Hallsberg", Email = "marcuskrohne@gmail.com" });
        }

        [Fact]
        public void Should_Create_a_File_With_Json_Contacts()
        {
            //act
            fileService.Save(contacts);
            string result = fileService.Read();

            //assert
            Assert.True(File.Exists(fileService.FilePath));
            Assert.Equal(result.Trim(), contacts);

        }
    }
}
