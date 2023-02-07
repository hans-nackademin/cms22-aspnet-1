namespace _02_WebAppWithServices.Services
{
    public class FileService
    {
        private string _filePath;
        private Guid _id;


        public FileService(string filePath)
        {
            _filePath = filePath;
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public void Save(string content)
        {
            using var sw = new StreamWriter(_filePath);
            sw.WriteLine(content);
        }

        public string Read()
        {
            if (File.Exists(_filePath))
            {
                using var sr = new StreamReader(_filePath);
                return sr.ReadToEnd();
            }

            return string.Empty;
        }


        public Guid GetId()
        {
            _id = Guid.NewGuid();
            return _id;
        }
    }
}
