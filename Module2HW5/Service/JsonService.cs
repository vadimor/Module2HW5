using System;
using Module2HW5.Service.Abstract;
using Newtonsoft.Json;

namespace Module2HW5.Service
{
    public class JsonService : IJsonService
    {
        public object Deserialization(string jsonObj, Type type)
        {
            return JsonConvert.DeserializeObject(jsonObj, type);
        }
    }
}
