

using Adressbok_Shared.Models;

namespace Adressbok_Shared.Interface;

public interface IPerson
{
    IContactInformation YourContactInformation { get; set; }
    IAddress YourAddress { get; set; }
    string FirstName { get; set; }
    int Id { get; set; }
    string LastName { get; set; }

}