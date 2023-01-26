using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class FileService
    {
        private string _filePath;

        public FileService(string filePath)
        {
            _filePath = filePath;
        }

        public void Save(string content)
        {
            try
            {
                using var sw = new StreamWriter(_filePath);
                sw.WriteLine(content);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
        }

        public string Read()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    using var sr = new StreamReader(_filePath);
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }

            return string.Empty;
        }
    }
}
