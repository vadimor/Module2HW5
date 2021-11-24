using System;

namespace Module2HW1
{
    public class Starter
    {
        private readonly Random _random;
        private readonly Actions _actions;
        private readonly FileManager _fileManager;
        private readonly Logger _logger;

        public Starter()
        {
            _random = new Random();
            _actions = new Actions();
            _fileManager = new FileManager();
            _logger = Logger.Instance;
        }

        public void Run()
        {
            var result = new Result();
            for (var i = 0; i < 100; i++)
            {
                switch (_random.Next(0, 3))
                {
                    case 0:
                        result = _actions.InfoLog();
                        break;
                    case 1:
                        result = _actions.WarningLog();
                        break;
                    case 2:
                        result = _actions.ErrorLog();
                        break;
                }

                if (!result.Status)
                {
                    _logger.Log(TypeLog.Error, $"Action failed by a reason: {result.ErrorMessage}");
                }
            }

            _fileManager.Write("log.txt", _logger.LogHistory);
        }
    }
}
