namespace Module2HW5.Service.Abstract
{
    public interface IFileService
    {
        public void Write(string path, string text);
        public string Read(string path);
    }
}
