
namespace Adressbok_Shared.Interface;

public interface IFileService
{
    string GetContentFromFile(string filePath);
    bool SaveContentToFile(string content, string filePath);
}