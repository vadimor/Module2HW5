using System;

namespace Module2HW1
{
    public class Actions
    {
        private readonly Logger _logger;
        public Actions()
        {
            _logger = Logger.Instance;
        }

        public Result InfoLog()
        {
            _logger.Log(TypeLog.Info, $"Start method: {nameof(InfoLog)}");
            return new Result { Status = true };
        }

        public Result WarningLog()
        {
            _logger.Log(TypeLog.Warning, $"Skipped logic in method: {nameof(WarningLog)}");
            return new Result { Status = true };
        }

        public Result ErrorLog() => new Result { ErrorMessage = "I broke a logic" };
    }
}
