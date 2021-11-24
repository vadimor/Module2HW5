using System.IO;

namespace Module2HW1
{
    public class FileManager
    {
        public void Write(string filePath, string text)
        {
            File.WriteAllText(filePath, text);
        }
    }
}
