using Module2HW5.Model;
using Module2HW5.Service.Abstract;
using Module2HW5.Provider.Abstract;

namespace Module2HW5.Service
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigProvider _configProvider;
        private readonly Config _config;
        public ConfigService(IConfigProvider configProvider)
        {
            _configProvider = configProvider;
            _config = _configProvider.GetConfig();
        }

        public Config GetConfig()
        {
            return _config;
        }
    }
}
