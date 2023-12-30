
namespace Adressbok_Shared.Interface;

public interface IContactInformation
{
    /// <summary>
    /// Managing contact information. With properties for Email and Phonenumber.
    /// </summary>
    string Email { get; set; }
    string? PhoneNumber { get; set; }
}