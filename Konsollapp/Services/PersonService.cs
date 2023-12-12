

using Konsollapp_adressbok.Interface;
using Konsollapp_adressbok.Models;
using Konsollapp_adressbok.Repository;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Konsollapp_adressbok.Services;


public class PersonService : IPersonService
{
    private readonly PersonRepository _personRepository;

    public PersonService(PersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    //private List<IPerson> _contactList = new List<IPerson>();
    private readonly IFileService _fileService;

    public PersonService(IFileService fileService)
    {
        _fileService = fileService;
    }

    public void AddNewContact()
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

       _personRepository.AddToList(person);

    }
    public void SaveToFile()
    {
        IServiceResult response = new ServiceResult();
        _fileService.SaveContentToFile(JsonConvert.SerializeObject(_personRepository._contactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All
}),@"C:\IT_kurser\Kurser\Webbutveckling-dotnet\CSharp\C-SharpUppgift\content.json");
                response.Status = Enums.ServiceStatus.SUCCEDED;
                Console.WriteLine("Sparat ned i listan");
                Console.ReadKey();
    }
   

    public IServiceResult DeleteContactFromList(string targetEmail)
    {
        IServiceResult response = new ServiceResult();
        IPerson person = new PersonModel();


        _personRepository._contactList.RemoveAll(person => person.YourContactInformation.Email == targetEmail);
        response.Status = Enums.ServiceStatus.SUCCEDED;
        
        return response;
    }

    public IServiceResult ShowAContactFromList(int targetId)
    {
        IServiceResult response = new ServiceResult();
        {
            foreach (var person in _personRepository._contactList)
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
            if (_personRepository._contactList.Count != 0)
            {

                foreach (var contact in _personRepository._contactList.Distinct())
                {
                    Console.WriteLine($"Kontakt: {contact.Id}");
                    Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine(); // Tom rad för att separera varje kontakt i utskriften
                }
                Console.ReadKey();
                response.Status = Enums.ServiceStatus.SUCCEDED;
                response.Result = _personRepository._contactList;

                Console.WriteLine("Skriv in numret på kontakten för att se detaljerad information: ");
                int.TryParse(Console.ReadLine(), out int targetId);

                ShowAContactFromList(targetId);
                Console.ReadKey();
            }
            else 
            {
                Console.WriteLine("No person in the list");
                Console.ReadKey();
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


    public  IEnumerable<IPerson> GetPersonList()
    {
       
        try
        {
            var content = _fileService.GetContentFromFile(@"C:\IT_kurser\Kurser\Webbutveckling-dotnet\CSharp\C-SharpUppgift\content.json");
            if (!string.IsNullOrEmpty(content))
            {
                _personRepository._contactList = JsonConvert.DeserializeObject<List<IPerson>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All})!;
                return _personRepository._contactList;
            }
           
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }



}
