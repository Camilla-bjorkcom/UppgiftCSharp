

using Konsollapp_adressbok.Interface;

namespace Konsollapp_adressbok.Services;

internal class MenuService : IMenuService
{
    public void ShowMainMenu()
    {
       while (true)
        {
            Console.WriteLine();
            DisplayMenuTitle("Din Adressbok");
            Console.WriteLine();
            Console.WriteLine("Välj ett alternativ: ");
            Console.WriteLine($"{" 1. ", - 4} Visa alla kontakter i adressboken" );
            Console.WriteLine($"{" 2. ", - 4} Lägg till en ny kontakt i adressboken" );

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    // ShowAllContacts();
                    break;
                case "2":
                    // AddNewContact();
                    break;
                default:
                    Console.WriteLine("Du har angivit ett ogiltig val");
                    break;
            }
        }
    }

    private void DisplayMenuTitle(string title)
    {
        Console.Clear();
        Console.WriteLine($"###### {title} ######");
        Console.WriteLine();
    }

}
