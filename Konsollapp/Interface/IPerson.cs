using Konsollapp_adressbok.Models;

namespace Konsollapp_adressbok.Interface
{
    internal interface IPerson
    {
        ContactInformationModel YourContactInformation { get; set;  }
        AddressModel YourAddress { get; set; }
        string FirstName { get; set; }
        int Id { get; set; }
        string LastName { get; set; }
     
    }
}