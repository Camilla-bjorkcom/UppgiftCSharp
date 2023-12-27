

using Adressbok_Shared.Interface;
using Adressbok_Shared.Services;


namespace Konsollapp_adressbok.Tests;

public class FileService_Tests
{
    [Fact]

    public void SaveToFileShould_SaveContentToFile_ThenReturnTrue()
    {
        //Arrange
        IFileService fileService = new FileService();
        string filePath = @"C:\IT_kurser\Kurser\Webbutveckling-dotnet\CSharp\C-SharpUppgift\test.txt";
        string content = "Test content";
        

        //Act
        bool result = fileService.SaveContentToFile(content, filePath);

        //Assert
        Assert.True(result);
    }
}
