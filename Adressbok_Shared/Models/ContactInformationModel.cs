using Adressbok_Shared.Interface;


namespace Adressbok_Shared.Models;

public class ContactInformationModel : IContactInformation
{
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
}
