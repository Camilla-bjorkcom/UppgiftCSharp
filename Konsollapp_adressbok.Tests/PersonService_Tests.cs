using Adressbok_Shared.Interface;
using Adressbok_Shared.Repository;
using Adressbok_Shared.Services;
using Moq;


namespace Konsollapp_adressbok.Tests;

public class PersonService_Tests
{
    [Fact]
    public void ShowAContactFromListShould_FindAContactFromListWithParamTargetId_ThenReturnNotNull()
    {
        // Arrange
        var mockFileService = new Mock<IFileService>();
        PersonRepository personRepository = new PersonRepository(mockFileService.Object);

        var targetId = 1;
        var mockPerson = new Mock<IPerson>();
        mockPerson.Setup(x => x.Id).Returns(targetId);

        // Set up _contactList with the mock person
        personRepository._contactList = new List<IPerson> { mockPerson.Object };

        // Act
        var result = personRepository._contactList.FirstOrDefault(x => x.Id == targetId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(targetId, result.Id);
    }


        [Fact]
    public void ShowAContactFromListShould_CompareAnIntParamWithPersonIdFromList()
    {
       
        //Arrange
        var mockFileService = new Mock<IFileService>();
        PersonRepository personRepository = new PersonRepository(mockFileService.Object);
        IPersonService personService = new PersonService(personRepository);
        
        var targetId = 1;
        var mockPerson = new Mock<IPerson>();
        var mockAddress = new Mock<IAddress>();
        var mockContactInformation = new Mock<IContactInformation>();
     
        mockPerson.Setup(x => x.YourAddress).Returns(mockAddress.Object);
        mockPerson.Setup(x => x.YourContactInformation).Returns(mockContactInformation.Object);
        mockPerson.Setup(x => x.Id).Returns(targetId);    
        
        personRepository._contactList = new List<IPerson> { mockPerson.Object };

        //Act
        bool result = personService.ShowAContactFromList(1);

        //Assert
        Assert.True(result);

    }
}
