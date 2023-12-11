

using Konsollapp_adressbok.Interface;
using Konsollapp_adressbok.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Konsollapp_adressbok.Services;


public class PersonService : IPersonService
{

    private List<IPerson> _contactList = new List<IPerson>();
    private readonly IFileService _fileService = new FileService(@"C:\IT_kurser\Kurser\Webbutveckling-dotnet\CSharp\C-SharpUppgift\content.json");
  
    public IServiceResult AddNewContact()
    {
        IServiceResult response = new ServiceResult();
        IPerson person = new PersonModel();


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

       
        var result = AddPersonToList(person);
        if (result.Status == Enums.ServiceStatus.SUCCEDED)
        {
            Console.WriteLine("The person was added successfully");
            person.Id = _contactList.Count + 1;
            response.Status = Enums.ServiceStatus.SUCCEDED;
        }
        else if (result.Status == Enums.ServiceStatus.ALREADY_EXISTS)
        {
            Console.WriteLine("The person already exists in contactlist");
        }
        else
        {
            Console.WriteLine("Failed when trying to add the person to the list");
            Console.WriteLine("See error message :: " + result.Result.ToString());
        }
        Console.ReadKey();
        return response;

    }

    public IServiceResult DeleteContactFromList(string targetEmail)
    {
        IServiceResult response = new ServiceResult();
        IPerson person = new PersonModel();


        _contactList.RemoveAll(person => person.YourContactInformation.Email == targetEmail);
        response.Status = Enums.ServiceStatus.SUCCEDED;
        
        return response;
    }

    public IServiceResult ShowAContactFromList(int targetId)
    {
        IServiceResult response = new ServiceResult();
        {
            foreach (var person in _contactList)
            {
                if (person.Id == targetId)
                {
                    Console.WriteLine($"Detaljer för person med ID {targetId}:");
                    Console.WriteLine($"Namn: {person.FirstName} {person.LastName}");
                    Console.WriteLine($"Adress: {person.YourAddress.StreetName} {person.YourAddress.PostalCode} {person.YourAddress.Country}");
                    Console.WriteLine($"Telefon: {person.YourContactInformation.PhoneNumber}");
                    Console.WriteLine($"E-post: {person.YourContactInformation.Email}");
                    // Lägg till ytterligare information om det behövs
                }
                else
                {
                    Console.WriteLine($"Person med ID {targetId} hittades inte.");
                }
            }
        }

        return response;
    }

    public IServiceResult ShowAllContacts()
    {
        IServiceResult response = new ServiceResult();

        try
        {
            if (_contactList != null)
            {

                foreach (var contact in _contactList.Distinct())
                {
                    Console.WriteLine($"Kontakt: {contact.Id}");
                    Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine(); // Tom rad för att separera varje kontakt i utskriften
                }
                Console.ReadKey();
                response.Status = Enums.ServiceStatus.SUCCEDED;
                response.Result = _contactList;

                Console.WriteLine("Skriv in numret på kontakten för att se detaljerad information: ");
                int.TryParse(Console.ReadLine(), out int targetId);

                ShowAContactFromList(targetId);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("no person in the list");
            }

        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.Status = Enums.ServiceStatus.FAILED;
            //skickar med felmeddelandet
            response.Result = ex.Message;

        }
        return response;

    }


    public IServiceResult AddPersonToList(IPerson person)
    {
        IServiceResult response = new ServiceResult();
        try
        {
            if (!_contactList.Any(x => x.YourContactInformation.Email == person.YourContactInformation.Email))
            {
            _contactList.Add(person);
            _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contactList));
                response.Status = Enums.ServiceStatus.SUCCEDED;
            }

            else
            {
                response.Status = Enums.ServiceStatus.ALREADY_EXISTS;
            }

        }


        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.Status = Enums.ServiceStatus.FAILED;
            //skickar med felmeddelandet
            response.Result = ex.Message;

        }

        return response;

    }




    //public IEnumerable<PersonModel> ShowAllContacts() 
    //{ 
    //    return contactList;
    //}

}
