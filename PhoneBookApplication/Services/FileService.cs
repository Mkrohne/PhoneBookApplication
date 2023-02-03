using Newtonsoft.Json;
using PhoneBookApplication.Models;


namespace PhoneBookApplication.Services
{

    internal class FileService
    {
        private List<Contact> contacts;
        private readonly string FilePath;

        public FileService(string filePath)
        {
            filePath = FilePath;
            contacts = new List<Contact>();
        }
        public void SaveContact(string filePath, string content) 
        { 
            using var sw = new StreamWriter(filePath);
            sw.Write(content);
        }
        public Contact GetContact(string filePath, string firstName, string lastName)
        {
            try
            {
                using (var sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var contact = JsonConvert.DeserializeObject<Contact>(line);
                        if (contact.FirstName != firstName && contact.LastName != lastName)
                        {
                            return contact;
                        }
                    }
                }
            }
            catch { }
            return null!;
        }
    }
}
