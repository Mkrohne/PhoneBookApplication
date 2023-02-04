
using PhoneBookApplication.Models;

namespace PhoneBookApplication.Services;

internal class Menu
{
    private List<Contact> contacts = new List<Contact>();
    private FileService file = new FileService(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\pbList.json");

    public string FilePath { get; set; } = null!;
    public void MainMenu()
    {
        Console.Clear();
        file.Read();
        Console.WriteLine("Välkommen till Telefonboken\n");
        Console.WriteLine("[1] Lägg till kontakt");
        Console.WriteLine("[2] Sök på en kontakt");
        Console.WriteLine("[3] Visa alla kontakter");
        Console.WriteLine("[4] To bort en kontakt\n");
        Console.WriteLine("Välj en siffra enligt ovan för att göra det du önskar:");
        var option = Console.ReadLine();

        switch(option)
        {
            case "1": Add(); break;
            case "2": Search(); break;
            case "3": ShowAll(); break;
            case "4": Remove(); break;

        }
    }
    private void Add()
    {
        Console.Clear();
        Console.WriteLine("Lägg till ny kontakt\n");
        Contact contact = new Contact();
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
        file.SaveContact(contacts);
        file.Read();
        

        Console.Clear();
        Console.WriteLine("Kontakt lades till i telefonboken.\nTryck på valfri tangent för att komma till huvudmenyn.");
        Console.ReadKey();
    }
    private void Search()
    {
        Console.Clear();
        contacts = file.Read();
        Console.WriteLine("Sök på en kontakt\n");
        Console.WriteLine("Ange Förnamn:");
        var firstName = Console.ReadLine();
        Console.WriteLine("Ange Efternamn:");
        var lastName = Console.ReadLine();

        var contact = contacts.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
        if (contact == null)
        {
            Console.WriteLine("Kontakten kunde inte hittas.");
        }
        else
        {
            Console.Clear() ;
            Console.WriteLine($"Förnamn: {contact.FirstName}\nEfternamn: {contact.LastName}\nAdress: {contact.Adress}\nTelefonnummer: {contact.PhoneNumber}\nE-postadress: {contact.Email}");
        }
        Console.WriteLine("\nTryck på valfri tangent för att komma till huvudmenyn");
        Console.ReadKey();
    }
    private void ShowAll()
    {
        Console.Clear();
        contacts = file.Read();
        Console.WriteLine("Visar alla kontakter\n");
        if (contacts.Count == 0)
        {
            Console.WriteLine("Det finns inga kontaker");
        }
        else
        {
            foreach (Contact contact in contacts)
            {
                Console.WriteLine($"Förnamn: {contact.FirstName}\nEfternamn: {contact.LastName}\nAdress: {contact.Adress}\nTelefonnummer: {contact.PhoneNumber}\nE-postadress: {contact.Email}");
                Console.WriteLine("\nTryck på valfri tangent för att gå till huvudmenyn");
            }
        }
        //file.Read();
        Console.ReadKey();
    }
    private void Remove()
    {
        Console.Clear();
        Console.WriteLine("Ta bort en kontakt\n");
        Console.WriteLine("Ange förnamn");
        var firstName = Console.ReadLine();
        Console.WriteLine("Ange efternamn");
        var lastName = Console.ReadLine();

        var contact = contacts.FirstOrDefault(c => c.FirstName.ToLower() == firstName && c.LastName.ToLower() == lastName);
        if (contact == null)
        {
            Console.Clear();
            Console.WriteLine("Kontaken hittades inte");
        }
        else
        {
            Console.Clear() ;
            Console.WriteLine($"Är du säker på att du vill ta bort: '{firstName} {lastName}'? (y/n)");
            var confirm = Console.ReadLine();

            if (confirm.ToLower() == "y")
            {
                contacts.Remove(contact);
                file.Delete(firstName, lastName);
                Console.Clear();
                Console.WriteLine($"Kontakten: '{firstName} {lastName}' har tagits bort.");
                file.SaveContact(contacts);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ingen kontakt togs bort");
            }
        }
        file.Read();
        Console.WriteLine("\nTryck på valfri tanget för att gå till huvudmenyn.");
        Console.ReadKey();
    }
}
