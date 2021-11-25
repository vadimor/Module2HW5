using System;
using Module2HW5.Service.Abstract;
using Module2HW5.Exceptions;

namespace Module2HW5.Service
{
    public class ActionsService : IActionsService
    {
        private readonly ILoggerService _logger;

        public ActionsService(ILoggerService loggerService)
        {
            _logger = loggerService;
        }

        public bool MethodInfo()
        {
            _logger.LogInfo($"Start method: {nameof(MethodInfo)}");
            return true;
        }

        public bool MethodWarning()
        {
            throw new BusinessException($"Skipped logic in method: {nameof(MethodWarning)}");
        }

        public bool MethodError()
        {
            throw new Exception("I broke a logic");
        }
    }
}
