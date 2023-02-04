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
            FilePath = filePath;
            contacts = new List<Contact>();
        }
        public void SaveContact(List<Contact> contacts) 
        { 
            using var sw = new StreamWriter(FilePath);
            sw.Write(JsonConvert.SerializeObject(contacts));
        }

        public List<Contact> Read()
        {
            try
            {
                using var sr = new StreamReader(FilePath);
                contacts = JsonConvert.DeserializeObject<List<Contact>>(sr.ReadToEnd())!;
            }
            catch { contacts = new List<Contact>(); }

            return contacts;
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
        public void Delete(string firstName, string lastName)
        {
            try
            {
                var tempFile = Path.GetTempFileName();
                using (var sr = new StreamReader(FilePath))
                using (var sw = new StreamWriter(tempFile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var contact = JsonConvert.DeserializeObject<Contact>(line);
                        if (contact.FirstName != firstName || contact.LastName != lastName)
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
                File.Delete(FilePath);
                File.Move(tempFile, FilePath);
            }
            catch { }
        }
    }
}
