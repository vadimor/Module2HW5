using System;
using System.IO;

namespace Module2HW5.Service.Abstract
{
    public interface IFileWorkingService : IDisposable
    {
        public void Create(string path);
        public void Delete(string path);
        public void Write(string path, string text);
        public string Read(string path);

        public string[] GetFiles(string path);
        public string GetDirectoryByFilePath(string path);
    }
}
