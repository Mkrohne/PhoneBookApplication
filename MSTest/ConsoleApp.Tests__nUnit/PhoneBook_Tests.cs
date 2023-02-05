using ConsoleApp.Models;
using ConsoleApp.Services;

namespace ConsoleApp.Tests__nUnit
{
    public class PhoneBook_Tests
    {
        private PhoneBook phoneBook;
        Contact contact;

        [SetUp]
        public void Setup()
        {
            //arrange
            phoneBook= new PhoneBook();
            contact= new Contact();
            

        }

        [Test]
        public void Shuld_Add_Contact_To_List()
        {
            
            phoneBook.ContacList.Add(contact);
            phoneBook.ContacList.Add(contact);

            //assert
            Assert.That(phoneBook.ContacList.Count, Is.EqualTo(2));

        }

        [Test]
        public void Shuld_Remove_Contact_From_List()
        {
            //arrange
            phoneBook.ContacList.Add(contact);
            phoneBook.ContacList.Add(contact);

            //Act
            phoneBook.ContacList.Remove(contact);

            //assert
            Assert.That(phoneBook.ContacList.Count, Is.EqualTo(1));
        }
    }
}
