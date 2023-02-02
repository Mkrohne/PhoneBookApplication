namespace PhoneBookApplication.Interfaces;

internal interface IContact
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Adress { get; set; }
    public string Email { get; set; }
}
