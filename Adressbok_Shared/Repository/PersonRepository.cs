using Adressbok_Shared.Interface;
using Adressbok_Shared.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;


namespace Adressbok_Shared.Repository;

public class PersonRepository
{
    /// <summary>
    /// Contact list to store contacts of type IPerson.
    /// </summary>
    public List<IPerson> _contactList = new List<IPerson>();

    private readonly IFileService _fileService;

    public PersonRepository(IFileService fileService)
    {
        _fileService = fileService;
    }


    /// <summary>
    /// Adds a person to the list and saves it to a data source.
    /// </summary>
    /// <param name="person">The person of type IPerson to be added.</param>
    /// <returns>An IServiceResult indicating the status of the addition operation.</returns>
    public IServiceResult AddToList(IPerson person)
    {

        IServiceResult response = new ServiceResult();
        try
        {
            if (!_contactList.Any(x => x.YourContactInformation.Email == person.YourContactInformation.Email))
            {
                _contactList.Add(person);
                person.Id = _contactList.Count + 1;
                SaveToFile();
                response.Status = Enums.ServiceStatus.SUCCEDED;
            }
            else
            {
                Console.WriteLine("Kontakten existerar redan i listan");
                response.Status = Enums.ServiceStatus.ALREADY_EXISTS;
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

    // <summary>
    /// Retrieves a list of persons from a data source.
    /// </summary>
    /// <returns>An IEnumerable<IPerson> representing the list of persons; null if retrieval fails.</returns>
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

    /// <summary>
    /// Saves the list of persons to a data source.
    /// </summary>
    public void SaveToFile()
    {
        IServiceResult response = new ServiceResult();
        _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contactList, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        }), @"C:\IT_kurser\Kurser\Webbutveckling-dotnet\CSharp\C-SharpUppgift\content.json");

        response.Status = Enums.ServiceStatus.SUCCEDED;

        Console.WriteLine("Uppdaterat listan");
        Console.ReadKey();
    }

}
