using System;
using Module2HW5.Model;
using Module2HW5.Service.Abstract;

namespace Module2HW5.Service
{
    public class LoggerService : ILoggerService
    {
        private readonly IFileService _fileService;
        private readonly IConfigService _configService;
        private string _timeFormat;
        private string _path;
        public LoggerService(IFileService fileService, IConfigService configService)
        {
            _fileService = fileService;
            _configService = configService;
            Init();
        }

        public void Log(TypeLog typeLog, string message)
        {
            var consoleMessage = $"{DateTime.UtcNow.ToString(_timeFormat)}: {typeLog}: {message}";
            _fileService.Write(_path, consoleMessage);
            Console.WriteLine(consoleMessage);
        }

        public void LogInfo(string message)
        {
            Log(TypeLog.Info, message);
        }

        public void LogWarning(string message)
        {
            Log(TypeLog.Warning, message);
        }

        private void Init()
        {
            var config = _configService.GetConfig();
            _timeFormat = config.LoggerServiceConfig.TimeFormat;
            var fileExtension = config.LoggerServiceConfig.FileExtension;
            var directoryPath = config.LoggerServiceConfig.DirectoryPath;
            var timeFormatFileName = config.LoggerServiceConfig.TimeFormatFileName;
            _path = directoryPath + DateTime.UtcNow.ToString(timeFormatFileName) + fileExtension;
        }
    }
}
