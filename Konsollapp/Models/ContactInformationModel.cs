
using Konsollapp_adressbok.Interface;

namespace Konsollapp_adressbok.Models;

internal class ContactInformationModel : IContactInformation
{
    public string Email { get; set; } = null!; 
    public string? PhoneNumber { get; set; } 
}
