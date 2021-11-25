using Module2HW5.Model;

namespace Module2HW5.Service.Abstract
{
    public interface ILoggerService
    {
        public void Log(TypeLog typeLog, string message);
        public void LogInfo(string message);
        public void LogWarning(string message);
    }
}
