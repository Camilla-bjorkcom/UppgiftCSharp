namespace Konsollapp_adressbok.Interface;

public interface IAddress
{
    string City { get; set; }
    string Country { get; set; }
    string PostalCode { get; set; }
    string StreetName { get; set; }
}