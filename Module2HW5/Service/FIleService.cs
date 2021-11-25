using System;
using System.Collections;
using Module2HW5.Helper;
using Module2HW5.Service.Abstract;

namespace Module2HW5.Service
{
    public class FIleService : IFileService
    {
        private const int _maxNumberFile = 3;
        private readonly IFileWorkingService _fileWorkingService;
        private readonly IComparer _fileLogComparer;

        public FIleService(IFileWorkingService fileWorkingService)
        {
            _fileLogComparer = new LogFileComparer();
            _fileWorkingService = fileWorkingService;
        }

        public string Read(string path)
        {
            return _fileWorkingService.Read(path);
        }

        public void Write(string path, string text)
        {
            _fileWorkingService.Write(path, text);
            NormalizationNumberOfFiles(path);
        }

        public void NormalizationNumberOfFiles(string path)
        {
            var directory = _fileWorkingService.GetDirectoryByFilePath(path);
            var files = _fileWorkingService.GetFiles(directory);
            if (files.Length <= _maxNumberFile)
            {
                return;
            }

            Array.Sort(files, _fileLogComparer);
            for (var i = 0; i < files.Length - _maxNumberFile; i++)
            {
                _fileWorkingService.Delete(files[i]);
            }
        }
    }
}
