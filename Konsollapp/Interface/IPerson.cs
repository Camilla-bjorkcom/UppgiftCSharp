using Konsollapp_adressbok.Models;

namespace Konsollapp_adressbok.Interface
{
    internal interface IPerson
    {
        ContactInformation ContactInformation { get; set;  }
        Address Address { get; set; }
        string FirstName { get; set; }
        string FullName { get; }
        int Id { get; set; }
        string LastName { get; set; }
     
    }
}