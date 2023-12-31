using Adressbok_Shared.Interface;


namespace Adressbok_Shared.Models;

public class AddressModel : IAddress
{
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;

}

