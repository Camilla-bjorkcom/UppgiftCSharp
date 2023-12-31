using Adressbok_Shared.Interface;
using Adressbok_Shared.Models;
using Adressbok_Shared.Repository;
using System.Diagnostics;


namespace Adressbok_Shared.Services;


public class PersonService : IPersonService
{
    // Dependency injection for PersonRepository in the PersonService class.
    private readonly PersonRepository _personRepository;

    // Constructor for PersonService, injecting a PersonRepository instance.
    public PersonService(PersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    //  Dependency injection for IPerson in the PersonService class.
    private readonly IPerson _person;

    // Constructor for PersonService, injecting an IPerson instance.
    public PersonService(IPerson person)
    {
        _person = person;
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

        if (!string.IsNullOrEmpty(person.YourContactInformation.Email))
        {
            _personRepository.AddToList(person);
        }

        else
        {
            Console.WriteLine("Något blev fel, du måste ange en emailadress");
            Console.ReadKey();
        }

    }



    public IServiceResult DeleteContactFromList(string targetEmail)
    {
        IServiceResult response = new ServiceResult();

        try
        {
            _personRepository.GetPersonList();
            _personRepository._contactList.RemoveAll(person => person.YourContactInformation.Email == targetEmail);
            _personRepository.SaveToFile();
            response.Status = Enums.ServiceStatus.SUCCEDED;
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.Status = Enums.ServiceStatus.FAILED;
            response.Result = ex.Message;
        }


        return response;
    }

    public bool ShowAContactFromList(int targetId)
    {

        try
        {
            var targetPerson = _personRepository._contactList.FirstOrDefault(x => x.Id == targetId);

            if (targetPerson != null)
            {
                Console.WriteLine($"Detaljer för person med ID {targetId}:");
                Console.WriteLine($"Namn: {targetPerson.FirstName} {targetPerson.LastName}");
                Console.WriteLine($"Adress: {targetPerson.YourAddress.StreetName} {targetPerson.YourAddress.PostalCode} {targetPerson.YourAddress.City} {targetPerson.YourAddress.Country}");
                Console.WriteLine($"Telefon: {targetPerson.YourContactInformation.PhoneNumber}");
                Console.WriteLine($"E-post: {targetPerson.YourContactInformation.Email}");
                return true;
            }


            else
            {
                Console.WriteLine($"Person med ID {targetId} hittades inte.");
                return false;
            }


        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public IServiceResult ShowAllContacts()
    {
        IServiceResult response = new ServiceResult();

        try
        {
            _personRepository.GetPersonList();
            if (_personRepository._contactList.Count != 0)
            {

                foreach (var contact in _personRepository._contactList)
                {
                    Console.WriteLine($"Kontakt: {contact.Id}");
                    Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine();
                }
                response.Status = Enums.ServiceStatus.SUCCEDED;
                response.Result = _personRepository._contactList;



                Console.WriteLine("Skriv in numret på kontakten för att se detaljerad information eller tryck på valfri knapp för att avbryta: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case var _ when int.TryParse(option, out int targetId):
                        Console.Clear();
                        ShowAContactFromList(targetId);
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Går tillbaks till menyn");
                        Console.ReadKey();
                        break;
                }

            }
            else
            {
                Console.WriteLine("Inga kontakter finns i listan");
                Console.ReadKey();
            }

        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.Status = Enums.ServiceStatus.FAILED;
            response.Result = ex.Message;

        }
        return response;

    }

}
