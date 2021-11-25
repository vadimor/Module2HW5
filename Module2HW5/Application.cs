using System;

using Module2HW5.Service.Abstract;
using Module2HW5.Exceptions;
using Module2HW5.Model;

namespace Module2HW5
{
    public class Application
    {
        private readonly Random _random;
        private readonly IActionsService _actionsService;
        private readonly ILoggerService _logger;
        public Application(IActionsService actionsService, ILoggerService loggerService, IFileWorkingService fileWorkingService)
        {
            _actionsService = actionsService;
            _logger = loggerService;
            _random = new Random();
        }

        public void Run()
        {
            for (var i = 0; i < 100; i++)
            {
                try
                {
                    switch (_random.Next(0, 3))
                    {
                        case 0:
                            _actionsService.MethodInfo();
                            break;
                        case 1:
                            _actionsService.MethodWarning();
                            break;
                        case 2:
                            _actionsService.MethodError();
                            break;
                    }
                }
                catch (BusinessException ex)
                {
                    _logger.LogWarning($"Action got this custom Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    _logger.Log(TypeLog.Error, $"Action failed by reason: {ex}");
                }
            }
        }
    }
}
