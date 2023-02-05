using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class FileManager
    {
        public string FilePath { get; set; } = string.Empty;

        public string Read()
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                try
                {
                    using var sr = new StreamReader(FilePath);
                    return sr.ReadToEnd();
                }
                catch { }
            }
            return string.Empty;
        }

        public void Save(string content)
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                using var sw = new StreamWriter(FilePath);
                sw.Write(content);
            }
        }
    }
}
