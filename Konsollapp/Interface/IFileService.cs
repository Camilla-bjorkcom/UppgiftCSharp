namespace Konsollapp_adressbok.Interface
{
    public interface IFileService
    {
        string GetContentFromFile();
        bool SaveContentToFile(string content);
    }
}