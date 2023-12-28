namespace Adressbok_Shared.Interface
{
    public interface IContact
    {
        string CityName { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        Guid Id { get; set; }
        string InputEmail { get; set; }
        string LastName { get; set; }
        string Phone { get; set; }
        string PostalCode { get; set; }
        string StreetName { get; set; }
    }
}