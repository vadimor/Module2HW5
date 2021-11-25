using System;

namespace Module2HW5.Service.Abstract
{
    public interface IJsonService
    {
        public object Deserialization(string path, Type type);
    }
}
