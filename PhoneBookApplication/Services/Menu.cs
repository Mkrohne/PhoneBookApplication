using Newtonsoft.Json;
using PhoneBookApplication.Interfaces;
using PhoneBookApplication.Models;

namespace PhoneBookApplication.Services;

internal class Menu
{
    private List<IContact> contacts = new List<IContact>();
    private FileService file = new FileService();

    public string FilePath { get; set; } = null!;
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
        file.SaveContact(FilePath, JsonConvert.SerializeObject(contacts));

        Console.Clear();
        Console.WriteLine("\nKontakt lades till i telefonboken.\nTryck på valfri tangent för att komma till huvudmenyn.");
        Console.ReadKey();
    }
    private void Two()
    {
        Console.Clear();
        
        Console.WriteLine("Sök på en kontakt\n");
        Console.WriteLine("Ange Förnamn:");
        var firstName = Console.ReadLine();
        Console.WriteLine("Ange Efternamn:");
        var lastName = Console.ReadLine();

        var contact = contacts.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
        if (contact != null)
        {
            Console.WriteLine("Kontakten kunde inte hittas.");
        }
        else
        {
            Console.WriteLine($"Förnamn: {contact.FirstName}\nEfternamn: {contact.LastName}\n Adress: {contact.Adress}\n Telefonnummer: {contact.PhoneNumber}\n E-postadress: {contact.Email}");
        }
        Console.WriteLine("\nTryck på valfri tangent för att komma till huvudmenyn");
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
