
using Konsollapp_adressbok.Interface;

namespace Konsollapp_adressbok.Models;

public class PersonModel : IPerson
{
    
    //Tom konstruktor
    public PersonModel()
    {

    }

    //Propertys till klassen
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public int Id { get; set; }

    public AddressModel YourAddress { get; set; } = new AddressModel();

    public ContactInformationModel YourContactInformation { get; set; } = new ContactInformationModel();


}
