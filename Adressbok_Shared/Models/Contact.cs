
using Adressbok_Shared.Interface;

namespace Adressbok_Shared.Models;

public class Contact : IContact
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string StreetName { get; set; } = null!;

    public string PostalCode { get; set; } = null!;
    public string CityName { get; set; } = null!;

    public string InputEmail { get; set; } = null!;

}
