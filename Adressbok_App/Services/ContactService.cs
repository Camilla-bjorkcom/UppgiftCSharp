

using Adressbok_App.Mvvm.Models;
using Adressbok_Shared.Repository;
using Newtonsoft.Json;

using System.Diagnostics;

namespace Adressbok_App.Services;

public class ContactService 
{
    private readonly FileService _fileService;

    public ContactService(FileService fileService)
    {
        _fileService = fileService;
    }

    private List<Contact> _contacts = [];

    public Contact CurrentContact { get; set; } = null!;


    public void Add(Contact contact)
    {
        try
        {
        _contacts.Add(contact);
        contact.Id = _contacts.Count + 1;
        SaveToFile();
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    public IEnumerable<Contact> GetAll()
    {
        try
        {
            var content = _fileService.GetContentFromFile(@"C:\IT_kurser\Kurser\Webbutveckling-dotnet\CSharp\C-SharpUppgift\contentApp.json");
            if (!string.IsNullOrEmpty(content))
            {
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return _contacts;
            }
           
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

    public void Update (Contact contact)
    {
        var contactPerson = _contacts.FirstOrDefault(x => x.Id == contact.Id);
        if (contactPerson != null)
        {
            contactPerson = contact;
            SaveToFile();
        }
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

    

public void SaveToFile()
    {
       
        _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        }), @"C:\IT_kurser\Kurser\Webbutveckling-dotnet\CSharp\C-SharpUppgift\contentApp.json");
        
    }
}


