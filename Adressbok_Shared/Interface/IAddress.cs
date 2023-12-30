

namespace Adressbok_Shared.Interface;

public interface IAddress
{

    /// <summary>
    /// Managing address details. With properties for City, Country, PostalCode, and StreetName.
    /// </summary>
    string City { get; set; }
    string Country { get; set; }
    string PostalCode { get; set; }
    string StreetName { get; set; }
}