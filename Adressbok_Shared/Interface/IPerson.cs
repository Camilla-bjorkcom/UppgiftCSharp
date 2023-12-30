

using Adressbok_Shared.Models;

namespace Adressbok_Shared.Interface;

public interface IPerson
{
    /// <summary>
    /// Managing essential details about an individual, including contact information, address, first name, unique ID, and last name.
    /// </summary>
    IContactInformation YourContactInformation { get; set; }
    IAddress YourAddress { get; set; }
    string FirstName { get; set; }
    int Id { get; set; }
    string LastName { get; set; }

}