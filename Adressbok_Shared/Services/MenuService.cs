using Adressbok_Shared.Interface;
using Adressbok_Shared.Repository;


namespace Adressbok_Shared.Services;

public class MenuService : IMenuService
{

    private readonly IPersonService _personService;

    public MenuService(IPersonService personService)
    {
        _personService = personService;
    }

    public void ShowMainMenu()
    {

        while (true)
        {
            Console.WriteLine();
            DisplayMenuTitle("Din Adressbok");
            Console.WriteLine();
            Console.WriteLine("Välj ett alternativ: ");
            Console.WriteLine($"{" 1. ",-4} Visa alla kontakter i adressboken");
            Console.WriteLine($"{" 2. ",-4} Lägg till en ny kontakt i adressboken");
            Console.WriteLine($"{" 3. ",-4} Ta bort en kontakt från adressboken");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    _personService.ShowAllContacts();
                    break;
                case "2":
                    _personService.AddNewContact();
                    break;
                case "3":
                    Console.WriteLine("Skriv in korrekt e-postadress: ");
                    var targetEmail = Console.ReadLine();
                    _personService.DeleteContactFromList(targetEmail!);
                    break;
                default:
                    Console.WriteLine("Du har angivit ett ogiltig val");
                    Console.ReadKey();
                    break;
            }
        }
    }

    public void DisplayMenuTitle(string title)
    {
        Console.Clear();
        Console.WriteLine($"###### {title} ######");
        Console.WriteLine();
    }

}
