


using Adressbok_Shared.Interface;
using Adressbok_Shared.Models;
using Adressbok_Shared.Services;
using Newtonsoft.Json;

using System.Diagnostics;
using System.Linq.Expressions;

namespace Adressbok_Shared.Services;

public class ContactService
{
    private readonly IFileService _fileService;

    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
    }


    public List<IContact> _contacts = [];

    public IContact CurrentContact { get; set; } = null!;


    public bool Add(IContact contact)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(contact.FirstName) && !string.IsNullOrWhiteSpace(contact.Email))
            {
                _contacts.Add(contact);
                SaveToFile();

            }
            return true;
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return false;
    }



    public IEnumerable<IContact> GetAll()
    {
        try
        {
            var content = _fileService.GetContentFromFile(@"C:\IT_kurser\Kurser\Webbutveckling-dotnet\CSharp\C-SharpUppgift\contentApp1.json");
            if (!string.IsNullOrWhiteSpace(content))
            {
                _contacts = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return _contacts;
            }


        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

        }
        return default!;
    }

    public bool Update(IContact contact)
    {
        try
        {
            var contactPerson = _contacts.FirstOrDefault(x => x.Id == contact.Id);
            if (contactPerson != null)
            {
                
                if (!String.IsNullOrWhiteSpace(contact.Email))
                {
                     contactPerson = contact;
                     SaveToFile();
                }
                return true;
                   
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
       
       
    }

    public bool Remove(string email)
    {
        try
        {

            if (!string.IsNullOrWhiteSpace(email))
            {
                GetAll();
                var result = _contacts.RemoveAll(person => person.Email == email);
                SaveToFile();
            }
            return true;
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }



    public bool SaveToFile()
    {
        try
        {

            _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            }), @"C:\IT_kurser\Kurser\Webbutveckling-dotnet\CSharp\C-SharpUppgift\contentApp1.json");
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }
}


