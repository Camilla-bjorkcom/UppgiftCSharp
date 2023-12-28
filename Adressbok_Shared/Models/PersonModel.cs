using Adressbok_Shared.Interface;


namespace Adressbok_Shared.Models;

public class PersonModel : IPerson
{

    //Tom konstruktor
    public PersonModel()
    {

    }

    //Propertys till klassen
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Id { get; set; }
    public IAddress YourAddress { get; set; } = new AddressModel();  
    public IContactInformation YourContactInformation { get; set; } = new ContactInformationModel();
}