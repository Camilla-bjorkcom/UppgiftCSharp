

using Konsollapp_adressbok.Interface;
using Konsollapp_adressbok.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Konsollapp_adressbok.Services;

internal class PersonService
{
    private readonly List<IPerson> contactList = new List<IPerson>();
    private readonly FileService _fileService = new FileService(@"C:\IT_kurser\Kurser\Webbutveckling-dotnet\CSharp\C-SharpUppgift\content.json");
    public void AddNewContact()
    {
        PersonModel person = new PersonModel();
        AddressModel address = new AddressModel();
        person.YourAddress = address;

        ContactInformationModel contactInfo = new ContactInformationModel();
        person.YourContactInformation = contactInfo;



        person.Id = contactList.Count + 1;

        Console.Write("Skriv in förnamn: ");
        person.FirstName = Console.ReadLine()!;

        Console.Write("Skriv in efternamn: ");
        person.LastName = Console.ReadLine()!;

        Console.Write("Skriv in Email: ");
        person.YourContactInformation.Email = Console.ReadLine()!;

        Console.Write("Skriv in telefonnummer: ");
        person.YourContactInformation.PhoneNumber = Console.ReadLine()!;

        Console.Write("Skriv in gatuadress: ");
         person.YourAddress.StreetName = Console.ReadLine()!;

        Console.Write("Skriv in postnummer: ");
        person.YourAddress.PostalCode = Console.ReadLine()!;

        Console.Write("Skriv in postort: ");
        person.YourAddress.City = Console.ReadLine()!;

        Console.Write("Skriv in land: ");
        person.YourAddress.Country = Console.ReadLine()!;


        AddPersonToList(person);
        


    }


    

    public void AddPersonToList(IPerson person)
    {


        try
        {
               contactList.Add(person);
               _fileService.SaveContentToFile(JsonConvert.SerializeObject(contactList));
         }
 

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
    
        }
    
    }


    public void ShowAllContacts()
    {
        foreach (var contact in contactList)
        {
            Console.WriteLine($"Kontakt: {contact.FirstName} {contact.LastName} {contact.Id} {contact.YourAddress.StreetName}");
        }
        Console.ReadKey();
        
    }

    //public IEnumerable<PersonModel> ShowAllContacts() 
    //{ 
    //    return contactList;
    //}

}
