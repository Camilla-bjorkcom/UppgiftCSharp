
namespace Adressbok_Shared.Interface;

public interface IFileService
{
    /// <summary>
    /// Get content as string from a specified filepath
    /// </summary>
    /// <param name="filePath">enter the filepath with extension (eg. c:\projects\myfile.json</param>
    /// <returns>returns file content as a string if file exists, else returns null</returns>
    string GetContentFromFile(string filePath);
    
    

    /// <summary>
    /// Save content to a specified filepath
    /// </summary>
    /// <param name="content"> enter your content as a string</param>
    /// <param name="filePath">enter the filepath with extension (eg. c:\projects\myfile.json)</param>
    /// <returns>returns true if saved, else false if failed</returns>
    bool SaveContentToFile(string content, string filePath);
}