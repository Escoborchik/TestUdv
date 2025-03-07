namespace TestUdv.Core.Interfaces
{
    public interface IFileLogging
    {
        Task WriteEndLogAsync();
        Task WriteStartLogAsync();
    }
}