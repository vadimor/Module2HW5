using Microsoft.Extensions.DependencyInjection;
using Module2HW5.Service.Abstract;
using Module2HW5.Service;
using Module2HW5.Provider.Abstract;
using Module2HW5.Provider;

namespace Module2HW5
{
    public class Starter
    {
        public void Start()
        {
            var start = new ServiceCollection()
                .AddTransient<IFileService, FIleService>()
                .AddSingleton<IFileWorkingService, FileWorkingService>()
                .AddSingleton<ILoggerService, LoggerService>()
                .AddSingleton<IConfigService, ConfigService>()
                .AddTransient<IConfigProvider, ConfigProvice>()
                .AddSingleton<IJsonService, JsonService>()
                .AddTransient<IActionsService, ActionsService>()
                .AddTransient<Application>()
                .BuildServiceProvider();
            var app = start.GetService<Application>();
            app.Run();
            start.Dispose();
        }
    }
}
