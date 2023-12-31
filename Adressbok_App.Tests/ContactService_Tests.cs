using Adressbok_Shared.Interface;
using Adressbok_Shared.Services;
using Moq;

namespace Adressbok_App.Tests;

public class ContactService_Tests
{

    [Fact]
    public void AddShould_AddOneContactToContactList_ThenReturnTrue()
    {
        //Arrange
        var mockContact = new Mock<IContact>();

        //IContact contact = new Contact { FirstName = "Camilla", Email= "hej.com"};

        var mockFileService = new Mock<IFileService>();
        ContactService contactService = new ContactService(mockFileService.Object);


        //Act
        bool result = contactService.Add(mockContact.Object);
       

        //Assert
        Assert.True(result);

    }
}
