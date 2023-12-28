using Adressbok_Shared.Interface;
using Adressbok_Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok_App.Tests;

public class FileService_Tests
{

    [Fact]

    public void SaveToFileShould_SaveContentToFile_ReturnTrue_IfFilePathExists()
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

    [Fact]

    public void SaveToFileShould_ReturnFalse_IfFilePathDoNotExists()
    {
        //Arrange
        IFileService fileService = new FileService();
        string filePath = @$"C:\IT_kurser\Kurser\Webbutveckling-dotnet\CSharp\{Guid.NewGuid()}\test.txt";
        string content = "Test content";


        //Act
        bool result = fileService.SaveContentToFile(content, filePath);

        //Assert
        Assert.False(result);
    }
}
