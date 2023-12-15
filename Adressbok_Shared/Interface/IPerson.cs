

using Adressbok_Shared.Models;

namespace Adressbok_Shared.Interface;

public interface IPerson
{
    ContactInformationModel YourContactInformation { get; set; }
    AddressModel YourAddress { get; set; }
    string FirstName { get; set; }
    int Id { get; set; }
    string LastName { get; set; }

}