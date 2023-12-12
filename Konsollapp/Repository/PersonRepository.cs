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

    private readonly IFileService _fileService;

    public PersonRepository(IFileService fileService)
    {
        _fileService = fileService;
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
                SaveToFile();

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



    public IEnumerable<IPerson> GetPersonList()
    {

        try
        {
            var content = _fileService.GetContentFromFile(@"C:\IT_kurser\Kurser\Webbutveckling-dotnet\CSharp\C-SharpUppgift\content.json");
            if (!string.IsNullOrEmpty(content))
            {
                _contactList = JsonConvert.DeserializeObject<List<IPerson>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return _contactList;
            }

        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

    public void SaveToFile()
    {
        IServiceResult response = new ServiceResult();
        _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contactList, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        }), @"C:\IT_kurser\Kurser\Webbutveckling-dotnet\CSharp\C-SharpUppgift\content.json");
        response.Status = Enums.ServiceStatus.SUCCEDED;
        Console.WriteLine("Sparat ned i listan");
        Console.ReadKey();
    }

}

