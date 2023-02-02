using PhoneBookApplication.Interfaces;
using PhoneBookApplication.Models;

namespace PhoneBookApplication.Services;

internal class Menu
{
    private List<IContact> contacts = new List<IContact>();
    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Välkommen till Telefonboken\n\n");
        Console.WriteLine("[1] Lägg till kontakt");
        Console.WriteLine("[2] Sök på en kontakt");
        Console.WriteLine("[3] Visa alla kontakter");
        Console.WriteLine("[4] To bort en kontakt\n");
        Console.WriteLine("Välj en siffra enligt ovan för att göra det du önskar:");
        var option = Console.ReadLine();

        switch(option)
        {
            case "1": One(); break;
            case "2": Two(); break;
            case "3": Three(); break;
            case "4": Four(); break;

        }
    }
    private void One()
    {
        Console.Clear();
        Console.WriteLine("Lägg till ny kontakt\n");
        IContact contact = new Contact();
        Console.WriteLine("Ange Förnamn: ");
        contact.FirstName = Console.ReadLine() ?? "";
        Console.WriteLine("Ange Efternamn: ");
        contact.LastName = Console.ReadLine() ?? "";
        Console.WriteLine("Ange Telefonnummer: ");
        contact.PhoneNumber = Console.ReadLine() ?? "";
        Console.WriteLine("Ange Adress: ");
        contact.Adress = Console.ReadLine() ?? "";
        Console.WriteLine("Ange E-postadress: ");
        contact.Email = Console.ReadLine() ?? "";
        
        contacts.Add(contact);
        Console.Clear();
        Console.WriteLine("\nKontakt lades till i telefonboken.\nTryck på valfri tangent för att komma till huvudmenyn");
        Console.ReadKey();
    }
    private void Two()
    {
        Console.Clear();
        Console.WriteLine("Sök på en kontakt");
        Console.ReadKey();
    }
    private void Three()
    {
        Console.Clear();
        Console.WriteLine("Visa alla kontakter");
        Console.ReadKey();
    }
    private void Four()
    {
        Console.Clear();
        Console.WriteLine("Ta bort en kontakt");
        Console.ReadKey();
    }
}
