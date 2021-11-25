using System;
using System.IO;
using Module2HW5.Service.Abstract;
using Module2HW5.Model;

namespace Module2HW5.Service
{
    public class FileWorkingService : IFileWorkingService
    {
        private StreamWriterInfo[] _arrayStreamWriterInfo;
        private bool _disposed;
        public FileWorkingService()
        {
            _arrayStreamWriterInfo = new StreamWriterInfo[0];
        }

        ~FileWorkingService()
        {
            foreach (var item in _arrayStreamWriterInfo)
            {
                item.Stream.Flush();
                item.Stream.Close();
                item.Stream.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            foreach (var item in _arrayStreamWriterInfo)
            {
                item.Stream.Flush();
                item.Stream.Close();
                item.Stream.Dispose();
            }

            _disposed = true;
            GC.SuppressFinalize(this);
        }

        public void Create(string path)
        {
            File.Create(path);
        }

        public void Delete(string path)
        {
            File.Delete(path);
        }

        public string[] GetFiles(string path)
        {
            return Directory.GetFiles(path);
        }

        public string Read(string path)
        {
            return File.ReadAllText(path);
        }

        public void Write(string path, string text)
        {
            CheckOrCreateDirectory(GetDirectoryByFilePath(path));
            var stream = CreateStreamWriter(path);
            stream.WriteLine(text);
        }

        public string GetDirectoryByFilePath(string path)
        {
            var splitPath = path.Split("/");
            var sizeFileName = splitPath[splitPath.Length - 1].Length;
            return path.Substring(0, path.Length - sizeFileName);
        }

        private void CheckOrCreateDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                return;
            }

            Directory.CreateDirectory(path);
        }

        private StreamWriter CreateStreamWriter(string path)
        {
            foreach (var item in _arrayStreamWriterInfo)
            {
                if (item.Path.EndsWith(path) || path.EndsWith(item.Path))
                {
                    return item.Stream;
                }
            }

            var newSreamWriter = new StreamWriter(path, true);
            AddStream(path, newSreamWriter);
            return newSreamWriter;
        }

        private void AddStream(string path, StreamWriter streamWriter)
        {
            var newArray = new StreamWriterInfo[_arrayStreamWriterInfo.Length + 1];
            for (var i = 0; i < _arrayStreamWriterInfo.Length; i++)
            {
                newArray[i] = _arrayStreamWriterInfo[i];
            }

            newArray[newArray.Length - 1] = new StreamWriterInfo { Path = path, Stream = streamWriter };
            _arrayStreamWriterInfo = newArray;
        }
    }
}
