using PhoneBookApplication.Interfaces;


namespace PhoneBookApplication.Models
{
    internal class Contact : IContact
    {
        public Guid Id { get ; set ; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get ; set ; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
