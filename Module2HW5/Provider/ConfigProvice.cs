using Module2HW5.Model;
using Module2HW5.Provider.Abstract;
using Module2HW5.Service.Abstract;

namespace Module2HW5.Provider
{
    public class ConfigProvice : IConfigProvider
    {
        private const string _path = "./config.json";
        private readonly IFileService _fileService;
        private readonly IJsonService _jsonService;

        public ConfigProvice(IFileService fileService, IJsonService jsonService)
        {
            _fileService = fileService;
            _jsonService = jsonService;
        }

        public Config GetConfig()
        {
            var jsonObj = _fileService.Read(_path);
            var config = _jsonService.Deserialization(jsonObj, typeof(Config)) as Config;
            return config;
        }
    }
}
