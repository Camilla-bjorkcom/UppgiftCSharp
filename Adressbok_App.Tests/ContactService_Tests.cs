using Adressbok_Shared.Models;
using Adressbok_Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok_App.Tests;

public class ContactService_Tests
{

    [Fact]
    public void AddShould_AddOneContactToContactList_ThenReturnTrue()
    {
        //Arrange
        Contact contact = new Contact { FirstName = "Camilla", Email= "hej.com"};
        ContactService contactService = new ContactService();


        //Act
        bool result = contactService.Add(contact);
       

        //Assert
        Assert.True(result);

    }
}
