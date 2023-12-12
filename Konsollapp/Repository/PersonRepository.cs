using Konsollapp_adressbok.Interface;
using Konsollapp_adressbok.Models;
using Konsollapp_adressbok.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsollapp_adressbok.Repository;

public class PersonRepository
{
    public List<IPerson> _contactList = new List<IPerson>();
    private readonly IPersonService _personService;

    public PersonRepository(IPersonService personService)
    {
        _personService = personService;
    }

    public IServiceResult AddToList (IPerson person)
    {

        IServiceResult response = new ServiceResult();
        try
        {
            if (!_contactList.Any(x => x.YourContactInformation.Email == person.YourContactInformation.Email))
            {
                _contactList.Add(person);
                person.Id = _contactList.Count + 1;
                _personService.SaveToFile();

                Console.WriteLine("The person was added successfully");

                person.Id = _contactList.Count + 1;
                response.Status = Enums.ServiceStatus.SUCCEDED;
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("The person already exists in contactlist");
                response.Status = Enums.ServiceStatus.ALREADY_EXISTS;
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

    
}

