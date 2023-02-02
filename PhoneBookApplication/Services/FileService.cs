using Newtonsoft.Json;
using PhoneBookApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApplication.Services
{

    internal class FileService
    {
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
