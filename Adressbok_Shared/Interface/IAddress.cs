

namespace Adressbok_Shared.Interface;

public interface IAddress
{
    /// <summary>
    /// 
    /// </summary>
    string City { get; set; }
    string Country { get; set; }
    string PostalCode { get; set; }
    string StreetName { get; set; }
}