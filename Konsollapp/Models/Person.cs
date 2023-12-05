
using Konsollapp_adressbok.Interface;

namespace Konsollapp_adressbok.Models;

internal class Person : IPerson
{
    //Tom konstruktor
    public Person()
    {

    }

    //Propertys till klassen
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;

    public int Id { get; set; }

    public Address Address { get; set; } = null!;

    public ContactInformation ContactInformation { get; set; } = null!;
    public string FullName => $"{FirstName} {LastName}";

}
