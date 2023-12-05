

using Konsollapp_adressbok.Interface;

namespace Konsollapp_adressbok.Models;

internal class Address : IAddress
{
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;

}
