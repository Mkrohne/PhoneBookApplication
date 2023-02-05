namespace ConsoleApp.Services
{
    public class FileService
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

        public void Save(string contacts)
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                using var sw = new StreamWriter(FilePath);
                sw.Write(contacts);
            }
        }
    }
}
